using AdvWeb_VN.Application.Catalog.Posts.Dtos;
using AdvWeb_VN.Application.Catalog.Posts.Dtos.Manage;
using AdvWeb_VN.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.Posts
{
	public interface IManagePostService
	{
		Task<int> Create(PostCreateRequest request);

		Task<int> Update(PostUpdateRequest request);

		Task<int> Delete(int postId);

		Task AddViewCount(int postId);

		Task<PagedResult<PostViewModel>> GetAllPaging(GetManagePostPagingRequest request);
	}
}
