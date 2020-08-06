using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Application.Catalog.Posts.Dtos
{
	public class GetPublicPostPagingRequest : PagingRequestBase
	{
		public int? TagId { set; get; }
	}
}
