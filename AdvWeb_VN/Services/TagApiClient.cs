using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Catalog.Tags;
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
    public class TagApiClient : ITagApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TagApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<TagViewModel>> GetByID(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/tags/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<TagViewModel>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<TagViewModel>>(body);
        }

        public async Task<ApiResult<List<TagViewModel>>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/tags");
            var body = await response.Content.ReadAsStringAsync();
            var tags = JsonConvert.DeserializeObject<ApiResult<List<TagViewModel>>>(body);
            return tags;
        }

        public async Task<ApiResult<PagedResult<TagViewModel>>> GetTagsPagings(GetTagPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/tags/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var tags = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<TagViewModel>>>(body);
            return tags;
        }

        public async Task<ApiResult<List<TagViewModel>>> GetAllByCategoryID(int categoryID)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/tags/category/{categoryID}");
            var body = await response.Content.ReadAsStringAsync();
            var tags = JsonConvert.DeserializeObject<ApiSuccessResult<List<TagViewModel>>>(body);
            return tags;
        }
    }
}
