﻿using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        //private IAdminService _adminService;

        //public AuthorizationController(IAdminService adminService)
        //{
        //    _adminService = adminService;
        //}

        public ActionResult Index()
        {
            var adminValues = adminManager.GetAll();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            List<SelectListItem> valueAdmin = (from adm in adminManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = adm.AdminRole,
                                                   Value = adm.AdminRole
                                               }).ToList();
            ViewBag.valueAdmin = valueAdmin;
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = admin.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminPassword = result;
            adminManager.Add(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admin admin)
        {
            var adminValue = adminManager.GetById(admin.AdminId);
            admin.AdminPassword = adminValue.AdminPassword;
            adminManager.Update(admin);
            return RedirectToAction("Index");
        }
    }
}