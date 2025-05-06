using Entities.Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IFavoriteFactDal : IGenericDal<FavoriteFact>
    {
        FavoriteFact GetByUserAndFact(int userId, int factId);  // Yeni metod
    }
}
