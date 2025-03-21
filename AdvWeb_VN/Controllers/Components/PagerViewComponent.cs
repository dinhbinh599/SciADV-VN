﻿using AdvWeb_VN.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WebApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result, string anchor = null)
        {
            ViewData["Anchor"] = anchor;
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}