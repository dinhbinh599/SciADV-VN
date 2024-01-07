using AdvWeb_VN.ViewModels.Catalog.Comments;
using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Services
{
	public class CommentApiClient : ICommentApiClient
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public CommentApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public async Task<ApiResult<bool>> CreateComment(CommentCreatePublicRequest createRequest)
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);

			var json = JsonConvert.SerializeObject(createRequest);
			var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync($"/api/comments/comment-public", httpContent);
			var result = await response.Content.ReadAsStringAsync();
			if (response.IsSuccessStatusCode)
				return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

			return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
		}
		public async Task<ApiResult<PagedResult<CommentViewModel>>> GetPagingByPostID(GetPublicPostPagingRequest request)
		{
			var client = _httpClientFactory.CreateClient("backendapi");
			var response = await client.GetAsync($"/api/comments/post?pageIndex=" +
				$"{request.PageIndex}&pageSize={request.PageSize}&id={request.Id}");
			var body = await response.Content.ReadAsStringAsync();
			var comments = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<CommentViewModel>>>(body);
			return comments;
		}
	}
}
