using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Tags
{
	public class GetTagPagingRequest : PagingRequestBase
	{
		public string Keyword { set; get; }
		public List<int> IDs { set; get; }
		public int? ID { set; get; }
	}
}
