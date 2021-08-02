using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Entities.Concrete
{
    public class Intern : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Mail { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
    }
}
