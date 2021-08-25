using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.SubCategories;
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
    public class SubCategoryApiClient : ISubCategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubCategoryApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<SubCategoryViewModel>> GetByID(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/subcategories/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<SubCategoryViewModel>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<SubCategoryViewModel>>(body);
        }

        public async Task<List<SubCategoryViewModel>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/subcategories");
            var body = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<SubCategoryViewModel>>(body);
            return categories;
        }
    }
}
