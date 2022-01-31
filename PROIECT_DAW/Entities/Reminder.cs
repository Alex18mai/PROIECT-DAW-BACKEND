using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Entities
{
    public class Reminder
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime RemindDate { get; set; }
        
        public string ToDoTaskId { get; set; } //FK ToDoTask
        public virtual ToDoTask ToDoTask { get; set; } //1-1
    }
}
