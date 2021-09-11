using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Entities
{
    public class PostImage
    {
        public int ID { get; set; }

        public int PostID { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }

        //public int SortOrder { get; set; }

        public long FileSize { get; set; }

        public Post Post { get; set; }
    }
}
