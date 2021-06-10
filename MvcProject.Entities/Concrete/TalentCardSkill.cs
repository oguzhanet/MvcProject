using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Entities.Concrete
{
    public class TalentCardSkill:IEntity 
    {
        [Key]
        public int SkillId { get; set; }
        [StringLength(20)]
        public string Skill { get; set; }
        [StringLength(3)]
        public string SkillPoint { get; set; }
    }
}
