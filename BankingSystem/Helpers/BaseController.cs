using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.Helpers
{
    public abstract class BaseController<T> : Controller
    {
        private ApiUrlConfig apiUrl;

        protected ApiUrlConfig _Config => apiUrl ??= HttpContext.RequestServices.GetService<ApiUrlConfig>();
    }
}
