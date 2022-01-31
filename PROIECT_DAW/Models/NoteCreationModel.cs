using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Models
{
    public class NoteCreationModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public string ToDoTaskId { get; set; }
    }
}
