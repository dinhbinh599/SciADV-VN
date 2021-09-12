using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Catalog.Categories;
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
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<List<CategoryMenuViewModel>>> GetMenuCategory()
        {
            //Khởi tạo kết nối đến WebApi, không xác thực người dùng
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/categories/menu");
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<List<CategoryMenuViewModel>>>(result);
            return JsonConvert.DeserializeObject<ApiErrorResult<List<CategoryMenuViewModel>>>(result);
        }

        public async Task<ApiResult<List<CategoryViewModel>>> GetFooterCategory()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/categories/footer");
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<List<CategoryViewModel>>>(result);
            return JsonConvert.DeserializeObject<ApiErrorResult<List<CategoryViewModel>>>(result);
        }
    }
}
