#pragma checksum "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "943fd0664a3853c0d0a8b70507e9efa57b974ca5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Zaposlenik_VrstaDvoraneIndex), @"mvc.1.0.view", @"/Views/Zaposlenik/VrstaDvoraneIndex.cshtml")]
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
#line 1 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
using Kino.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
using PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"943fd0664a3853c0d0a8b70507e9efa57b974ca5", @"/Views/Zaposlenik/VrstaDvoraneIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df205999c203b7c097cfb1dbb724ed6ac27f2c63", @"/Views/_ViewImports.cshtml")]
    public class Views_Zaposlenik_VrstaDvoraneIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList<VrstaDvorane>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
  
	ViewData["Title"] = "Prikazi";

	var porukasuccess = (string)ViewData["porukasuccess"];
	var porukaerror = (string)ViewData["porukaerror"];

	List<VrstaDvorane> dvorane = (List<VrstaDvorane>)ViewData["vrste-kljuc"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Vrste dvorana</h1>\r\n<label style=\"color: red\">");
#nullable restore
#line 15 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
                     Write(porukaerror);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<label style=\"color: green\">");
#nullable restore
#line 16 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
                       Write(porukasuccess);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<table class=\"table\">\r\n\t<thead>\r\n\t\t<tr>\r\n\t\t\t<th>Vrsta dvorane</th>\r\n\t\t</tr>\r\n\t</thead>\r\n\t<tbody>\r\n");
#nullable restore
#line 24 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
         foreach (var x in Model)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<tr>\r\n\t\t\t\t<td>");
#nullable restore
#line 27 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
               Write(x.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t</tr>\r\n");
#nullable restore
#line 29 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n\r\n</table>\r\n\r\n<ul class=\"pagination\">\r\n");
#nullable restore
#line 35 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
     for (int i = 1; i <= Model.PageCount; i++)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<li");
            BeginWriteAttribute("class", " class=\"", 712, "\"", 783, 1);
#nullable restore
#line 37 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
WriteAttributeValue("", 720, i == Model.TotalItemCount ? "page-item active" : "page-item", 720, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t<a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 810, "\"", 855, 1);
#nullable restore
#line 38 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
WriteAttributeValue("", 817, Url.Action("Index", new { page = i }), 817, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 38 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"
                                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t</li>\r\n");
#nullable restore
#line 40 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\VrstaDvoraneIndex.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList<VrstaDvorane>> Html { get; private set; }
    }
}
#pragma warning restore 1591