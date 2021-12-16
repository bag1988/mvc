using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class ModulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Index(string urlPartial)
        {
            if (!System.IO.File.Exists("views/modules/" + urlPartial + ".cshtml"))
                return null;
            return PartialView(urlPartial);
            
        }
    }
}