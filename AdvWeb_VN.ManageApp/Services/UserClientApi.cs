using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.ViewModels.System.Users;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.ManageApp.Services
{
	public class UserClientApi : IUserClientApi
	{
		private readonly IHttpClientFactory httpClientFactory;
		private readonly IConfiguration configuration;

		public UserClientApi(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			this.httpClientFactory = httpClientFactory;
			this.configuration = configuration;
		}

		public async Task<ApiResult<string>> Authenticate(LoginRequest request)
		{
			var json = JsonConvert.SerializeObject(request);
			var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

			var client = httpClientFactory.CreateClient();
			client.BaseAddress = new Uri("https://localhost:5002");
			var response = await client.PostAsync("/api/users/authenticate", httpContent);
			if (response.IsSuccessStatusCode)
			{
				return JsonConvert.DeserializeObject<ApiSuccessResult<string>>(await response.Content.ReadAsStringAsync());
			}

			return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await response.Content.ReadAsStringAsync());
		}
	}
}
