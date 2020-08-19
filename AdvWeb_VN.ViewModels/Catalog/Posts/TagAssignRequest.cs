using AdvWeb_VN.ViewModels.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
    public class TagAssignRequest
    {
        public List<string> SelectedTags { get; set; } = new List<string>();
        public List<SelectItem> Tags { get; set; } = new List<SelectItem>();
    }
}