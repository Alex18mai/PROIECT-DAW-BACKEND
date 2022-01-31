using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Entities
{
    public class ToDoTaskCategory
    {
        public string TaskId { get; set; }
        public string CategoryId { get; set; }

        public virtual ToDoTask ToDoTask { get; set; }
        public virtual Category Category { get; set; }
    }
}
