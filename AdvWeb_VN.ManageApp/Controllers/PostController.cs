using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.ManageApp.Models;
using AdvWeb_VN.ManageApp.Services;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.Utilities.Settings;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb_VN.ManageApp.Controllers
{
	public class PostController : BaseController
	{
		private readonly IPostApiClient _postApiClient;
		private readonly IConfiguration _configuration;
		private readonly ITagApiClient _tagApiClient;

		public PostController(IPostApiClient postApiClient, IConfiguration configuration, ISubCategoryApiClient subCategegoryApiClient, ICategoryApiClient categegoryApiClient, ITagApiClient tagApiClient)
		{
			_postApiClient = postApiClient;
			_configuration = configuration;
			_tagApiClient = tagApiClient;
		}

		public async Task<IActionResult> Index(string keyword, int id = 0, int pageIndex = 1, int pageSize = 10)
		{
			//Hiển thị Post Paging theo CategoryID
			//Sau có lẽ thêm hiển thị All nữa ???
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			ViewData["PortalAddress"] = _configuration["PortalAddress"];

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
			ViewData["PageSize"] = pageSize;
			if (TempData["result"] != null)
			{
				ViewBag.SuccessMsg = TempData["result"];
			}
			return View(data.ResultObj);
		}

		// GET: /<controller>/


		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			//Để đây cho vui, sau xem chi tiết dẫn hẳn đến WebApp của bài viết
			var result = await _postApiClient.GetByID(id);
			return View(result.ResultObj);
		}

		[HttpGet]
		public IActionResult Create()
		{
			//Dẫn hướng đến trang khởi tạo bài viết mới
			//Lấy UserID hiện hành
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			ViewData["ManageAddress"] = _configuration["ManageAddress"];
			var userID = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

			var postCreateRequest = new PostCreateRequest()
			{
				UserID = userID
			};
			return View(postCreateRequest);
		}

		[HttpPost]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Create([FromForm] PostCreateRequest request)
		{
			//Khởi tạo bài viết mới nếu request truyền lên đầy đủ
			//Lấy hình ảnh từ trang Web khác rồi upload lên Server mình đồng thời sửa lại đường dẫn vào bài viết
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			ViewData["ManageAddress"] = _configuration["ManageAddress"];

			if (!ModelState.IsValid)
				return View();

			//var oldContents = request.Contents;
			//request.Contents = "oldContents";

			//Convert Format của Write Time
			DateTime writeTime = DateTime.ParseExact(request.TimePicker, "MM/dd/yyyy h:mm tt",
									   System.Globalization.CultureInfo.InvariantCulture);
			request.WriteTime = writeTime;

			//Replace url thật bằng placeholder để tránh lưu cứng url vào nội dung bài viết
			request.Contents = request.Contents.Replace(_configuration["BaseAddress"], "{{BaseAddress}}");

			var result = await _postApiClient.CreatePost(request);

			if (result.IsSuccessed)
			{
				var postID = result.ResultObj.PostID;

				////Sửa lại url Hình ảnh trong bài viết thành url của server mình
				// await _postApiClient.UpdateContents(postID, new PostUpdateContentsRequest
				// {
				// 	id = result.ResultObj.PostID,
				// 	Contents = await ConvertImage(postID, oldContents)
				// });

				//Gán Tag cho bài viết
				var tagAssignRequest = await GetTagAssignRequest();
				tagAssignRequest.SelectedTags = request.TagAssignRequest.SelectedTags;
				var requestConvert = SelectConvertBySelectedTags(tagAssignRequest);
				await _postApiClient.TagAssign(postID, requestConvert);

				await _postApiClient.ImageAssign(new ImageAssignRequest()
				{
					postImages = getPostImages(postID, request.Contents)
				});

				TempData["result"] = "Thêm mới bài viết thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			//Dẫn hướng đến trang chỉnh sửa bài viết
			var result = await _postApiClient.GetByID(id);
			ViewData["BaseAddress"] = _configuration["BaseAddress"];
			ViewData["PortalAddress"] = _configuration["PortalAddress"];
			var convert = new ConvertTime();
			//Replace placeholder bằng url thật để hiển thị nội dung bài viết
			result.ResultObj.Contents = result.ResultObj.Contents.Replace("{{BaseAddress}}", _configuration["BaseAddress"]);

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
					CategoryName = post.CategoryName,
					SubCategoryName = post.SubCategoryName,
					IsShow = post.IsShow ?? false,
					CategoryID = post.CategoryID,
					TimePicker = convert.ConvertToGMT7(post.WriteTime).ToString("MM'/'dd'/'yyyy hh:mm tt"),
					TagAssignRequest = SelectConvertByTags(await GetTagAssignRequest(post.PostID))
				};
				return View(updateRequest);
			}
			return RedirectToAction("Error", "Home");
		}

		[HttpPost]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Edit([FromForm] PostUpdateRequest request)
		{
			//Chỉnh sửa bài viết từ Form gửi lên nếu request đầy đủ
			ViewData["BaseAddress"] = _configuration["BaseAddress"];

			if (!ModelState.IsValid)
				return View();

			//request.Contents = await ConvertImage(request.PostID, request.Contents);

			//Convert Format của Write Time
			DateTime writeTime = DateTime.ParseExact(request.TimePicker, "MM/dd/yyyy h:mm tt",
									   System.Globalization.CultureInfo.InvariantCulture);
			request.WriteTime = writeTime;

			//Replace url thật bằng placeholder để tránh lưu cứng url vào nội dung bài viết
			request.Contents = request.Contents.Replace(_configuration["BaseAddress"], "{{BaseAddress}}");

			var result = await _postApiClient.UpdatePost(request.PostID, request);
			if (result.IsSuccessed)
			{
				var requestConvert = SelectConvertBySelectedTags(request.TagAssignRequest);
				await _postApiClient.TagAssign(request.PostID, requestConvert);
				await _postApiClient.ImageAssign(new ImageAssignRequest()
				{
					postImages = getPostImages(request.PostID, request.Contents)
				});
				TempData["result"] = "Cập nhật bài viết thành công";
				return RedirectToAction("Index");
			}
			var resultEdit = await _postApiClient.GetByID(request.PostID);
			var post = resultEdit.ResultObj;

			request.Thumbnail = post.Thumbnail;
			request.CategoryID = post.CategoryID;
			request.SubCategoryID = post.SubCategoryID;
			request.IsShow = post.IsShow ?? false;

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			//Dẫn hướng đến trang xác nhận xóa bài viết
			return View(new PostDeleteRequest()
			{
				PostID = id
			});
		}

		[HttpPost]
		public async Task<IActionResult> Delete(PostDeleteRequest request)
		{
			//Xóa bài viết nếu request đầy đủ
			ViewData["BaseAddress"] = _configuration["BaseAddress"];

			if (!ModelState.IsValid)
				return View();

			var result = await _postApiClient.Delete(request.PostID);
			if (result.IsSuccessed)
			{
				var resultUnassign = await _postApiClient.ImageUnassignAll(request.PostID);
				TempData["result"] = "Xóa bài viết thành công";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", result.Message);
			return View(request);
		}

		[HttpPost("UploadFiles")]
		[Produces("application/json")]
		public async Task<IActionResult> Post(List<IFormFile> files)
		{
			var imageServerUrl = _configuration["BaseAddress"];

			// Get the file from the POST request
			var theFile = HttpContext.Request.Form.Files.GetFile("file");

			// Get the mime type
			var mimeType = HttpContext.Request.Form.Files.GetFile("file").ContentType;

			// Get File Extension
			string extension = System.IO.Path.GetExtension(theFile.FileName);

			// Generate Random name.
			string name = Guid.NewGuid().ToString().Substring(0, 8) + extension;

			// Basic validation on mime types and file extension
			string[] imageMimetypes = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };
			string[] imageExt = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };

			try
			{
				if (Array.IndexOf(imageMimetypes, mimeType) >= 0 && (Array.IndexOf(imageExt, extension) >= 0))
				{
					var createRequest = new PostImageCreateRequest()
					{
						ImageFile = theFile
					};

					var result = await _postApiClient.UploadImage(createRequest);

					// Return the file path as json
					Hashtable imageUrl = new Hashtable();
					imageUrl.Add("link", imageServerUrl + "/" + result.ResultObj);

					return Json(imageUrl);
				}
				throw new ArgumentException("The image did not pass the validation");
			}

			catch (ArgumentException ex)
			{
				return Json(ex.Message);
			}
		}

		private async Task<TagAssignRequest> GetTagAssignRequest()
		{
			//Lấy danh sách toàn bộ Tag
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

		private async Task<TagAssignRequest> GetTagAssignRequest(int postID)
		{
			//Lấy danh sách Tag đã được gán vào bài viết dựa vào postID
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
			//Kiểm tra Tag đã tồn tại hay chưa
			foreach (var item in request.SelectedTags)
			{
				var newTag = true;
				for (int i = 0; i < request.Tags.Count; i++)
				{
					if (request.Tags[i].Name.Equals(item))
					{
						newTag = false;
						request.Tags[i].Selected = true;
					}
				}
				//Nếu chưa thì thêm mới Tag
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
			//Thêm Tag đã được Selected
			foreach (var item in request.Tags)
			{
				if (item.Selected) request.SelectedTags.Add(item.Name);
			}
			return request;
		}

		private async Task<string> ConvertImage(int id, string contents)
		{
			//Kiểm tra hình ảnh là từ Url hình hay từ máy up lên
			//Tùy loại thì upload nó lên API theo từng kiểu khác nhau
			//Dùng Regex để kiểm tra

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

			for (int i = 0; i < requests.Count; i++)
			{
				requests[i].FileName = matchCollFileName[i].Groups[1].Value;
				var result = await _postApiClient.AddImageBase64(id, requests[i]);
				contents = contents.Replace(base64Strings[i], _configuration["BaseAddress"] + "/user-content/" + result.ResultObj.ImagePath);
			}
			return contents;
		}

		private bool checkUrl(string uriName)
		{
			//Kiểm tra có phải Url hay không.
			Uri uriResult;
			bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
				&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
			return result;
		}

		private List<PostImage> getPostImages(int postID, string contents)
		{
			var postImages = new List<PostImage>();
			MatchCollection matchCollImage = Regex.Matches(contents, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase);

			foreach (Match match in matchCollImage)
			{
				var image = match.Groups[1].Value;
				if (image.Contains(_configuration["BaseAddress"]))
				{
					postImages.Add(new PostImage
					{
						PostID = postID,
						DateCreated = DateTime.Now,
						ImagePath = image.Replace(_configuration["BaseAddress"] + "/user-content/", "")
					});
				}
			}
			return postImages;
		}
	}
}
