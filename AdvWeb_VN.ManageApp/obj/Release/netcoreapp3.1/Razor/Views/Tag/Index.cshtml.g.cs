#pragma checksum "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e11c1ad77ed5e5cfa481fd3fb689cf98c048e23a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tag_Index), @"mvc.1.0.view", @"/Views/Tag/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
using AdvWeb_VN.ViewModels.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e11c1ad77ed5e5cfa481fd3fb689cf98c048e23a", @"/Views/Tag/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3f6baa6e67c4f478d7f7473d85d03c023841e64", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Tag_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedResult<AdvWeb_VN.ViewModels.Catalog.Tags.TagViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tag", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "10", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "25", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "50", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "100", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
  
    ViewData["Title"] = "Danh sách";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
  
    var pageNow = (Model.PageIndex - 1) * Model.PageSize + 1;
    var pageLast = pageNow + Model.PageSize - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Content Wrapper. Contains page content -->
<div class=""content-wrapper"" style=""min-height: 1200.88px;"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1>Danh sách Tag</h1>
                </div>
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item""><a href=""/Home"">Home</a></li>
                        <li class=""breadcrumb-item active"">Danh sách Tag</li>
                    </ol>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>
    <!-- Main content -->
    <section class=""content"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">

                        <!-- Tên nằm trên đầu bảng");
            WriteLiteral(" -->\r\n                        <div class=\"card-header\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e11c1ad77ed5e5cfa481fd3fb689cf98c048e23a8243", async() => {
                WriteLiteral("Tạo mới");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <!-- /.card-header -->
                        <div class=""card-body"">
                            <div id=""example1_wrapper"" class=""dataTables_wrapper dt-bootstrap4"">
                                <div class=""row"">
                                    <div class=""col-sm-12 col-md-6"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e11c1ad77ed5e5cfa481fd3fb689cf98c048e23a10085", async() => {
                WriteLiteral(@"
                                            <div class=""dataTables_length"" id=""example1_length"">
                                                <label>
                                                    Show entries
                                                    <select name=""pageSize"" aria-controls=""example1""
                                                            class=""custom-select custom-select-sm form-control form-control-sm"">
                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e11c1ad77ed5e5cfa481fd3fb689cf98c048e23a10862", async() => {
                    WriteLiteral("10");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e11c1ad77ed5e5cfa481fd3fb689cf98c048e23a12138", async() => {
                    WriteLiteral("25");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e11c1ad77ed5e5cfa481fd3fb689cf98c048e23a13414", async() => {
                    WriteLiteral("50");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e11c1ad77ed5e5cfa481fd3fb689cf98c048e23a14690", async() => {
                    WriteLiteral("100");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                                    </select>
                                                </label>
                                                <button type=""submit"" class=""btn btn-outline-primary"">Select</button>
                                            </div>
                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </div>
                                    <div class=""col-sm-12 col-md-6"" "">
                                        <form asp-action=""Index"" method=""get"">
                                            <div id=""example1_filter"" class=""dataTables_filter"">
                                                <label>
                                                    Search:<input name=""keyword"" value=""");
#nullable restore
#line 67 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                                                   Write(ViewBag.Keyword);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" type=""search"" class=""form-control form-control-sm"" placeholder=""""
                                                                  aria-controls=""example1"">
                                                </label>
                                                <button type=""submit"" class=""btn btn-outline-primary"">Search</button>
                                                <button type=""button"" onclick=""window.location.href='/Tag/Index'"" class=""btn btn-outline-dark"">Reset</button>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                                <div class=""row"" style=""margin-top:20px"">
                                    <div class=""col-sm-12"">
                                        <table id=""example1""
                                               class=""table table-bordered  table-striped dataTable dtr-inline table-hover"" role=""grid""
      ");
            WriteLiteral(@"                                         aria-describedby=""example1_info"">
                                            <thead>
                                                <tr role=""row"">
                                                    <th class=""sorting_asc"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1""
                                                        aria-sort=""ascending"" aria-label=""Rendering engine: activate to sort column descending"">
                                                        ID
                                                    </th>
                                                    <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1""
                                                        aria-label=""Browser: activate to sort column ascending"">Tên Tag</th>
                                                    <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1""
                              ");
            WriteLiteral(@"                          aria-label=""Platform(s): activate to sort column ascending"">Số Bài Viết</th>
                                                    <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1""
                                                        aria-label=""CSS grade: activate to sort column ascending""></th>
                                                </tr>
                                            </thead>
                                            <tbody>
");
#nullable restore
#line 96 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                 foreach (var item in Model.Items)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr role=\"row\" class=\"odd\">\r\n                                                        <td tabindex=\"0\" class=\"sorting_1\">\r\n                                                            ");
#nullable restore
#line 100 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                       Write(Html.DisplayFor(modelItem => item.TagID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 103 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                       Write(Html.DisplayFor(modelItem => item.TagName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 106 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                       Write(Html.DisplayFor(modelItem => item.PostCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 109 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                       Write(Html.ActionLink("Sửa", "Edit", new { id = item.TagID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                                            ");
#nullable restore
#line 110 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                       Write(Html.ActionLink("Xem", "Details", new { id = item.TagID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                                            ");
#nullable restore
#line 111 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                       Write(Html.ActionLink("Xóa", "Delete", new { id = item.TagID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                    </tr>\r\n");
#nullable restore
#line 114 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <th rowspan=""1"" colspan=""1"">ID</th>
                                                    <th rowspan=""1"" colspan=""1"">Tên Tag</th>
                                                    <th rowspan=""1"" colspan=""1"">Số Bài Viết</th>
                                                    <th rowspan=""1"" colspan=""1""></th>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-sm-12 col-md-5"">
                                        <div class=""dataTables_info"" id=""example1_info"" role=""status"" aria-live=""polite"">
        ");
            WriteLiteral("                                    Showing ");
#nullable restore
#line 130 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                               Write(pageNow);

#line default
#line hidden
#nullable disable
            WriteLiteral(" to ");
#nullable restore
#line 130 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                                           Write(pageLast);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            of ");
#nullable restore
#line 131 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                                          Write(Model.TotalRecords);

#line default
#line hidden
#nullable disable
            WriteLiteral(" entries\r\n                                        </div>\r\n                                    </div>\r\n                                    ");
#nullable restore
#line 134 "D:\Project\Website\SciAdvWeb\AdvWeb_VN.ManageApp\Views\Tag\Index.cshtml"
                               Write(await Component.InvokeAsync("Pager", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </section>
    <!-- /.content -->
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedResult<AdvWeb_VN.ViewModels.Catalog.Tags.TagViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
