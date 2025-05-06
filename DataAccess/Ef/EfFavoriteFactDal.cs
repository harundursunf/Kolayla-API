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
    public class EfFavoriteFactDal : GenericRepository<FavoriteFact>, IFavoriteFactDal
    {
        public EfFavoriteFactDal(StudyFlowApiDbContext context) : base(context)
        {
        }

        public FavoriteFact GetByUserAndFact(int userId, int factId)
        {
            return _context.Set<FavoriteFact>()
                .FirstOrDefault(f => f.UserId == userId && f.FactId == factId);
        }
    }
}
