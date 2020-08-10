using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.Posts
{
    public class TagAssignRequest
    {
        //public Guid ID { get; set; }
        public List<SelectItem> Tags { get; set; } = new List<SelectItem>();
    }
}