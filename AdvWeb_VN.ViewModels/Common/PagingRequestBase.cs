using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Common
{
	public class PagingRequestBase
	{
		public int PageIndex { set; get; }
		public int PageSize { set; get; }
	}
}
