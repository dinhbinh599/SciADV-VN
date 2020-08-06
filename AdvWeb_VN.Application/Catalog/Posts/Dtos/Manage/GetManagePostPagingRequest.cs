using AdvWeb_VN.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Application.Catalog.Posts.Dtos.Manage
{
	public class GetManagePostPagingRequest : PagingRequestBase
	{
		public string KeyWord { set; get; }
		public List<int> TagIds { set; get; }
	}
}
