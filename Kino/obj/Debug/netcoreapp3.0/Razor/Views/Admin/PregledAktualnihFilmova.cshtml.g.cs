#pragma checksum "C:\Users\User\source\repos\webapp\Kino\Views\Admin\PregledAktualnihFilmova.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8b9b7fb0aa2f473a0b8539dc2e1371d0b962779"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_PregledAktualnihFilmova), @"mvc.1.0.view", @"/Views/Admin/PregledAktualnihFilmova.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8b9b7fb0aa2f473a0b8539dc2e1371d0b962779", @"/Views/Admin/PregledAktualnihFilmova.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df205999c203b7c097cfb1dbb724ed6ac27f2c63", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_PregledAktualnihFilmova : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\User\source\repos\webapp\Kino\Views\Admin\PregledAktualnihFilmova.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8b9b7fb0aa2f473a0b8539dc2e1371d0b9627793293", async() => {
                WriteLiteral(@"
    <link href=""//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css"" rel=""stylesheet"" id=""bootstrap-css"">
    <script src=""//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js""></script>
    <script src=""//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js""></script>
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
<!------ Include the above in your HEAD tag ---------->
<style>
    .cta-100 {
        margin-top: 100px;
        padding-left: 8%;
        padding-top: 7%;
    }

    .col-md-4 {
        padding-bottom: 20px;
    }

    .white {
        color: #fff !important;
    }

    .mt {
        float: left;
        margin-top: -20px;
        padding-top: 20px;
    }

    .bg-blue-ui {
        background-color: #708198 !important;
    }

    figure img {
        width: 300px;
    }

    #blogCarousel {
        padding-bottom: 100px;
    }

    .blog .carousel-indicators {
        left: 0;
        top: -50px;
        height: 50%;
    }


        /* The colour of the indicators */

        .blog .carousel-indicators li {
            background: #708198;
            border-radius: 50%;
            width: 8px;
            height: 8px;
        }

        .blog .carousel-indicators .active {
            background: #0fc9af;
        }




    .item-carousel-blog-block");
            WriteLiteral(@" {
        outline: medium none;
        padding: 15px;
    }

    .item-box-blog {
        border: 1px solid #dadada;
        text-align: center;
        z-index: 4;
        padding: 20px;
    }

    .item-box-blog-image {
        position: relative;
    }

        .item-box-blog-image figure img {
            width: 100%;
            height: auto;
        }

    .item-box-blog-date {
        position: absolute;
        z-index: 5;
        padding: 4px 20px;
        top: -20px;
        right: 8px;
        background-color: #41cb52;
    }

        .item-box-blog-date span {
            color: #fff;
            display: block;
            text-align: center;
            line-height: 1.2;
        }

            .item-box-blog-date span.mon {
                font-size: 18px;
            }

            .item-box-blog-date span.day {
                font-size: 16px;
            }

    .item-box-blog-body {
        padding: 10px;
    }

    .item-heading-blog a h5 {");
            WriteLiteral(@"
        margin: 0;
        line-height: 1;
        text-decoration: none;
        transition: color 0.3s;
    }

    .item-box-blog-heading a {
        text-decoration: none;
    }

    .item-box-blog-data p {
        font-size: 13px;
    }

        .item-box-blog-data p i {
            font-size: 12px;
        }

    .item-box-blog-text {
        max-height: 100px;
        overflow: hidden;
    }

    .mt-10 {
        float: left;
        margin-top: -10px;
        padding-top: 10px;
    }

    .btn.bg-blue-ui.white.read {
        cursor: pointer;
        padding: 4px 20px;
        float: left;
        margin-top: 10px;
    }

        .btn.bg-blue-ui.white.read:hover {
            box-shadow: 0px 5px 15px inset #4d5f77;
        }
</style>


<div class=""container cta-100 "">
    <div class=""container"">
        <div class=""row blog"">
            <div class=""col-md-12"">
                <div id=""blogCarousel"" class=""carousel slide container-blog"" data-ride=""carousel""");
            WriteLiteral(@">
                    <ol class=""carousel-indicators"">
                        <li data-target=""#blogCarousel"" data-slide-to=""0"" class=""active""></li>
                        <li data-target=""#blogCarousel"" data-slide-to=""1""></li>
                    </ol>
                    <!-- Carousel items -->
                    
                    <div class=""carousel-inner"">
                        <div class=""carousel-item active"">
                            <div class=""row"">
                                <div class=""col-md-4"">
                                    <div class=""item-box-blog"">
                                        <div class=""item-box-blog-image"">
                                            <!--Date-->
                                            <div class=""item-box-blog-date bg-blue-ui white""> <span class=""mon"">Augu 01</span> </div>
                                            <!--Image-->
                                            <figure> <img");
            BeginWriteAttribute("alt", " alt=\"", 4403, "\"", 4409, 0);
            EndWriteAttribute();
            WriteLiteral(@" src=""https://cdn.pixabay.com/photo/2017/02/08/14/25/computer-2048983_960_720.jpg""> </figure>
                                        </div>
                                        <div class=""item-box-blog-body"">
                                            <!--Heading-->
                                            <div class=""item-box-blog-heading"">
                                                <a href=""#"" tabindex=""0"">
                                                    <h5>News Title</h5>
                                                </a>
                                            </div>
                                            <!--Data-->
                                            <div class=""item-box-blog-data"" style=""padding: px 15px;"">
                                                <p><i class=""fa fa-user-o""></i> Admin, <i class=""fa fa-comments-o""></i> Comments(3)</p>
                                            </div>
                                            <!--Text-->
     ");
            WriteLiteral(@"                                       <div class=""item-box-blog-text"">
                                                <p>Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor.</p>
                                            </div>
                                            <div class=""mt""> <a href=""#"" tabindex=""0"" class=""btn bg-blue-ui white read"">read more</a> </div>
                                            <!--Read More Button-->
                                        </div>
                                    </div>
                                </div>
                                <div class=""col-md-4"">
                                    <div class=""item-box-blog"">
                                        <div class=""item-box-blog-image"">
                                            <!--Date-->
  ");
            WriteLiteral("                                          <div class=\"item-box-blog-date bg-blue-ui white\"> <span class=\"mon\">Augu 01</span> </div>\r\n                                            <!--Image-->\r\n                                            <figure> <img");
            BeginWriteAttribute("alt", " alt=\"", 6706, "\"", 6712, 0);
            EndWriteAttribute();
            WriteLiteral(@" src=""https://cdn.pixabay.com/photo/2017/02/08/14/25/computer-2048983_960_720.jpg""> </figure>
                                        </div>
                                        <div class=""item-box-blog-body"">
                                            <!--Heading-->
                                            <div class=""item-box-blog-heading"">
                                                <a href=""#"" tabindex=""0"">
                                                    <h5>News Title</h5>
                                                </a>
                                            </div>
                                            <!--Data-->
                                            <div class=""item-box-blog-data"" style=""padding: px 15px;"">
                                                <p><i class=""fa fa-user-o""></i> Admin, <i class=""fa fa-comments-o""></i> Comments(3)</p>
                                            </div>
                                            <!--Text-->
     ");
            WriteLiteral(@"                                       <div class=""item-box-blog-text"">
                                                <p>Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor.</p>
                                            </div>
                                            <div class=""mt""> <a href=""#"" tabindex=""0"" class=""btn bg-blue-ui white read"">read more</a> </div>
                                            <!--Read More Button-->
                                        </div>
                                    </div>
                                </div>
                                <div class=""col-md-4"">
                                    <div class=""item-box-blog"">
                                        <div class=""item-box-blog-image"">
                                            <!--Date-->
  ");
            WriteLiteral("                                          <div class=\"item-box-blog-date bg-blue-ui white\"> <span class=\"mon\">Augu 01</span> </div>\r\n                                            <!--Image-->\r\n                                            <figure> <img");
            BeginWriteAttribute("alt", " alt=\"", 9009, "\"", 9015, 0);
            EndWriteAttribute();
            WriteLiteral(@" src=""https://cdn.pixabay.com/photo/2017/02/08/14/25/computer-2048983_960_720.jpg""> </figure>
                                        </div>
                                        <div class=""item-box-blog-body"">
                                            <!--Heading-->
                                            <div class=""item-box-blog-heading"">
                                                <a href=""#"" tabindex=""0"">
                                                    <h5>News Title</h5>
                                                </a>
                                            </div>
                                            <!--Data-->
                                            <div class=""item-box-blog-data"" style=""padding: px 15px;"">
                                                <p><i class=""fa fa-user-o""></i> Admin, <i class=""fa fa-comments-o""></i> Comments(3)</p>
                                            </div>
                                            <!--Text-->
     ");
            WriteLiteral(@"                                       <div class=""item-box-blog-text"">
                                                <p>Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor.</p>
                                            </div>
                                            <div class=""mt""> <a href=""#"" tabindex=""0"" class=""btn bg-blue-ui white read"">read more</a> </div>
                                            <!--Read More Button-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--.row-->
                        </div>
                        <!--.item-->
                        <div class=""carousel-item "">
                            <div class=""row"">
       ");
            WriteLiteral(@"                         <div class=""col-md-4"">
                                    <div class=""item-box-blog"">
                                        <div class=""item-box-blog-image"">
                                            <!--Date-->
                                            <div class=""item-box-blog-date bg-blue-ui white""> <span class=""mon"">Augu 01</span> </div>
                                            <!--Image-->
                                            <figure> <img");
            BeginWriteAttribute("alt", " alt=\"", 11560, "\"", 11566, 0);
            EndWriteAttribute();
            WriteLiteral(@" src=""https://cdn.pixabay.com/photo/2017/02/08/14/25/computer-2048983_960_720.jpg""> </figure>
                                        </div>
                                        <div class=""item-box-blog-body"">
                                            <!--Heading-->
                                            <div class=""item-box-blog-heading"">
                                                <a href=""#"" tabindex=""0"">
                                                    <h5>News Title</h5>
                                                </a>
                                            </div>
                                            <!--Data-->
                                            <div class=""item-box-blog-data"" style=""padding: px 15px;"">
                                                <p><i class=""fa fa-user-o""></i> Admin, <i class=""fa fa-comments-o""></i> Comments(3)</p>
                                            </div>
                                            <!--Text-->
     ");
            WriteLiteral(@"                                       <div class=""item-box-blog-text"">
                                                <p>Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor.</p>
                                            </div>
                                            <div class=""mt""> <a href=""#"" tabindex=""0"" class=""btn bg-blue-ui white read"">read more</a> </div>
                                            <!--Read More Button-->
                                        </div>
                                    </div>
                                </div>
                                <div class=""col-md-4"">
                                    <div class=""item-box-blog"">
                                        <div class=""item-box-blog-image"">
                                            <!--Date-->
  ");
            WriteLiteral("                                          <div class=\"item-box-blog-date bg-blue-ui white\"> <span class=\"mon\">Augu 01</span> </div>\r\n                                            <!--Image-->\r\n                                            <figure> <img");
            BeginWriteAttribute("alt", " alt=\"", 13863, "\"", 13869, 0);
            EndWriteAttribute();
            WriteLiteral(@" src=""https://cdn.pixabay.com/photo/2017/02/08/14/25/computer-2048983_960_720.jpg""> </figure>
                                        </div>
                                        <div class=""item-box-blog-body"">
                                            <!--Heading-->
                                            <div class=""item-box-blog-heading"">
                                                <a href=""#"" tabindex=""0"">
                                                    <h5>News Title</h5>
                                                </a>
                                            </div>
                                            <!--Data-->
                                            <div class=""item-box-blog-data"" style=""padding: px 15px;"">
                                                <p><i class=""fa fa-user-o""></i> Admin, <i class=""fa fa-comments-o""></i> Comments(3)</p>
                                            </div>
                                            <!--Text-->
     ");
            WriteLiteral(@"                                       <div class=""item-box-blog-text"">
                                                <p>Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor.</p>
                                            </div>
                                            <div class=""mt""> <a href=""#"" tabindex=""0"" class=""btn bg-blue-ui white read"">read more</a> </div>
                                            <!--Read More Button-->
                                        </div>
                                    </div>
                                </div>
                                <div class=""col-md-4"">
                                    <div class=""item-box-blog"">
                                        <div class=""item-box-blog-image"">
                                            <!--Date-->
  ");
            WriteLiteral("                                          <div class=\"item-box-blog-date bg-blue-ui white\"> <span class=\"mon\">Augu 01</span> </div>\r\n                                            <!--Image-->\r\n                                            <figure> <img");
            BeginWriteAttribute("alt", " alt=\"", 16166, "\"", 16172, 0);
            EndWriteAttribute();
            WriteLiteral(@" src=""https://cdn.pixabay.com/photo/2017/02/08/14/25/computer-2048983_960_720.jpg""> </figure>
                                        </div>
                                        <div class=""item-box-blog-body"">
                                            <!--Heading-->
                                            <div class=""item-box-blog-heading"">
                                                <a href=""#"" tabindex=""0"">
                                                    <h5>News Title</h5>
                                                </a>
                                            </div>
                                            <!--Data-->
                                            <div class=""item-box-blog-data"" style=""padding: px 15px;"">
                                                <p><i class=""fa fa-user-o""></i> Admin, <i class=""fa fa-comments-o""></i> Comments(3)</p>
                                            </div>
                                            <!--Text-->
     ");
            WriteLiteral(@"                                       <div class=""item-box-blog-text"">
                                                <p>Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, adipiscing. Lorem ipsum dolor sit amet, consectetuer adipiscing. Lorem ipsum dolor.</p>
                                            </div>
                                            <div class=""mt""> <a href=""#"" tabindex=""0"" class=""btn bg-blue-ui white read"">read more</a> </div>
                                            <!--Read More Button-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--.row-->
                        </div>
                        <!--.item-->
                    </div>
                    <!--.carousel-inner-->
                </div>
            ");
            WriteLiteral("    <!--.Carousel-->\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
