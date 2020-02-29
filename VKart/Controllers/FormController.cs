using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VKart.Models;

namespace VKart.Controllers
{
    public class FormController : Controller
    {

        public ActionResult Upload()
        {
            ViewBag.Message = string.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase postedFile, string fileKey)
        {
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var uploadedFileOriginalName = Path.GetFileName(postedFile.FileName);

                postedFile.SaveAs(path + fileKey + Path.GetExtension(postedFile.FileName));

                ViewBag.Message = "File uploaded successfully.";
            }

            return View("Upload");
        }

        public ActionResult ReadImagesFromDirectory()
        {
            List<FileDetails> files = new List<FileDetails>();

            string path = Server.MapPath("~/Uploads/");


            foreach (var item in Directory.GetFiles(path))
            {
                files.Add(new FileDetails
                {
                    Name = Path.GetFileNameWithoutExtension(item),
                    Path = Url.Content(string.Format("~/Uploads/{0}", Path.GetFileName(item)))
                });
            }


            return View(files.AsEnumerable());
        }

    }
}