using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Catalog.ProductImages;
using AdvWeb_VN.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.ManageApp.Services
{
    public class PostApiClient : IPostApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/posts/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<ApiResult<PostViewModel>> GetByID(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/posts/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<PostViewModel>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<PostViewModel>>(body);
        }

        public async Task<ApiResult<PagedResult<PostViewModel>>> GetPostsPagings(GetManagePostPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/posts/paging-categoryid?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}&id={request.ID}");
            var body = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<PostViewModel>>>(body);
            return posts;
        }

        public async Task<ApiResult<PostViewModel>> CreatePost(PostCreateRequest createRequest)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (createRequest.ThumbnailFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(createRequest.ThumbnailFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)createRequest.ThumbnailFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "thumbnailFile", createRequest.ThumbnailFile.FileName);
            }

            requestContent.Add(new StringContent(createRequest.PostName), "postName");
            requestContent.Add(new StringContent(createRequest.CategoryID.ToString()), "categoryID");
            requestContent.Add(new StringContent(createRequest.SubCategoryID.ToString()), "subCategoryID");
            requestContent.Add(new StringContent(createRequest.UserID.ToString()), "userID");
            requestContent.Add(new StringContent(createRequest.Contents), "contents");
            requestContent.Add(new StringContent(createRequest.WriteTime.ToString()), "writeTime");
            requestContent.Add(new StringContent(createRequest.IsShow.ToString()), "isShow");

            var response = await client.PostAsync($"/api/posts/", requestContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<PostViewModel>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<PostViewModel>>(result);
        }

        public async Task<ApiResult<PostImageViewModel>> AddImageBase64(int postID, PostImageBase64CreateRequest createRequest)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (createRequest.ImageBase64 != null)

            {
                byte[] data = Convert.FromBase64String(createRequest.ImageBase64);
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "imageFile", createRequest.FileName);
            }


            var response = await client.PostAsync($"/api/posts/{postID}/images", requestContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<PostImageViewModel>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<PostImageViewModel>>(result);
        }

        public async Task<ApiResult<bool>> UpdatePost(int id, PostUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                            .HttpContext
                            .Session
                            .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailFile != null)

            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "thumbnailFile", request.ThumbnailFile.FileName);
            }

            requestContent.Add(new StringContent(request.PostName), "postName");
            requestContent.Add(new StringContent(request.CategoryID.ToString()), "categoryID");
            requestContent.Add(new StringContent(request.SubCategoryID.ToString()), "subCategoryID");
            requestContent.Add(new StringContent(request.Contents), "contents");
            requestContent.Add(new StringContent(request.WriteTime.ToString()), "writeTime");
            requestContent.Add(new StringContent(request.IsShow.ToString()), "isShow");

            var response = await client.PutAsync($"/api/posts/{request.PostID}", requestContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

        public async Task<ApiResult<bool>> TagAssign(int id, TagAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/posts/{id}/tags", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }


        public async Task<ApiResult<string>> AddImageByUrl(int id, PostImageCreateUrlRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/posts/{id}/images/url", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            var imagePath = JsonConvert.DeserializeObject<ApiSuccessResult<string>>(body);
            return imagePath;
        }

        public async Task<ApiResult<bool>> UpdateContents(int id, PostUpdateContentsRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/posts/{id}/contents", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);
            return result;
        }

        public async Task<ApiResult<string>> UploadImage(PostImageCreateRequest createRequest)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (createRequest.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(createRequest.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)createRequest.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "imageFile", createRequest.ImageFile.FileName);
            }

            var response = await client.PostAsync($"/api/images/", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            var imagePath = JsonConvert.DeserializeObject<ApiSuccessResult<string>>(body);
            return imagePath;
        }

        public async Task<ApiResult<bool>> ImageAssign(ImageAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/images/assign", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

        public async Task<ApiResult<bool>> ImageUnassignAll(int postID)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/images/{postID}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }
    }
}
