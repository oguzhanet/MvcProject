using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface ITalentCardSkillService
    {
        List<TalentCardSkill> GetAll();
        TalentCardSkill GetById(int id);
        void Add(TalentCardSkill talentCardSkill);
        void Update(TalentCardSkill talentCardSkill);
        void Delete(TalentCardSkill talentCardSkill);
    }
}
