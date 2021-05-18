namespace Pricer_v3
{
    public class PricerResponse
    {
        public double? Price { get; set; }
        public string Title { get; set; } = "";
        public string Site { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string Error { get; set; }
    }
}