#pragma checksum "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc6f605b6d56a9e0b0d4326aba7e90816d25502f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_News_Default), @"mvc.1.0.view", @"/Views/Shared/Components/News/Default.cshtml")]
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
#line 1 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\_ViewImports.cshtml"
using WebSaleHfFood;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\_ViewImports.cshtml"
using WebSaleHfFood.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6f605b6d56a9e0b0d4326aba7e90816d25502f", @"/Views/Shared/Components/News/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cca5b83291a6d3a2d586608afc8a080659253be", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_News_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebSaleHfFood.ViewModels.NewsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-12\">\r\n            <div class=\"section-title from-blog__title\">\r\n                <h2>Bài viết</h2>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 11 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
         foreach (var item in @Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-4 col-md-4 col-sm-6\">\r\n                <div class=\"blog__item\">\r\n                    <div class=\"blog__item__pic\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 530, "\"", 567, 1);
#nullable restore
#line 16 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
WriteAttributeValue("", 536, Url.Content(item.ImgUrlMaster), 536, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 568, "\"", 574, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </div>\r\n                    <div class=\"blog__item__text\">\r\n                        <ul>\r\n                            <li><i class=\"fa fa-calendar-o\"></i> ");
#nullable restore
#line 20 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
                                                            Write(Html.DisplayFor(mo => item.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><i class=\"fa fa-comment-o\"></i> 5</li>\r\n                        </ul>\r\n                        <h5><a href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 942, "\"", 1031, 12);
            WriteAttributeValue("", 952, "addNewsRecent(\'", 952, 15, true);
#nullable restore
#line 23 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
WriteAttributeValue("", 967, item.Id, 967, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 975, "\',", 975, 2, true);
            WriteAttributeValue(" ", 977, "\'", 978, 2, true);
#nullable restore
#line 23 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
WriteAttributeValue("", 979, item.Title, 979, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 990, "\',", 990, 2, true);
            WriteAttributeValue(" ", 992, "\'", 993, 2, true);
#nullable restore
#line 23 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
WriteAttributeValue("", 994, DateTime.Now, 994, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1007, "\',", 1007, 2, true);
            WriteAttributeValue(" ", 1009, "\'", 1010, 2, true);
#nullable restore
#line 23 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
WriteAttributeValue("", 1011, item.ImgUrlMaster, 1011, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1029, "\')", 1029, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
                                                                                                                             Write(Html.DisplayFor(mo => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\r\n                        ");
#nullable restore
#line 24 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
                   Write(Html.Raw(item.SortContent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 28 "E:\16.HfMartVn\Hfmart\WebSaleHfFood\Views\Shared\Components\News\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebSaleHfFood.ViewModels.NewsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
