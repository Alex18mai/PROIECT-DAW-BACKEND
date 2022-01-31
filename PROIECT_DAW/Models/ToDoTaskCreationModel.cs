using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Models
{
    public class ToDoTaskCreationModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ToDoDate { get; set; }
        public bool DoneStatus { get; set; }
    }
}
