using MVC1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class FileUploadController : Controller
    {
        private MVC1Context db = new MVC1Context();
        // GET: FileUpload


        public ActionResult Index()
        {
            var model = new UploadFileResult();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UploadFileResult model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            byte[] uploadedFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            // now you could pass the byte array to your model and store wherever 
            // you intended to store it

            return Content("Thanks for uploading the file");
        }
    }
}
