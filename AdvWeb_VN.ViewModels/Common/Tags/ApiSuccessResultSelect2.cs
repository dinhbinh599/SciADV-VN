using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Common.Tags
{
    public class ApiSuccessResultSelect2<T> : ApiResultSelect2<T>
    {
        public ApiSuccessResultSelect2(T resultObj)
        {
            IsSuccessed = true;
            results = resultObj;
        }

        public ApiSuccessResultSelect2()
        {
            IsSuccessed = true;
        }
    }
}