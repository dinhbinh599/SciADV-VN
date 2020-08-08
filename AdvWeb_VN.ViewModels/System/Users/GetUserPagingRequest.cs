using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
	public class GetUserPagingRequest : PagingRequestBase
	{
		public string Keyword { set; get; }
	}
}
