using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface ILoginService
    {
        Writer WriterLogin(Writer writer);
        Admin AdminLogin(Admin admin);
    }
}
