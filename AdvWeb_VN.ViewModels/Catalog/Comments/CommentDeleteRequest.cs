using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Comments
{
    public class CommentDeleteRequest
    {
        public int CommentID { get; set; }
        public int PostID { set; get; }
    }
}