using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class GetPublicPostPagingRequest : PagingRequestBase
	{
		public int? Id { set; get; }
	}
}
