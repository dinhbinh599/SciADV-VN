using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Common.Tags
{
    public class ApiResultSelect2<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }

        public T results{ get; set; }
    }
}