using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Flurl.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Pricer_v3
{

    public interface IPricerService
    {
        Task<PricerResponse> GetPrice(string url);
    }
    public class PricerService : IPricerService
    {
        const string digits = @"\d";
        const string space = @"(\s|&nbsp;|&ensp;|&emsp;)";
        const string dots = @"[\.\,'\-]";
        const string lastsymbol = @"(?!(\d|"+dots+"))";

            
        const string from1to3 = @"{1,3}";
        const string from1to2 = @"{1,2}";
        const string only3 = @"{3}";
        
        class PriceMatches
        {
             public List<string> StrValues { get; set; }
             public List<double> NumValues { get; set; }
        }
        
        private static ChromeOptions options;
        static PricerService()
        {
            options = new ChromeOptions();
            options.AddArgument("--enable-popup-blocking");
            options.AddArgument("--headless");
        }

        public async Task<PricerResponse> GetPrice(string url)
        {
            using (var driver = new RemoteWebDriver(new Uri("http://chrome:4444/wd/hub"), options))
            {
                string base64Screenshot;
                try
                {
                    driver.Manage().Window.Size = new Size(1280, 2000);
                    driver.Navigate().GoToUrl(url);
                    base64Screenshot = driver.GetScreenshot().AsBase64EncodedString;
                }
                catch (Exception)
                {
                    Console.WriteLine("Browser error" );
                    return new PricerResponse() { Error = "Browser error" };
                }

                DetectorResponse response;
                try
                {
                    response = await "http://flask:5050/detector"
                        .WithTimeout(60)
                        .PostJsonAsync(new {image = base64Screenshot})
                        .ReceiveJson<DetectorResponse>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error with detector API");
                    return new PricerResponse() { Error = "Error with detector API" };
                }

                if (response.Error != null)
                    return new PricerResponse() { Error = "Can't detect price on page" };
                try
                {
                    return new PricerResponse() { Price = FindPriceInHtml(driver, response) };
                }
                catch (Exception e)
                {
                    return new PricerResponse() { Error = "Can't find detected price in HTML code" };
                }
            }
        }

        private double FindPriceInHtml(IWebDriver driver, DetectorResponse response)
        {
            int x = (response.Box[2] + response.Box[0]) / 2;
            int y = (response.Box[3] + response.Box[1]) / 2;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement theElement = (IWebElement)js
                .ExecuteScript($"return document.elementFromPoint({x}, {y});");
            string html = theElement.GetAttribute("outerHTML");
            return ParsePrice(html, response.Texts);
        }

        private double ParsePrice(string html, string[] variants)
        {
            PriceMatches mathces = RegSearch(html);
            for (int i = 0; i < mathces.StrValues.Count(); i++)
            {
                foreach (var variant in variants)
                {
                    if (mathces.StrValues[i].IndexOf(variant) != -1)
                        return mathces.NumValues[i];
                }
            }

            throw new Exception("Price isn't found in HTML code");
        }

        private PriceMatches RegSearch(string html)
        {
            var matches1 = SerachType1(html);
            var matches2 = SerachType2(html);

            var matches = new PriceMatches {StrValues = matches1.Union(matches2).ToList()};
            ParseMatches(ref matches, matches1, matches2);
            return matches;
        }

        private List<string> SerachType1(string html)
        {
            string firstDigits = $"({digits}{from1to3}{space}?)";
            string otherDigits = $"({digits}{only3}{space}?)*";
            string cents = $"({space}?{dots}{space}?{digits}{from1to2})";

            Regex regex = new Regex($"({firstDigits}{otherDigits}{cents}?){lastsymbol}");
            return regex.Matches(html)
                .Select(x=> Regex.Replace(x.Value, space, " "))
                .ToList();
        }
        
        private List<string> SerachType2(string html)
        {
            string firstDigits = $"({digits}{from1to3}(\\,))";
            string otherDigits = $"({digits}{only3}(\\,))*";
            string cents = $"({space}?{dots}{space}?{digits}{from1to2})";

            Regex regex = new Regex($"({firstDigits}{otherDigits}{cents}?){lastsymbol}");
            return regex.Matches(html)
                .Select(x=> x.Value)
                .ToList();
        }

        private void ParseMatches(ref PriceMatches mathces, IEnumerable<string> matches1, IEnumerable<string> matches2)
        {
            var temp_matches = matches1.Union(matches2.Select(x => x.Replace(",", "")))
                .Select(x => x.Replace(" ", ""))
                .Select(x => Regex.Replace(x, dots, ".")).ToArray();


            mathces.NumValues = new List<double>();
            for (int i = 0; i < temp_matches.Count(); i++)
            {
                try
                {
                    mathces.NumValues.Add(double.Parse(temp_matches[i], CultureInfo.InvariantCulture));
                }
                catch (Exception)
                {
                    mathces.NumValues.Add(-1);
                }
            }
        }
    }
}