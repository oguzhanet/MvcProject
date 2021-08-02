using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        //ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        private IImageFileService _ımageFileService;

        public GalleryController(IImageFileService ımageFileService)
        {
            _ımageFileService = ımageFileService;
        }

        public ActionResult Index()
        {
            var files = _ımageFileService.GetAll();
            return View(files);
        }

        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ImageFile ımageFile)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/AdminLTE-3.0.4/Images/" + fileName + expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ımageFile.ImagePath = "/AdminLTE-3.0.4/Images/" + fileName + expansion;
                _ımageFileService.Add(ımageFile);
                Thread.Sleep(1500);
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}