#pragma checksum "C:\Users\User\source\repos\webapp\Kino\Views\Film\PregledFilmova.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "645f199782d04f4a1ef63656251ff69d0c44f66b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Film_PregledFilmova), @"mvc.1.0.view", @"/Views/Film/PregledFilmova.cshtml")]
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
#nullable restore
#line 1 "C:\Users\User\source\repos\webapp\Kino\Views\_ViewImports.cshtml"
using Kino;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\webapp\Kino\Views\_ViewImports.cshtml"
using Kino.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\source\repos\webapp\Kino\Views\Film\PregledFilmova.cshtml"
using Kino.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"645f199782d04f4a1ef63656251ff69d0c44f66b", @"/Views/Film/PregledFilmova.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df205999c203b7c097cfb1dbb724ed6ac27f2c63", @"/Views/_ViewImports.cshtml")]
    public class Views_Film_PregledFilmova : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FilmIndexVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Film", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dodaj", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn btn-success filter-button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\User\source\repos\webapp\Kino\Views\Film\PregledFilmova.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "645f199782d04f4a1ef63656251ff69d0c44f66b5039", async() => {
                WriteLiteral(@"
        <link href=""//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css"" rel=""stylesheet"" id=""bootstrap-css"">
        <script src=""//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js""></script>
        <script src=""//code.jquery.com/jquery-1.11.1.min.js""></script>
        <!------ Include the above in your HEAD tag ---------->
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
            WriteLiteral(@"
<style>
    .gallery-title {
        font-size: 36px;
        color: black;
        text-align: center;
        font-weight: 500;
        margin-bottom: 70px;
    }

        .gallery-title:after {
            content: """";
            position: absolute;
            width: 7.5%;
            left: 46.5%;
            height: 45px;
            
        }

    .filter-button {
        font-size: 18px;
       
        border-radius: 5px;
        text-align: center;
        color: white;
        margin-bottom: 30px;
    }

        .filter-button:hover {
            font-size: 18px;
            border: 1px solid #42B32F;
            border-radius: 5px;
            text-align: center;
            color: #ffffff;
            background-color: #42B32F;
        }
      .btn{
          background-color:white;
          color:black;

      }
       .btn-default:active {
        background-color: white;
        color: black;
    }
       .btn-default:hover {
        background-");
            WriteLiteral(@"color: white;
        color: black;
    }
    .btn-default:active .filter-button:active {
        background-color: white;
        color: black;
    }

    .port-image {
        width: 100%;
    }

    .gallery_product {
        margin-bottom: 30px;
       
    }
    
    #slika{
        
       
    }
</style>
<section>
    <div class=""container"">
        <div class=""row"">
            <div class=""gallery col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                <h1 class=""gallery-title"">Filmovi</h1>
            </div>

            <div align=""center"">
                <button class=""btn btn-default filter-button"" data-filter=""all"">Svi</button>
                <button class=""btn btn-default filter-button"" data-filter=""2020"">2020</button>
                <button class=""btn btn-default filter-button"" data-filter=""2019"">2019</button>
                <button class=""btn btn-default filter-button"" data-filter=""2018"">2018</button>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "645f199782d04f4a1ef63656251ff69d0c44f66b8441", async() => {
                WriteLiteral("Dodaj film");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n            <br />\r\n\r\n");
#nullable restore
#line 97 "C:\Users\User\source\repos\webapp\Kino\Views\Film\PregledFilmova.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div id=\"slika\"");
            BeginWriteAttribute("class", " class=\"", 2702, "\"", 2781, 7);
            WriteAttributeValue("", 2710, "gallery_product", 2710, 15, true);
            WriteAttributeValue(" ", 2725, "col-lg-4", 2726, 9, true);
            WriteAttributeValue(" ", 2734, "col-md-4", 2735, 9, true);
            WriteAttributeValue(" ", 2743, "col-sm-4", 2744, 9, true);
            WriteAttributeValue(" ", 2752, "col-xs-6", 2753, 9, true);
            WriteAttributeValue(" ", 2761, "filter", 2762, 7, true);
#nullable restore
#line 99 "C:\Users\User\source\repos\webapp\Kino\Views\Film\PregledFilmova.cshtml"
WriteAttributeValue(" ", 2768, item.Godina, 2769, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "645f199782d04f4a1ef63656251ff69d0c44f66b11039", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2815, "~/images/", 2815, 9, true);
#nullable restore
#line 100 "C:\Users\User\source\repos\webapp\Kino\Views\Film\PregledFilmova.cshtml"
AddHtmlAttributeValue("", 2824, item.putanjaSlike, 2824, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <h3 style=\"text-align:center\"><strong>");
#nullable restore
#line 101 "C:\Users\User\source\repos\webapp\Kino\Views\Film\PregledFilmova.cshtml"
                                                     Write(item.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></h3>\r\n                </div>\r\n");
#nullable restore
#line 103 "C:\Users\User\source\repos\webapp\Kino\Views\Film\PregledFilmova.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
</section>
<script>
    $(document).ready(function () {

        $("".filter-button"").click(function () {
            var value = $(this).attr('data-filter');

            if (value == ""all"") {
                //$('.filter').removeClass('hidden');
                $('.filter').show('1000');
            }
            else {
                //            $('.filter[filter-item=""'+value+'""]').removeClass('hidden');
                //            $("".filter"").not('.filter[filter-item=""'+value+'""]').addClass('hidden');
                $("".filter"").not('.' + value).hide('3000');
                $('.filter').filter('.' + value).show('3000');

            }
        });

        if ($("".filter-button"").removeClass(""active"")) {
            $(this).removeClass(""active"");
        }
        $(this).addClass(""active"");

    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FilmIndexVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
