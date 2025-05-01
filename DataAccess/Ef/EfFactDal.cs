using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Ef
{
    public class EfFactDal : GenericRepository<Fact>, IFactDal

    {
        public EfFactDal(DbContext context) : base(context)
        {
        }
    }
}
