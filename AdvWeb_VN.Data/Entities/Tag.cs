using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class Tag
	{
		public string TagID { set; get; }
		public string TagName { set; get; }
		public List<PostTag> PostTags { set; get; }
	}
}
