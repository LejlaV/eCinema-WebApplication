#pragma checksum "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d5f30f118c2738498b58d1c1d79dba97896d925"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reziser_Index), @"mvc.1.0.view", @"/Views/Reziser/Index.cshtml")]
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
#line 5 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
using Kino.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
using PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d5f30f118c2738498b58d1c1d79dba97896d925", @"/Views/Reziser/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df205999c203b7c097cfb1dbb724ed6ac27f2c63", @"/Views/_ViewImports.cshtml")]
    public class Views_Reziser_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList<ReziserAddVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Slika nije dodana!"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Prikaz rezisera</h1>\r\n\r\n<label style=\"color:green\">");
#nullable restore
#line 10 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
                      Write(ViewData["poruka-kljuc"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<label style=\"color:red\"> ");
#nullable restore
#line 11 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
                     Write(ViewData["poruka1-kljuc"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
<style>
    img {
        width: 180px;
        height: 100px;
    }
</style>
<script type=""text/javascript"">
        $(document).ready(function(){
            $(""#btnsave"").click(function () {
                validationForm();
            })
        });
    function validationForm() {
        if ($(""#Ime"").val() == """") {
            alert(""Ime ne smije biti prazno!"");
        return false;
    }
}
</script>
<table class=""table"">
    <thead class=""table table-bordered"">
        <tr>
            <th>Ime</th>
            <th>Prezime</th>
            <th>Datum rodjenja</th>
            <th>Mjesto rodjenja</th>
            <th>Slika</th>
            <th>Akcija</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 43 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 46 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
               Write(item.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 47 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
               Write(item.Prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 48 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
               Write(item.DatumRodjenja.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 49 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
               Write(item.MjestoRodjenja);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                <td> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d5f30f118c2738498b58d1c1d79dba97896d9256585", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1306, "~/images/", 1306, 9, true);
#nullable restore
#line 51 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
AddHtmlAttributeValue("", 1315, item.putanjaSlike, 1315, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "asp-for", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 51 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
AddHtmlAttributeValue("", 1344, item.putanjaSlike, 1344, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1442, "\"", 1506, 4);
            WriteAttributeValue("", 1449, "/Reziser/Dodaj?id=", 1449, 18, true);
#nullable restore
#line 53 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
WriteAttributeValue("", 1467, item.ReziserID, 1467, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1482, "&put=", 1483, 6, true);
#nullable restore
#line 53 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
WriteAttributeValue("", 1488, item.putanjaSlike, 1488, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Uredi</a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1565, "\"", 1624, 4);
            WriteAttributeValue("", 1572, "/Reziser/Obrisi?ime=", 1572, 20, true);
#nullable restore
#line 54 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
WriteAttributeValue("", 1592, item.Ime, 1592, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1601, "&prezime=", 1602, 10, true);
#nullable restore
#line 54 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
WriteAttributeValue("", 1611, item.Prezime, 1611, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Obrisi</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 57 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </tbody>\r\n</table>\r\n<br />\r\n<br />\r\n<a href=\"/home\" class=\"btn btn-danger\"><<</a>\r\n<a href=\"/Reziser/Dodaj\" class=\"btn btn-success\">Dodaj</a>\r\n\r\n<br />\r\n<br />\r\n<ul class=\"pagination\">\r\n");
#nullable restore
#line 70 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
     for (int i = 1; i <= Model.PageCount; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li");
            BeginWriteAttribute("class", " class=\"", 1975, "\"", 2046, 1);
#nullable restore
#line 72 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
WriteAttributeValue("", 1983, i == Model.TotalItemCount ? "page-item active" : "page-item", 1983, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2082, "\"", 2127, 1);
#nullable restore
#line 73 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
WriteAttributeValue("", 2089, Url.Action("Index", new { page = i }), 2089, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 73 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"
                                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        </li>\r\n");
#nullable restore
#line 75 "C:\Users\User\source\repos\webapp\Kino\Views\Reziser\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList<ReziserAddVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591