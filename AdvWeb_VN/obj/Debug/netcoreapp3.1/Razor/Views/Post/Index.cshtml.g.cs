#pragma checksum "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "322023d6c4010c9842209d9b7482af3056d2f0d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Index), @"mvc.1.0.view", @"/Views/Post/Index.cshtml")]
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
#nullable restore
#line 2 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
using AdvWeb_VN.Utilities.Settings;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"322023d6c4010c9842209d9b7482af3056d2f0d6", @"/Views/Post/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfaa8eea551f5eeb67718111ed694c75dff6453c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Post_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdvWeb_VN.WebApp.Models.PostPageViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
  
	ViewData["Title"] = Model.Post.PostName;
	Layout = "~/Views/Shared/_Layout.cshtml";
	var imageFolder = ViewData["BaseAddress"] + "/user-content/";
	Split split = new Split();
	ConvertTime convertTime = new ConvertTime();
	var defaultAvatar = imageFolder + "user-icon.jpg";
	string adminColor, avatar = "";
	UrlRewrite rewrite = new UrlRewrite();
	var postUrl = ViewData["PortalAddress"] + "/post/" + rewrite.Rewrite(Model.Post.PostName) + Model.Post.PostID;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Breadcrumb -->\r\n<div class=\"container\">\r\n\t<div class=\"bg0 flex-wr-sb-c p-rl-20 p-tb-8\">\r\n\t\t<div class=\"f2-s-1 p-r-30 m-tb-6\">\r\n");
            WriteLiteral(@"		</div>

		<div class=""pos-relative size-a-2 bo-1-rad-22 of-hidden bocl11 m-tb-6"">
			<input id=""search"" class=""f1-s-1 cl6 plh9 s-full p-l-25 p-r-45"" type=""text"" name=""search"" placeholder=""Search"">
			<button id=""search"" class=""flex-c-c size-a-1 ab-t-r fs-20 cl2 hov-cl10 trans-03"">
				<i class=""zmdi zmdi-search""></i>
			</button>
		</div>
	</div>
</div>

<!-- Content -->
<section class=""bg0 p-b-140 p-t-10"">
	<div class=""container"">
		<div class=""row justify-content-center"">
			<div class=""col-md-10 col-lg-8 p-b-30"">
				<div class=""p-r-10 p-r-0-sr991"">
					<!-- Blog Detail -->
					<div class=""p-b-70"">
						<a");
            BeginWriteAttribute("href", " href=\"", 1508, "\"", 1565, 2);
            WriteAttributeValue("", 1515, "/subcategory/subcategory-", 1515, 25, true);
#nullable restore
#line 45 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
WriteAttributeValue("", 1540, Model.Post.SubCategoryID, 1540, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"f1-s-10 cl2 hov-cl10 trans-03 text-uppercase\">\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 46 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                       Write(Model.Post.SubCategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</a>\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n\t\t\t\t\t\t<div style=\"text-align:center\" class=\"wrap-pic-max-w p-t-30\">\r\n\t\t\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=\"", 2361, "\"", 2405, 1);
#nullable restore
#line 68 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
WriteAttributeValue("", 2367, imageFolder + @Model.Post.Thumbnail, 2367, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"IMG\">\r\n\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t<h3 class=\"f1-l-3 cl2 p-b-5 p-t-33 respon2\">\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 72 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                       Write(Model.Post.PostName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</h3>\r\n\r\n\t\t\t\t\t\t<div class=\"flex-wr-s-s p-b-20\">\r\n\t\t\t\t\t\t\t<span class=\"f1-s-3 cl8 m-r-15\">\r\n\t\t\t\t\t\t\t\t<a href=\"#\" class=\"f1-s-4 cl8 hov-cl10 trans-03\">\r\n\t\t\t\t\t\t\t\t\tby ");
#nullable restore
#line 78 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                  Write(Model.Post.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t</a>\r\n\r\n\t\t\t\t\t\t\t\t<span class=\"m-rl-3\">-</span>\r\n\r\n\t\t\t\t\t\t\t\t<span>\r\n\t\t\t\t\t\t\t\t\t");
#nullable restore
#line 84 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                Write(Model.Post.WriteTime.Day + "/" + Model.Post.WriteTime.Month + "/" + Model.Post.WriteTime.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t</span>\r\n\t\t\t\t\t\t\t</span>\r\n\r\n\t\t\t\t\t\t\t<span class=\"f1-s-3 cl8 m-r-15\">\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 89 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                           Write(Model.Post.View);

#line default
#line hidden
#nullable disable
            WriteLiteral(" lượt xem\r\n\t\t\t\t\t\t\t</span>\r\n\r\n\t\t\t\t\t\t\t<a href=\"#\" class=\"f1-s-3 cl8 hov-cl10 trans-03 m-r-15\">\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 93 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                           Write(Model.Comments.TotalRecords);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Bình luận\r\n\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t</div>\r\n\r\n\r\n\r\n\t\t\t\t\t\t<!-- Post Content-->\r\n\t\t\t\t\t\t");
#nullable restore
#line 100 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                   Write(Html.Raw(Model.Post.Contents));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\t\t\t\t\t\t<!-- Tag -->\r\n\t\t\t\t\t\t<div class=\"flex-s-s p-t-12 p-b-15\">\r\n\t\t\t\t\t\t\t<span class=\"f1-s-12 cl5 m-r-8\">\r\n\t\t\t\t\t\t\t\tTags:\r\n\t\t\t\t\t\t\t</span>\r\n\r\n\t\t\t\t\t\t\t<div class=\"flex-wr-s-s size-w-0\">\r\n");
#nullable restore
#line 109 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                 foreach (var tag in Model.Post.Tags)
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 3478, "\"", 3494, 2);
            WriteAttributeValue("", 3485, "/tag/", 3485, 5, true);
