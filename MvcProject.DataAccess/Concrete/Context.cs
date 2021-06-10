using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcProject.Entities.Concrete;

namespace MvcProject.DataAccess.Concrete
{
    public class Context : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ımageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<TalentCard> TalentCards { get; set; }
        public DbSet<TalentCardSkill> talentCardSkills { get; set; }

    }
}
