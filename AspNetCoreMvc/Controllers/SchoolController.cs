using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Controllers
{
    [SchoolActionFilter]
    [LoginActionFilter]
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}