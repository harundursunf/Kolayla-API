using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repositories;
using Entities.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Ef
{
    public class EfCompletedTopicDal : GenericRepository<CompletedTopic>, ICompletedTopicDal
    {
        private readonly StudyFlowApiDbContext _context;

        public EfCompletedTopicDal(StudyFlowApiDbContext context) : base(context)
        {
            _context = context;
        }

        public CompletedTopic Get(Expression<Func<CompletedTopic, bool>> filter)
        {
            return _context.CompletedTopics.FirstOrDefault(filter);
        }
    }
}
