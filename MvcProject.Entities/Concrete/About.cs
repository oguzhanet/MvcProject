using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace MvcProject.Entities.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int AboutId { get; set; }
        [StringLength(1000)]
        public string AboutDetails1 { get; set; }
        [StringLength(1000)]
        public string AboutDetails2 { get; set; }
        [StringLength(100)]
        public string AboutImage1 { get; set; }
        [StringLength(100)]
        public string AboutImage2 { get; set; }
        public bool AboutStatus { get; set; }
    }
}
