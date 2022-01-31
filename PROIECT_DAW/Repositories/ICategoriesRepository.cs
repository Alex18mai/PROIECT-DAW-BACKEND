using PROIECT_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Repositories
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> GetCategoriesIQueriable();
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
