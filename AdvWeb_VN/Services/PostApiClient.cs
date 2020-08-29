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

namespace AdvWeb_VN.WebApp.Services
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


        public async Task<ApiResult<PostViewModel>> GetByID(string id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/posts/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<PostViewModel>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<PostViewModel>>(body);
        }

        public async Task<ApiResult<PagedResult<PostViewModel>>> GetPostsPagings(GetPublicPostPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/posts/public-paging-categoryid?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}");
            var body = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<PostViewModel>>>(body);
            return posts;
        }

        public async Task<ApiResult<List<PostViewModel>>> GetPopular()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/posts/popular");
            var body = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<ApiSuccessResult<List<PostViewModel>>>(body);
            return posts;
        }

        public async Task<ApiResult<PagedResult<PostViewModel>>> GetPostsPagingsCategory(GetPublicPostPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/posts/public-paging-category?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&id={request.Id}");
            var body = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<PostViewModel>>>(body);
            return posts;
        }
    }
}
