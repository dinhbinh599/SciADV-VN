using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Common.Tags
{
    public class ApiErrorResultSelect2<T> : ApiResultSelect2<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResultSelect2()
        {
        }

        public ApiErrorResultSelect2(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResultSelect2(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}