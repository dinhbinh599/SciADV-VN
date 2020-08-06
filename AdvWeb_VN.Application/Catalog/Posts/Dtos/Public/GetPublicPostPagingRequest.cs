using AdvWeb_VN.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Application.Catalog.Posts.Dtos.Public
{
	public class GetPublicPostPagingRequest : PagingRequestBase
	{
		public string CategoryId { set; get; }
	}
}
