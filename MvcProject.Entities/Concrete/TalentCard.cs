using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Entities.Concrete
{
    public class TalentCard:IEntity
    {
        [Key]
        public int CardId { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Text { get; set; }
        [StringLength(20)]
        public string Skill { get; set; }
        public int SkillPoint { get; set; }
        [StringLength(20)]
        public string Skill2 { get; set; }
        public int SkillPoint2 { get; set; }
        [StringLength(20)]
        public string Skill3 { get; set; }
        public int SkillPoint3 { get; set; }
        [StringLength(20)]
        public string Skill4 { get; set; }
        public int SkillPoint4 { get; set; }
        [StringLength(20)]
        public string Skill5 { get; set; }
        public int SkillPoint5 { get; set; }
        [StringLength(20)]
        public string Skill6 { get; set; }
        public int SkillPoint6 { get; set; }
        [StringLength(20)]
        public string Skill7 { get; set; }
        public int SkillPoint7 { get; set; }
        [StringLength(20)]
        public string Skill8 { get; set; }
        public int SkillPoint8 { get; set; }
        [StringLength(20)]
        public string Skill9 { get; set; }
        public int SkillPoint9 { get; set; }
        [StringLength(20)]
        public string Skill10 { get; set; }
        public int SkillPoint10 { get; set; }
    }
}
