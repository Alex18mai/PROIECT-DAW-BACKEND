using PROIECT_DAW.Entities;
using PROIECT_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Managers
{
    public interface INotesManager
    {
        List<Note> GetNotes();
        Note GetNoteById(string id);

        void Create(NoteCreationModel model);
        void Update(NoteCreationModel model);
        void Delete(string id);
    }
}
