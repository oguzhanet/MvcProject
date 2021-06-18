using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}