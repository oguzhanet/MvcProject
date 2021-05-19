using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace MvcProject.Entities.Concrete
{
    public class Writer:IEntity
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(50)]
        public string WriterName { get; set; }
        [StringLength(50)]
        public string WriterSurName { get; set; }
        [StringLength(150)]
        public string WriterAbout { get; set; }
        [StringLength(30)]
        public string WriterTitle { get; set; }
        [StringLength(100)]
        public string WriterImage { get; set; }
        [StringLength(200)]
        public string WriterMail { get; set; }
        [StringLength(200)]
        public string WriterPassword { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
