using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Ef
{
    public class EfTopicDal : GenericRepository<Topic>, ITopicDal
    {
        public EfTopicDal(StudyFlowApiDbContext context) : base(context)
        {
        }
    }
}
