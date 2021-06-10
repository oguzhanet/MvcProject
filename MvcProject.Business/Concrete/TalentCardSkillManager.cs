using MvcProject.Business.Abstract;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Concrete
{
    public class TalentCardSkillManager : ITalentCardSkillService
    {
        private ITalentCardSkillDal _talentCardSkillDal;

        public TalentCardSkillManager(ITalentCardSkillDal talentCardSkillDal)
        {
            _talentCardSkillDal = talentCardSkillDal;
        }

        public void Add(TalentCardSkill talentCardSkill)
        {
            _talentCardSkillDal.Add(talentCardSkill);
        }

        public void Delete(TalentCardSkill talentCardSkill)
        {
            throw new NotImplementedException();
        }

        public List<TalentCardSkill> GetAll()
        {
            return _talentCardSkillDal.GetAll();
        }

        public TalentCardSkill GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TalentCardSkill talentCardSkill)
        {
            throw new NotImplementedException();
        }
    }
}
