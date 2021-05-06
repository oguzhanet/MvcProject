﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess.EntityFramework;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entities.Concrete;

namespace MvcProject.DataAccess.Concrete
{
    public class EfHeadingDal:EfEntityRepositoryBase<Heading,Context>,IHeadingDal
    {
    }
}
