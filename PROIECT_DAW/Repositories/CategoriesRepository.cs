using PROIECT_DAW.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ProjectContext db;

        public CategoriesRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Category> GetCategoriesIQueriable()
        {
            var category = db.Categories;
            return category;
        }

        public void Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void Update(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
        }

        public void Delete(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }
    }
}
