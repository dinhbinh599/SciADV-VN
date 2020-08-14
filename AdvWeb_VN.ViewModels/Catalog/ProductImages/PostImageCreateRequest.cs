using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.ProductImages
{
    public class PostImageCreateRequest
    {
        public string Caption { get; set; }

        public bool IsDefault { get; set; }

//        public int SortOrder { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}