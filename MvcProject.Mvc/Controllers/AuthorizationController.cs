using MvcProject.Business.Concrete;
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
        //private IAboutService _aboutSercice;

        //public AboutController(IAboutService aboutSercice)
        //{
        //    _aboutSercice = aboutSercice;
        //}
        public ActionResult Index()
        {
            var adminValues = adminManager.GetAll();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
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
    }
}