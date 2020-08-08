using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid ID { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}