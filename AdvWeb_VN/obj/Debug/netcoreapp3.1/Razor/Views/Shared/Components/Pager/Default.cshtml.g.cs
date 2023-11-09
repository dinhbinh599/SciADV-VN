#pragma checksum "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23933b09a2e31ef97792a740e55f69d37840c485"
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
#line 1 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\_ViewImports.cshtml"
using AdvWeb_VN;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\_ViewImports.cshtml"
using AdvWeb_VN.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23933b09a2e31ef97792a740e55f69d37840c485", @"/Views/Shared/Components/Pager/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfaa8eea551f5eeb67718111ed694c75dff6453c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_Pager_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdvWeb_VN.ViewModels.Common.PagedResultBase>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
  
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
#line 28 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
 if (Model.PageCount > 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"flex-wr-c-c m-rl--7 p-t-28\">\r\n");
#nullable restore
#line 31 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
         if (Model.PageIndex != startIndex)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a class=\"flex-c-c pagi-item hov-btn1 trans-03 m-all-7\" title=\"1\"");
            BeginWriteAttribute("href", " href=\"", 961, "\"", 1000, 1);
#nullable restore
#line 33 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 968, urlTemplate.Replace("{0}", "1"), 968, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Đầu</a>\r\n            <a class=\"flex-c-c pagi-item hov-btn1 trans-03 m-all-7\"");
            BeginWriteAttribute("href", " href=\"", 1078, "\"", 1144, 1);
#nullable restore
#line 34 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1085, urlTemplate.Replace("{0}", (Model.PageIndex-1).ToString()), 1085, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Trước</a>\r\n");
#nullable restore
#line 35 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
         for (var i = startIndex; i <= finishIndex; i++)
        {
            if (i == Model.PageIndex)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"flex-c-c pagi-item hov-btn1 trans-03 m-all-7 pagi-active\" href=\"#\">");
#nullable restore
#line 40 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
                                                                                        Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"sr-only\">(current)</span></a>\r\n");
#nullable restore
#line 41 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"flex-c-c pagi-item hov-btn1 trans-03 m-all-7\"");
            BeginWriteAttribute("title", " title=\"", 1550, "\"", 1577, 2);
            WriteAttributeValue("", 1558, "Trang", 1558, 5, true);
#nullable restore
#line 44 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue(" ", 1563, i.ToString(), 1564, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1578, "\"", 1626, 1);
#nullable restore
#line 44 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1585, urlTemplate.Replace("{0}", i.ToString()), 1585, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 44 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
                                                                                                                                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 45 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
         if (Model.PageIndex != finishIndex)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a class=\"flex-c-c pagi-item hov-btn1 trans-03 m-all-7\"");
            BeginWriteAttribute("title", " title=\"", 1786, "\"", 1821, 1);
#nullable restore
#line 49 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1794, Model.PageCount.ToString(), 1794, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1822, "\"", 1888, 1);
#nullable restore
#line 49 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1829, urlTemplate.Replace("{0}", (Model.PageIndex+1).ToString()), 1829, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sau</a>\r\n            <a class=\"flex-c-c pagi-item hov-btn1 trans-03 m-all-7\"");
            BeginWriteAttribute("href", " href=\"", 1966, "\"", 2028, 1);
#nullable restore
#line 50 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1973, urlTemplate.Replace("{0}", Model.PageCount.ToString()), 1973, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Cuối</a>\r\n");
#nullable restore
#line 51 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 53 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Shared\Components\Pager\Default.cshtml"
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
