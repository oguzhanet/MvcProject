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
    public class TalentCardManager : ITalentCardService
    {
        private ITalentCardDal _talentCardDal;

        public TalentCardManager(ITalentCardDal talentCardDal)
        {
            _talentCardDal = talentCardDal;
        }

        public void Add(TalentCard talentCard)
        {
            _talentCardDal.Add(talentCard);
        }

        public void Delete(TalentCard talentCard)
        {
            throw new NotImplementedException();
        }

        public List<TalentCard> GetAll()
        {
            return _talentCardDal.GetAll();
        }

        public TalentCard GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TalentCard talentCard)
        {
            throw new NotImplementedException();
        }
    }
}
