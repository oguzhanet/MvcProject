using MvcProject.DataAccess.Concrete;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject.Mvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = admin.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminPassword = result;

            Context context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName &&
              x.AdminPassword == result);

          
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }

            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}