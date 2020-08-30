using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdvWeb_VN.ManageApp.Models;
using AdvWeb_VN.ManageApp.Services;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.ManageApp.Controllers
{
	public class PostController : BaseController
	{
		private readonly IPostApiClient _postApiClient;
		private readonly IConfiguration _configuration;
		private readonly ISubCategoryApiClient _subCategegoryApiClient;
		private readonly ICategoryApiClient _categegoryApiClient;
		private readonly ITagApiClient _tagApiClient;

		public PostController(IPostApiClient postApiClient, IConfiguration configuration, ISubCategoryApiClient subCategegoryApiClient, ICategoryApiClient categegoryApiClient, ITagApiClient tagApiClient)
		{
			_postApiClient = postApiClient;
			_configuration = configuration;
			_subCategegoryApiClient = subCategegoryApiClient;
			_categegoryApiClient = categegoryApiClient;
			_tagApiClient = tagApiClient;
		}

		public async Task<IActionResult> Index(string keyword, int id = 1, int pageIndex = 1, int pageSize = 10)
		{
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			ViewData["ID"] = id;
			var request = new GetManagePostPagingRequest()
			{
				ID = id,
				Keyword = keyword,
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var data = await _postApiClient.GetPostsPagings(request);
			ViewBag.Keyword = keyword;
			if (TempData["result"] != null)
			{
				ViewBag.SuccessMsg = TempData["result"];
			}
			return View(data.ResultObj);
		}

		// GET: /<controller>/
		

		[HttpGet]
		public async Task<IActionResult> Details(string id)
		{
			var result = await _postApiClient.GetByID(id);
			return View(result.ResultObj);
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			var userID = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
			
			var postCreateRequest = new PostCreateRequest()
			{
				UserID = userID			
			};
			return View(postCreateRequest);
		}

		[HttpPost]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Create([FromForm]PostCreateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var oldContents = request.Contents;
			request.Contents = "oldContents";
			var result = await _postApiClient.CreatePost(request);
			if (result.IsSuccessed)
			{
				var postID = result.ResultObj.PostID;
				await _postApiClient.UpdateContents(postID, new PostUpdateContentsRequest
				{
					id = result.ResultObj.PostID,
					Contents = await ConvertImage(postID, oldContents)
				});
				var tagAssignRequest = await GetTagAssignRequest();
				tagAssignRequest.SelectedTags = request.TagAssignRequest.SelectedTags;
				var requestConvert = SelectConvertBySelectedTags(tagAssignRequest);
				await _postApiClient.TagAssign(postID, requestConvert);
				TempData["result"] = "Thêm mới bài viết thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			var result = await _postApiClient.GetByID(id);
			ViewData["BaseAddress"] = _configuration["BaseAddress"];

			if (result.IsSuccessed)
			{
				var post = result.ResultObj;
				var updateRequest = new PostUpdateRequest()
				{
					PostID = post.PostID,
					PostName = post.PostName,
					SubCategoryID = post.SubCategoryID,
					Contents = post.Contents,
					Thumbnail = post.Thumbnail,
					CategoryName = post.SubCategoryName,
					CategoryID = post.CategoryID,
					TagAssignRequest = SelectConvertByTags(await GetTagAssignRequest(post.PostID))
				};
				return View(updateRequest);
			}
			return RedirectToAction("Error", "Home");
		}

		[HttpPost]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Edit([FromForm]PostUpdateRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			request.Contents = await ConvertImage(request.PostID, request.Contents);
			var result = await _postApiClient.UpdatePost(request.PostID, request);
			if (result.IsSuccessed)
			{
				var requestConvert = SelectConvertBySelectedTags(request.TagAssignRequest);
				await _postApiClient.TagAssign(request.PostID, requestConvert);
				TempData["result"] = "Cập nhật bài viết thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpGet]
		public IActionResult Delete(string id)
		{
			return View(new PostDeleteRequest()
			{
				PostID = id
			});
		}

		[HttpPost]
		public async Task<IActionResult> Delete(PostDeleteRequest request)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _postApiClient.Delete(request.PostID);
			if (result.IsSuccessed)
			{
				TempData["result"] = "Xóa bài viết thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		private async Task<TagAssignRequest> GetTagAssignRequest()
		{
			var tagObj = await _tagApiClient.GetAll();
			var tagAssignRequest = new TagAssignRequest();
			foreach (var tag in tagObj.ResultObj)
			{
				tagAssignRequest.Tags.Add(new SelectItem()
				{
					ID = tag.TagID.ToString(),
					Name = tag.TagName,
					Selected = false
				});
			}
			return tagAssignRequest;
		}

		private async Task<TagAssignRequest> GetTagAssignRequest(string postID)
		{
			var postObj = await _postApiClient.GetByID(postID);
			var tagObj = await _tagApiClient.GetAll();
			var tagAssignRequest = new TagAssignRequest();
			foreach (var tag in tagObj.ResultObj)
			{
				tagAssignRequest.Tags.Add(new SelectItem()
				{
					ID = tag.TagID.ToString(),
					Name = tag.TagName,
					Selected = postObj.ResultObj.Tags.Contains(tag.TagName)
				});
			}
			return tagAssignRequest;
		}

		private TagAssignRequest SelectConvertBySelectedTags(TagAssignRequest request)
		{
			foreach(var item in request.SelectedTags)
			{
				var newTag = true;
				for(int i=0;i<request.Tags.Count;i++)
				{
					if(request.Tags[i].Name.Equals(item))
					{
						newTag = false;
						request.Tags[i].Selected = true;
					}
				}
				if (newTag)
				{
					request.Tags.Add(new SelectItem
					{
						ID = "0",
						Name = item,
						Selected = true
					});
					newTag = false;
				}
			}
			return request;
		}

		private TagAssignRequest SelectConvertByTags(TagAssignRequest request)
		{
			foreach(var item in request.Tags)
			{
				if (item.Selected) request.SelectedTags.Add(item.Name);
			}
			return request;
		}

		private async Task<string> ConvertImage(string id,string contents)
		{
			var base64Strings = new List<string>();
			var requests = new List<PostImageBase64CreateRequest>();
			MatchCollection matchCollImage = Regex.Matches(contents, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase);
			MatchCollection matchCollFileName = Regex.Matches(contents, "data-filename=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase);
			foreach (Match match in matchCollImage)
			{
				var image = match.Groups[1].Value;
				if (!image.Contains(_configuration["BaseAddress"]))
				{ 
					if (checkUrl(image))
					{
						var result = await _postApiClient.AddImageByUrl(id, new PostImageCreateUrlRequest
						{
							ImageUrl = image
						});
						contents = contents.Replace(image, _configuration["BaseAddress"] + "/user-content/" + result.ResultObj);
					}
					else
					{
						base64Strings.Add(image);
						requests.Add(new PostImageBase64CreateRequest { ImageBase64 = image.Split(',')[1] });
					}
				}
			}

			for(int i=0; i<requests.Count;i++)
			{
				requests[i].FileName = matchCollFileName[i].Groups[1].Value;
				var result = await _postApiClient.AddImageBase64(id, requests[i]);
				contents = contents.Replace(base64Strings[i], _configuration["BaseAddress"] + "/user-content/" + result.ResultObj.ImagePath);
			}
			return contents;
		}
		private bool checkUrl(string uriName)
		{
			Uri uriResult;
			bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
				&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
			return result;
		}
	}
}
