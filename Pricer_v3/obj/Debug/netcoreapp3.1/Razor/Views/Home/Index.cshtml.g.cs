#pragma checksum "/Users/evgenijlasenko/RiderProjects/Pricer_v3/Pricer_v3/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "102bec26331c45b8687c7bf447dfdb0328a0dade"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.razor-page", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"102bec26331c45b8687c7bf447dfdb0328a0dade", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "/Users/evgenijlasenko/RiderProjects/Pricer_v3/Pricer_v3/Views/Home/Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!DOCTYPE html>\n\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "102bec26331c45b8687c7bf447dfdb0328a0dade2869", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"" integrity=""sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk"" crossorigin=""anonymous"">
    <title>Сервис для мониторинга цены</title>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "102bec26331c45b8687c7bf447dfdb0328a0dade4088", async() => {
                WriteLiteral(@"
<div id=""app"">
    <div style=""max-width: 900px; margin: 20px auto; font-family: sans-serif; "">
        <h1 style=""font-weight: 700; font-size: 28px;"">Сервис для мониторинга цены</h1>
        <div style=""font-size: 12px; margin: 15px 0; color: #111"">Введите адрес страницы товара, цену которого вы хотите отслеживать, и адрес почты, чтобы получать уведомления</div>
        <div class=""input-group flex-nowrap"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text"" id=""addon-wrapping"">Адрес страницы</span>
            </div>
            <input type=""text"" class=""form-control"" aria-describedby=""addon-wrapping"" v-model=""url"">
        </div>
        <div class=""input-group  flex-nowrap"" style=""margin-top: 12px"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text"" id=""addon-wrapping"">Email</span>
            </div>
            <input v-model=""email"" type=""text"" class=""form-control"" aria-describedby=""addon-wrapping"" style=""max-width: 250p");
                WriteLiteral(@"x; margin-right: 18px"">
            <button type=""button"" class=""btn btn-primary"" v-on:click=""submit"" :disabled=""loading"">Начать мониторинг</button>
        </div>
        <div class=""alert alert-info"" role=""alert"" :style=""{display: info != '' ? 'block' : 'none' }"" style=""margin-top: 10px;"">
          {{ info }}<span id=""wait"" :style=""{display: loading ? 'inline' : 'none' }"">.</span>
        </div>
    </div>
</div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script src=""https://cdn.jsdelivr.net/npm/vue/dist/vue.js""></script>
<script src=""https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js""></script>
<script>
var dots = window.setInterval( function() {
    var wait = document.getElementById(""wait"");
    if ( wait.innerHTML.length > 3 ) 
        wait.innerHTML = """";
    else 
        wait.innerHTML += ""."";
    }, 400);
var app = new Vue({
    el: '#app',
    data:{
        url: """",
        email: """",
        info: """",
        loading: false
    },
    methods: {
        submit: function () {
            if (!this.validateUrl(this.url))
            {
              this.info = ""Адрес страницы не соответствует формату"";
              return;
            }
            if (!this.validateEmail(this.email))
            {
             this.info = ""Email не соответствует формату"";
             return;
            }

            this.info = ""Выполняется анализ переданой страницы, ожидайте"";
            this.loading = true;
            axios.get('/api/pricer', {
          ");
            WriteLiteral(@"      params: {
                  url: this.url,
                  email: this.email
                }
              })
              .then(function (response) {
                resp = response.data;
                if (resp.error != null)
                    app.info = ""К сожалению, возникла ошибка при распознании цены, попробуйте с другим магазином"";
                else if(resp.price != null)
                    app.info = ""Мониторинг запущен. На данный момент цена: "" + resp.price;
                else
                    app.info = ""К сожалению, на возникла ошибка"";
                app.loading = false;
              })
              .catch(function (error) {
                  app.info = ""К сожалению, на сервере возникла ошибка"";
                  app.loading = false;
              });
        },
        validateEmail: function (email) {
            var re = /^(([^<>()\[\]\\.,;:\s");
            WriteLiteral("@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s");
            WriteLiteral("@\"]+)*)|(\".+\"))");
            WriteLiteral(@"@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(String(email).toLowerCase());
        },
        validateUrl: function(url) {
            var re = /((([A-Za-z]{3,9}:(?:\/\/)?)(?:[\-;:&=\+\$,\w]+");
            WriteLiteral("@)?[A-Za-z0-9\\.\\-]+|(?:www\\.|[\\-;:&=\\+\\$,\\w]+");
            WriteLiteral("@)[A-Za-z0-9\\.\\-]+)((?:\\/[\\+~%\\/\\.\\w\\-_]*)?\\??(?:[\\-\\+=&;%");
            WriteLiteral("@\\.\\w_]*)#?(?:[\\.\\!\\/\\\\\\w]*))?)/\n            return re.test(String(url));\n        }\n    }\n})\n</script>\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pricer_v3.Views.Home> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pricer_v3.Views.Home> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pricer_v3.Views.Home>)PageContext?.ViewData;
        public Pricer_v3.Views.Home Model => ViewData.Model;
    }
}
#pragma warning restore 1591
