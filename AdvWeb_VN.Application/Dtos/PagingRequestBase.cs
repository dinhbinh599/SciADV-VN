using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Application.Dtos
{
	public class PagingRequestBase
	{
		public int PageIndex { set; get; }
		public int PageSize { set; get; }
	}
}