#nullable restore
#line 111 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
WriteAttributeValue("", 3490, tag, 3490, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"f1-s-12 cl8 hov-link1 m-r-15\">\r\n\t\t\t\t\t\t\t\t\t\t");
#nullable restore
#line 112 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                   Write(tag);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</a>\r\n");
#nullable restore
#line 114 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
								}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"							</div>
						</div>

						<!-- Share -->
						<div class=""flex-s-s"">
							<span class=""f1-s-12 cl5 p-t-1 m-r-15 p-b-15"">
								Share:
							</span>

							<div class=""flex-wr-s-s size-w-0"">
								<button id=""fbShare"" class=""dis-block f1-s-13 cl0 bg-facebook borad-3 p-tb-4 p-rl-18 hov-btn1 m-r-3 m-b-3 trans-03"">
									<i class=""fab fa-facebook-f m-r-7""></i>
									Facebook
								</button>

								<button id=""twitterShare"" class=""dis-block f1-s-13 cl0 bg-twitter borad-3 p-tb-4 p-rl-18 hov-btn1 m-r-3 m-b-3 trans-03"">
									<i class=""fab fa-twitter m-r-7""></i>
									Twitter
								</button>

								<button id=""gplusShare"" class=""dis-block f1-s-13 cl0 bg-google borad-3 p-tb-4 p-rl-18 hov-btn1 m-r-3 m-b-3 trans-03"">
									<i class=""fab fa-google-plus-g m-r-7""></i>
									Google+
								</button>
							</div>
						</div>

						<!-- Switch View -->
");
            WriteLiteral("\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\r\n\r\n\t\t\t<!-- Sidebar -->\r\n\t\t\t");
