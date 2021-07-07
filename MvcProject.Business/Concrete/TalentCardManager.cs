using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
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

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<TalentCard> GetAll()
        {
            return _talentCardDal.GetAll();
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(TalentCard talentCard)
        {
            _talentCardDal.Add(talentCard);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(TalentCard talentCard)
        {
            _talentCardDal.Update(talentCard);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(TalentCard talentCard)
        {
            _talentCardDal.Delete(talentCard);
        }

        public TalentCard GetById(int id)
        {
            return _talentCardDal.Get(x => x.CardId == id);
        }
    }
}
