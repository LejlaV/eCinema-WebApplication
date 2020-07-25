#pragma checksum "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32747b2fdb34b63dc6804b73ab776cbd1322d5bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Zaposlenik_KinoObjekatIndex), @"mvc.1.0.view", @"/Views/Zaposlenik/KinoObjekatIndex.cshtml")]
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
#line 1 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
using Kino.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32747b2fdb34b63dc6804b73ab776cbd1322d5bb", @"/Views/Zaposlenik/KinoObjekatIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df205999c203b7c097cfb1dbb724ed6ac27f2c63", @"/Views/_ViewImports.cshtml")]
    public class Views_Zaposlenik_KinoObjekatIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<KinoObjekat>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
  
	ViewData["Title"] = "Index";
	var poruka = (string)ViewData["kina"];
	var porukasuccess = (string)TempData["porukasuccess"];
	var porukaerror = (string)TempData["porukaerror"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Prikaz kino objekata</h1>\r\n<label style=\"color:red\">");
#nullable restore
#line 12 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
                    Write(porukaerror);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<label style=\"color:green\">");
#nullable restore
#line 13 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
                      Write(porukasuccess);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n\r\n<table class=\"table\">\r\n\t<thead>\r\n\t\t<tr>\r\n\t\t\t<th>Naziv kina</th>\r\n\t\t\t<th>Adresa ulice</th>\r\n\t\t</tr>\r\n\t</thead>\r\n\t<tbody>\r\n");
#nullable restore
#line 23 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
         foreach (var x in Model)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<tr>\r\n\t\t\t\t<td>");
#nullable restore
#line 26 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
               Write(x.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\t\t\t\t<td>\r\n");
#nullable restore
#line 29 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
                     if (x.Adresa == null)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<label>Nema adrese</label>\r\n");
#nullable restore
#line 32 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
					}
					else
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<label>");
#nullable restore
#line 35 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
                          Write(x.Adresa.NazivUlice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n");
#nullable restore
#line 36 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</td>\r\n\t\t\t</tr>\r\n");
#nullable restore
#line 39 "C:\Users\User\source\repos\webapp\Kino\Views\Zaposlenik\KinoObjekatIndex.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<KinoObjekat>> Html { get; private set; }
    }
}
#pragma warning restore 1591
