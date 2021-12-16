using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Areas.Admin.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace mvc.Areas.Admin.Controllers
{
    [Area("admin")]
    public class userImagesController : Controller
    {
        // GET: Admin/userImages
        public ActionResult Index(string name)
        {
            return View();
        }

        [HttpPost]
        public ActionResult getDirInfo(string nameDirectory)
        {
            nameDirectory = "/images/" + (nameDirectory == null ? "" : nameDirectory + "/");
            string url ="wwwroot"+ nameDirectory;
            if (!Directory.Exists("wwwroot/images/"))
            {
                Directory.CreateDirectory("wwwroot/images/");
            }
            if (Directory.Exists(url))
            {
                viewDirectory views = new viewDirectory();
                views.nameFile = new DirectoryInfo(url).GetFiles().Select(x => nameDirectory + x.Name).ToList();
                views.nameDirectory = new DirectoryInfo(url).GetDirectories().Select(x => x.Name).ToList();
                return Json(views);
            }
            return NoContent();
        }

        [HttpPost]
        public JsonResult saveNewImages(IFormFile image, string dirName, string imgName)
        {
            if (image == null)
                return Json("<font style='color:red'>Выберете файл!</font>");
            FileInfo fInfo = new FileInfo(image.FileName);
            string exec = fInfo.Extension;
            if (("jpg gif png jpeg").Contains(exec))
                return Json("<font style='color:red'>Допустимые расширения файла: JPG, JPEG, PNG, GIF</font>");
            if (image.Length > 6000000)
                return Json("<font style='color:red'>Допустимый размер файла 5mb</font>");
            if (dirName == "")
                dirName = "wwwroot/images/";
            if (imgName == "")
                return Json("<font style='color:red'>Введите имя файла</font>");

            string path = "wwwroot" + dirName + imgName + exec;
            if (System.IO.File.Exists(path))
                return Json("<font style='color:red'>Файл с именем " + imgName + " существует, выберете другое имя файла!</font>");


            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return Json("<font style='color:green'>Файл сохранен!</font>");
        }

        [HttpPost]
        public JsonResult deleteImages(string nameImage)
        {
            nameImage ="wwwroot" +  nameImage;
            if (!System.IO.File.Exists(nameImage))
                return Json("<font style='color:red'>Файл  " + nameImage + " несуществует!</font>");


            System.IO.File.Delete(nameImage);

            return Json("<font style='color:green'>Файл удален!</font>");
        }

        [HttpPost]
        public string CreateDirectory(string nameDirectory)
        {
            try
            {
                string url = "wwwroot/images/" + nameDirectory.Replace(" ", "");
                if (!Directory.Exists(url))
                {
                    Directory.CreateDirectory(url);
                    return "<font style='color:green'>Папка с именем " + nameDirectory + " создана</font>";
                }
                else
                {
                    return "<font style='color:red'>Папка с таким именем " + nameDirectory + " существует</font>";
                }
            }
            catch (Exception e)
            {
                return "<font style='color:red'>" + e.ToString() + "</font>";
            }
        }
    }
}
