using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models.Base;

namespace mvc.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RedactorController : Controller
    {
        // GET: Admin/Redactor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult adminPanel()
        {
            return PartialView();
        }
        
    }
}