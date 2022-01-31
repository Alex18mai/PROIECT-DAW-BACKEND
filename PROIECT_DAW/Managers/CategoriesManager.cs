using PROIECT_DAW.Entities;
using PROIECT_DAW.Models;
using PROIECT_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Managers
{
    public class CategoriesManager : ICategoriesManager
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesManager(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public List<Category> GetCategories()
        {
            return categoriesRepository.GetCategoriesIQueriable().ToList();
        }

        public Category GetCategoryById(string id)
        {
            var category = categoriesRepository
                  .GetCategoriesIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return category;
        }


        public void Create(CategoryCreationModel model)
        {
            var newCategory = new Category
            {
                Id = model.Id,
                Name = model.Name
            };

            categoriesRepository.Create(newCategory);
        }
        public void Update(CategoryCreationModel model)
        {
            var newCategory = GetCategoryById(model.Id);
            newCategory.Id = model.Id;
            newCategory.Name = model.Name;

            categoriesRepository.Update(newCategory);
        }

        public void Delete(string id)
        {
            var newCategory = GetCategoryById(id);

            categoriesRepository.Delete(newCategory);
        }
    }
}
