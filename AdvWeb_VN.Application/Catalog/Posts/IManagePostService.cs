using AdvWeb_VN.ViewModels.Catalog.Posts;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public interface IManagePostService
	{
		Task<string> Create(PostCreateRequest request);

		Task<int> Update(PostUpdateRequest request);

		Task<int> Delete(string postId);

		Task AddViewCount(string postId);
		Task<PostViewModel> GetByID(string postID);
		Task<PagedResult<PostViewModel>> GetAllPaging(GetManagePostPagingRequest request);
	}
}
