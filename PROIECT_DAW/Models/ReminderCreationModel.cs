using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Models
{
    public class ReminderCreationModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime RemindDate { get; set; }

        public string ToDoTaskId { get; set; }
    }
}
