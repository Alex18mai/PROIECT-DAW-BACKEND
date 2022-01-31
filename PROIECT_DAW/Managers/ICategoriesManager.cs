using PROIECT_DAW.Entities;
using PROIECT_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Managers
{
    public interface ICategoriesManager
    {
        List<Category> GetCategories();
        Category GetCategoryById(string id);

        void Create(CategoryCreationModel model);
        void Update(CategoryCreationModel model);
        void Delete(string id);
    }
}
