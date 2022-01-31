using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Entities
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ToDoTaskCategory> ToDoTaskCategories { get; set; } //M-M 
    }
}
