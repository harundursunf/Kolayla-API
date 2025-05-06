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
    public class EfNoteDal : GenericRepository<Note>, INoteDal
    {
        public EfNoteDal(StudyFlowApiDbContext context) : base(context)
        {
        }
    }
}
