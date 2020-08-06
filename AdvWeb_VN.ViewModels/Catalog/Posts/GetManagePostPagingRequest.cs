using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
	public class GetManagePostPagingRequest : PagingRequestBase
	{
		public string KeyWord { set; get; }
		public List<int> TagIds { set; get; }
	}
}
