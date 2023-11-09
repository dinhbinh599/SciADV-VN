#pragma checksum "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "478fda92c5e91adf3fd4a5c8b6c01a901b510377"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Pager_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Pager/Default.cshtml")]
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
#line 1 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\_ViewImports.cshtml"
using AdvWeb_VN.ManageApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\_ViewImports.cshtml"
using AdvWeb_VN.ManageApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"478fda92c5e91adf3fd4a5c8b6c01a901b510377", @"/Views/Shared/Components/Pager/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3f6baa6e67c4f478d7f7473d85d03c023841e64", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_Pager_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdvWeb_VN.ViewModels.Common.PagedResultBase>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
  
    var urlTemplate = Url.Action() + "?pageIndex={0}";
    var request = ViewContext.HttpContext.Request;
    foreach (var key in request.Query.Keys)
    {
        if (key == "pageIndex")
        {
            continue;
        }
        if (request.Query[key].Count > 1)
        {
            foreach (var item in (string[])request.Query[key])
            {
                urlTemplate += "&" + key + "=" + item;
            }
        }
        else
        {
            urlTemplate += "&" + key + "=" + request.Query[key];
        }
    }

    var startIndex = Math.Max(Model.PageIndex - 5, 1);
    var finishIndex = Math.Min(Model.PageIndex + 5, Model.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 28 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
 if (Model.PageCount > 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul class=\"pagination\">\r\n");
#nullable restore
#line 31 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
         if (Model.PageIndex != startIndex)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">\r\n                <a class=\"page-link\" title=\"1\"");
            BeginWriteAttribute("href", " href=\"", 949, "\"", 988, 1);
#nullable restore
#line 34 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 956, urlTemplate.Replace("{0}", "1"), 956, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Đầu</a>\r\n            </li>\r\n            <li class=\"page-item\">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1090, "\"", 1156, 1);
#nullable restore
#line 37 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1097, urlTemplate.Replace("{0}", (Model.PageIndex-1).ToString()), 1097, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Trước</a>\r\n            </li>\r\n");
#nullable restore
#line 39 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
         for (var i = startIndex; i <= finishIndex; i++)
        {
            if (i == Model.PageIndex)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item active\">\r\n                    <a class=\"page-link\" href=\"#\">");
#nullable restore
#line 45 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
                                             Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"sr-only\">(current)</span></a>\r\n                </li>\r\n");
#nullable restore
#line 47 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("title", " title=\"", 1595, "\"", 1622, 2);
            WriteAttributeValue("", 1603, "Trang", 1603, 5, true);
#nullable restore
#line 50 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue(" ", 1608, i.ToString(), 1609, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1623, "\"", 1671, 1);
#nullable restore
#line 50 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1630, urlTemplate.Replace("{0}", i.ToString()), 1630, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 50 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
                                                                                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 51 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
         if (Model.PageIndex != finishIndex)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("title", " title=\"", 1841, "\"", 1876, 1);
#nullable restore
#line 56 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1849, Model.PageCount.ToString(), 1849, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1877, "\"", 1943, 1);
#nullable restore
#line 56 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1884, urlTemplate.Replace("{0}", (Model.PageIndex+1).ToString()), 1884, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sau</a>\r\n            </li>\r\n            <li class=\"page-item\">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2045, "\"", 2107, 1);
#nullable restore
#line 59 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 2052, urlTemplate.Replace("{0}", Model.PageCount.ToString()), 2052, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Cuối</a>\r\n            </li>\r\n");
#nullable restore
#line 61 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n");
#nullable restore
#line 63 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Shared\Components\Pager\Default.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdvWeb_VN.ViewModels.Common.PagedResultBase> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
