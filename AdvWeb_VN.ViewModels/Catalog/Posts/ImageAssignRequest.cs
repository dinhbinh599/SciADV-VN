using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.ViewModels.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
    public class ImageAssignRequest
    {
        public List<PostImage> postImages { get; set; } = new List<PostImage>();
    }
}