using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Abstract;
using MvcProject.DataAccess.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {           
            Bind<IAboutService>().To<AboutManager>().InSingletonScope();
            Bind<IAboutDal>().To<EfAboutDal>().InSingletonScope();

            Bind<IAdminService>().To<AdminManager>().InSingletonScope();
            Bind<IAdminDal>().To<EfAdminDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<IContactService>().To<ContactManager>().InSingletonScope();
            Bind<IContactDal>().To<EfContactDal>().InSingletonScope();

            Bind<IContentService>().To<ContentManager>().InSingletonScope();
            Bind<IContentDal>().To<EfContentDal>().InSingletonScope();

            Bind<IHeadingService>().To<HeadingManager>().InSingletonScope();
            Bind<IHeadingDal>().To<EfHeadingDal>().InSingletonScope();

            Bind<IImageFileService>().To<ImageFileManager>().InSingletonScope();
            Bind<IImageFileDal>().To<EfImageFileDal>().InSingletonScope();

            Bind<IMessageService>().To<MessageManager>().InSingletonScope();
            Bind<IMessageDal>().To<EfMessageDal>().InSingletonScope();

            Bind<ITalentCardService>().To<TalentCardManager>().InSingletonScope();
            Bind<ITalentCardDal>().To<EfTalentCardDal>().InSingletonScope();

            Bind<ITalentCardSkillService>().To<TalentCardSkillManager>().InSingletonScope();
            Bind<ITalentCardSkillDal>().To<EfTalentCardSkillDal>().InSingletonScope();

            Bind<IWriterService>().To<WriterManager>().InSingletonScope();
            Bind<IWriterDal>().To<EfWriterDal>().InSingletonScope();

            Bind<ILoginService>().To<LoginManager>().InSingletonScope();
        }
    }
}
