using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repositories;
using Entities.Entities;

namespace DataAccess.Ef
{
    public class EfCompletedTopicDal : GenericRepository<CompletedTopic>, ICompletedTopicDal
    {
        public EfCompletedTopicDal(StudyFlowApiDbContext context) : base(context)
        {
        }
    }
}
