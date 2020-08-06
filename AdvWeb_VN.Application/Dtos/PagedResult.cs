using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Application.Dtos
{
	public class PagedResult<T>
	{
		List<T> Items { set; get; }
		public int TotalRecord { set; get; }
	}
}
