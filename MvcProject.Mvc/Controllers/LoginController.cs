using MvcProject.DataAccess.Concrete;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft;
using Newtonsoft.Json;
using MvcProject.Business.Abstract;

namespace MvcProject.Mvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            //SHA1 sha1 = new SHA1CryptoServiceProvider();
            //string password = admin.AdminPassword;
            //string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            //admin.AdminPassword = result;

            //Context context = new Context();
            //var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName &&
            //  x.AdminPassword == result); //Business katmanına taşındı

            var adminUserInfo = _loginService.AdminLogin(admin);

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

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //SHA1 sha1 = new SHA1CryptoServiceProvider();
            //string password = writer.WriterPassword;
            //string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            //writer.WriterPassword = result;

            //Context context = new Context();
            //var writerUserInfo = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail &&
            //  x.WriterPassword == result); //Business Katmanına Taşındı

            var writerUserInfo = _loginService.WriterLogin(writer);

            var response = Request["g-recaptcha-response"];
            const string secret = "6LfHFTwbAAAAAB53V5ZcixAgVCi2aTXIuF-eLxF9";
            var client = new WebClient();

            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            if (!captchaResponse.Success)
            {
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                return View();
            }

            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }

            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
            return View();
        }

        public ActionResult WriterLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("WriterLogin", "Login");
        }

        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }
    }
}