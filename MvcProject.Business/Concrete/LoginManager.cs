using MvcProject.Business.Abstract;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Concrete
{
    public class LoginManager : ILoginService
    {
        private IWriterService _writerService;
        private IAdminService _adminService;

        public LoginManager(IWriterService writerService, IAdminService adminService)
        {
            _writerService = writerService;
            _adminService = adminService;
        }

        public Admin AdminLogin(Admin admin)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = admin.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminPassword = result;

            var adminInfo = _adminService.GetAdmin(admin.AdminUserName, result);
            return adminInfo;
        }

        public Writer WriterLogin(Writer writer)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = writer.WriterPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            writer.WriterPassword = result;

            var writerUserInfo = _writerService.GetWriter(writer.WriterMail, result);
            return writerUserInfo;
        }
    }
}
