using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
	public class PostTag
	{
		public int PostID { set; get; }
		public Post Post { set; get; }
		public int TagID { set; get; }
		public Tag Tag { set; get; }
	}
}
