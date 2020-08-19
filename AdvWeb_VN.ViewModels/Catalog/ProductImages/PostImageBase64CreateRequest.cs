using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.ProductImages
{
    public class PostImageBase64CreateRequest
    {
        //public string Caption { get; set; }

        //public bool IsDefault { get; set; }

//        public int SortOrder { get; set; }

        public string FileName { set; get; }
        public string ImageBase64 { get; set; }
    }
}