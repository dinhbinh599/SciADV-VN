using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class PostTag
	{
		public string PostID { set; get; }
		public Post Post { set; get; }
		public string TagID { set; get; }
		public Tag Tag { set; get; }
	}
}