#nullable restore
#line 159 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
       Write(await Component.InvokeAsync("Sidebar"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

			<!-- Show Comment -->
			<div class=""col-12 col-md-10 col-lg-12"">
				<h4 class=""f1-l-4 cl3 p-b-12"">
					Bình Luận
				</h4>
			</div>

			<div class=""col-12 col-md-10 col-lg-12 p-b-100"">
				<div class=""comments"">
					<div class=""comments-details"">
						<span class=""total-comments comments-sort"">");
#nullable restore
#line 171 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                              Write(Model.Comments.TotalRecords);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Bình luận</span>\r\n");
            WriteLiteral("\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t<!-- Form Add Comment đầu -->\r\n");
            WriteLiteral("\t\t\t\t\t<!-- List Comment Hiện ở đây -->\r\n");
#nullable restore
#line 199 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                     foreach (var comment in Model.Comments.Items)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div data-id=\"");
#nullable restore
#line 201 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                 Write(comment.CommentID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"comment-box main-comment\">\r\n\t\t\t\t\t\t\t<span class=\"commenter-pic\">\r\n");
#nullable restore
#line 203 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                 if (comment.Avatar != null) { avatar = imageFolder + comment.Avatar; } else { avatar = defaultAvatar; }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=", 7347, "", 7359, 1);
#nullable restore
#line 204 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
WriteAttributeValue("", 7352, avatar, 7352, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid img-avatar-comment\">\r\n\t\t\t\t\t\t\t</span>\r\n");
#nullable restore
#line 206 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                             if (comment.IsManaged) { adminColor = "style=color:red"; } else { adminColor = ""; }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<span class=\"commenter-name\">\r\n\t\t\t\t\t\t\t\t<a ");
#nullable restore
#line 208 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                              Write(adminColor);

#line default
#line hidden
#nullable disable
            WriteLiteral(" href=\"#\">");
#nullable restore
#line 208 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                   Write(comment.Commentator);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> <span class=\"comment-time\">");
#nullable restore
#line 208 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                                                       Write(convertTime.Convert(comment.CommentTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t\t\t</span>\r\n\t\t\t\t\t\t\t<p class=\"comment-txt more\">");
#nullable restore
#line 210 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                   Write(comment.Commenter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t<div class=\"comment-meta\">\r\n\t\t\t\t\t\t\t\t<button class=\"comment-like\"><i class=\"fa fa-thumbs-o-up\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 212 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                                                             Write(comment.LikeCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n\t\t\t\t\t\t\t\t<button class=\"comment-dislike\"><i class=\"fa fa-thumbs-o-down\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 213 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                                                                  Write(comment.DislikeCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n\t\t\t\t\t\t\t\t<button");
            BeginWriteAttribute("parent-id", " parent-id=\"", 8052, "\"", 8082, 1);
#nullable restore
#line 214 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
WriteAttributeValue("", 8064, comment.CommentID, 8064, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 214 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                           Write(comment.CommentID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"comment-reply reply-popup\"><i class=\"fa fa-reply-all\" aria-hidden=\"true\"></i> Reply</button>\r\n\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 216 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                             foreach (var subComment in comment.SubComments)
							{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t<div data-id=\"");
#nullable restore
#line 218 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                         Write(subComment.SubCommentID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"comment-box replied\">\r\n\t\t\t\t\t\t\t\t\t<span class=\"commenter-pic\">\r\n");
#nullable restore
#line 220 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                         if (subComment.Avatar != null) { avatar = imageFolder + subComment.Avatar; } else { avatar = defaultAvatar; }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=", 8549, "", 8561, 1);
#nullable restore
#line 221 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
WriteAttributeValue("", 8554, avatar, 8554, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid img-avatar-comment\">\r\n\t\t\t\t\t\t\t\t\t</span>\r\n");
#nullable restore
#line 223 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                     if (subComment.IsManaged) { adminColor = "style=color:red"; } else { adminColor = ""; }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<span class=\"commenter-name\">\r\n\t\t\t\t\t\t\t\t\t\t<a ");
#nullable restore
#line 225 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                      Write(adminColor);

#line default
#line hidden
#nullable disable
            WriteLiteral(" href=\"#\">");
#nullable restore
#line 225 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                           Write(subComment.Commentator);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> <span class=\"comment-time\">");
#nullable restore
#line 225 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                                                                  Write(convertTime.Convert(subComment.CommentTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t\t\t\t\t</span>\r\n\t\t\t\t\t\t\t\t\t<p class=\"comment-txt more\">");
#nullable restore
#line 227 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                           Write(subComment.Commenter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t\t\t<div class=\"comment-meta\">\r\n\t\t\t\t\t\t\t\t\t\t<button class=\"comment-like\"><i class=\"fa fa-thumbs-o-up\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 229 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                                                                     Write(subComment.LikeCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n\t\t\t\t\t\t\t\t\t\t<button class=\"comment-dislike\"><i class=\"fa fa-thumbs-o-down\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 230 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                                                                          Write(subComment.DislikeCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n\t\t\t\t\t\t\t\t\t\t<button");
            BeginWriteAttribute("parent-id", " parent-id=\"", 9292, "\"", 9322, 1);
#nullable restore
#line 231 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
WriteAttributeValue("", 9304, comment.CommentID, 9304, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 231 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                                   Write(subComment.SubCommentID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"comment-reply reply-popup\"><i class=\"fa fa-reply-all\" aria-hidden=\"true\"></i> Reply</button>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 234 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
							}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 236 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>\r\n\r\n\t\t\t<!-- Pagination -->\r\n\t\t\t");
#nullable restore
#line 241 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
       Write(await Component.InvokeAsync("Pager", Model.Comments));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\t\t</div>\r\n\t</div>\r\n</section>\r\n\r\n");
            DefineSection("style", async() => {
                WriteLiteral(@"
	<style>
		.contents {
			font-size: 18px;
		}

			.contents h1 {
				display: block;
				font-size: 2em;
				margin-top: 0.67em;
				margin-bottom: 0.67em;
				margin-left: 0;
				margin-right: 0;
				font-weight: bold;
			}

			.contents h2 {
				display: block;
				font-size: 1.5em;
				margin-top: 0.83em;
				margin-bottom: 0.83em;
				margin-left: 0;
				margin-right: 0;
				font-weight: bold;
			}

			.contents h3 {
				display: block;
				font-size: 1.17em;
				margin-top: 1em;
				margin-bottom: 1em;
				margin-left: 0;
				margin-right: 0;
				font-weight: bold;
			}

			.contents h4 {
				display: block;
				font-size: 1em;
				margin-top: 1.33em;
				margin-bottom: 1.33em;
				margin-left: 0;
				margin-right: 0;
				font-weight: bold;
			}

			.contents h5 {
				display: block;
				font-size: .83em;
				margin-top: 1.67em;
				margin-bottom: 1.67em;
				margin-left: 0;
				margin-right: 0;
				font-weight: bold;
			}

			.contents h6 {
				");
                WriteLiteral("display: block;\r\n\t\t\t\tfont-size: .67em;\r\n\t\t\t\tmargin-top: 2.33em;\r\n\t\t\t\tmargin-bottom: 2.33em;\r\n\t\t\t\tmargin-left: 0;\r\n\t\t\t\tmargin-right: 0;\r\n\t\t\t\tfont-weight: bold;\r\n\t\t\t}\r\n\t</style>\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
	<script type=""text/javascript"">
		var isReply = false;
		var fbShare = document.getElementById(""fbShare"");
		var gplusShare = document.getElementById(""gplusShare"");
		var twitterShare = document.getElementById(""twitterShare"");

		var form  = document.getElementById('commentForm');
		var error = document.querySelector('.error');
		var commentator = document.getElementById('Commentator');
		var commentator = document.getElementById('Commenter');


		$(document).ready(function () {
			$(""img"").css(""max-width"", ""100%"");
			$(""video"").css(""max-width"", ""100%"");
			$(""iframe"").css(""max-width"", ""100%"");

			//Khi nhấn vào reply thì bật khung Reply lên
			$("".comment-reply"").click(function () {
				isReply = true;
				$("".reply"").remove();
				var dataID = $(this).attr(""data-id"");
				var parentID = $(this).attr(""parent-id"");
				var box = $(""div[data-id='"" + dataID + ""']"");
				box.append('<form class=""reply"" action=""/post/CreateComment"" role=""form"" method=""post""><div class=""comment-box add");
                WriteLiteral(@"-comment reply""><span class=""commenter-pic""><img src=""/images/user-icon.jpg"" class=""img-fluid img-avatar-comment""></span><span class=""commenter-name""><input oninput=""this.setCustomValidity(\'\')"" oninvalid=""this.setCustomValidity(\'Tên bắt buộc phải có, dài tối đa 50 kí tự!\')"" maxlength=""50""  id=""commentator"" type=""text"" placeholder=""Tên"" name=""commentator"" required><input value=""");
#nullable restore
#line 341 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             Write(ViewData["PostID"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" id=\"PostID\" type=\"hidden\" placeholder=\"ID\" name=\"PostID\"><input value=\"");
#nullable restore
#line 341 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         Write(Model.Post.PostName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""" id=""PostName"" type=""hidden"" placeholder=""Name"" name=""PostName""><input value=""' + parentID + '"" id=""ParentID"" type=""hidden"" placeholder=""ID"" name=""ParentID""></span><textarea oninput=""this.setCustomValidity(\'\')"" oninvalid=""this.setCustomValidity(\'Bình luận bắt buộc phải có, dài tối đa 250 kí tự!\')"" maxlength=""250""  id=""commenter"" class=""bo-1-rad-3 bocl13 size-a-15 f1-s-13 cl5 plh6 p-rl-18 p-tb-14 m-b-20"" type=""text"" placeholder=""Vui lòng nhập bình luận"" name=""commenter"" required></textarea><button type=""submit"" class=""btn btn-default"">Reply</button><button type=""cancel"" class=""btn btn-default reply-popup-cancel"">Cancel</button></form>');
					$("".reply-popup-cancel"").click(function () {
					$("".reply"").remove();
				});
			});

			//Nhấn Cancel thì xóa khung reply đi
			$("".reply-popup-cancel"").click(function () {
				$("".reply"").remove();
			});

			//Ấn vào Comment bự thì ẩn Comment nhỏ đi
			$("".main-comment"").click(function () {
				if (!isReply) {
					var x = $(this).children("".commen");
                WriteLiteral(@"t-box"");
					for (let i = 0; i < x.length; i++) {
						if (x[i].style.display === ""none"") {
							x[i].style.display = ""block"";
						} else {
							x[i].style.display = ""none"";
						}
					}
				}
			});

			fbShare.onclick = function () {
				window.open(""https://www.facebook.com/sharer.php?u=");
#nullable restore
#line 367 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                              Write(postUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral("\", \"\", \"height=368,width=600,left=100,top=100,menubar=0\");\r\n\t\t\t\treturn false;\r\n\t\t\t}\r\n\r\n\t\t\tgplusShare.onclick = function () {\r\n\t\t\t\twindow.open(\"https://plus.google.com/share?url=");
#nullable restore
#line 372 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                          Write(postUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral("\", \"\", \"height=550,width=525,left=100,top=100,menubar=0\");\r\n\t\t\t\treturn false;\r\n\t\t\t}\r\n\r\n\t\t\ttwitterShare.onclick = function () {\r\n\t\t\t\twindow.open(\"https://twitter.com/share?url=");
#nullable restore
#line 377 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                      Write(postUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + \"&text=");
#nullable restore
#line 377 "D:\Project\Website\test\SciADV-VN\AdvWeb_VN\Views\Post\Index.cshtml"
                                                                         Write(Model.Post.PostName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""", """", ""height=260,width=500,left=100,top=100,menubar=0"");
				return false;
			}

			form.addEventListener(""submit"", function (event) {
				// kiểm tra khi user click submit.
				if (!commentator.validity.valid||!commenter.validity.valid) {
					alert(""Tên hoặc bình luận không hợp lệ!"");
					// chặn việc submit form
					event.preventDefault();
				}
			}, false);


");
                WriteLiteral("\r\n\t\t});\r\n\t</script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdvWeb_VN.WebApp.Models.PostPageViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
