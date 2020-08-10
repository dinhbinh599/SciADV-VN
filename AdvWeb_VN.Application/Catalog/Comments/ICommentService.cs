using AdvWeb_VN.ViewModels.Catalog.Categories;
using AdvWeb_VN.ViewModels.Catalog.Comments;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Catalog.Comments
{
	public interface ICommentService
	{
		Task<ApiResult<bool>> Create(CommentCreateRequest request);
		Task<ApiResult<bool>> Update(CommentUpdateRequest request);
		Task<ApiResult<bool>> Delete(string commentID);
		Task<ApiResult<CommentViewModel>> GetByID(string commentID);
		Task<List<CommentViewModel>> GetByParrentID(string parrentID);
		Task<List<CommentViewModel>> GetAll();
	}
}
