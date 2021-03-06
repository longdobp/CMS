﻿using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagingResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}