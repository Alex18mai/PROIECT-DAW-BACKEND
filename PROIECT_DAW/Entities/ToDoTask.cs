using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Entities
{
    public class ToDoTask
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ToDoDate { get; set; }
        public bool DoneStatus { get; set; }


        public virtual Reminder Reminder { get; set; } //1-1
        public virtual ICollection<Note> Notes { get; set; } //1-M
        public virtual ICollection<ToDoTaskCategory> ToDoTaskCategories { get; set; } //M-M 
    }
}

//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False