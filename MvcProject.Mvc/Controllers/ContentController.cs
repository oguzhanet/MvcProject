﻿using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetAllByHeadingId(id);
            return View(contentValues);
        }
    }
}