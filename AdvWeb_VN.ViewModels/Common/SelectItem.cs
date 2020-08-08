using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Common
{
    public class SelectItem
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public bool Selected { get; set; }

        public object Select()
        {
            throw new NotImplementedException();
        }
    }
}