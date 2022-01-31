using PROIECT_DAW.Entities;
using PROIECT_DAW.Models;
using PROIECT_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Managers
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository notesRepository;

        public NotesManager(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public List<Note> GetNotes()
        {
            return notesRepository.GetNotesIQueriable().ToList();
        }

        public Note GetNoteById(string id)
        {
            var note = notesRepository
                  .GetNotesIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return note;
        }


        public void Create(NoteCreationModel model)
        {
            var newNote = new Note
            {
                Id = model.Id,
                Title = model.Title,
                Details = model.Details,
                ToDoTaskId = model.ToDoTaskId
            };

            notesRepository.Create(newNote);
        }
        public void Update(NoteCreationModel model)
        {
            var newNote = GetNoteById(model.Id);
            newNote.Id = model.Id;
            newNote.Title = model.Title;
            newNote.Details = model.Details;
            newNote.ToDoTaskId = model.ToDoTaskId;

            notesRepository.Update(newNote);
        }

        public void Delete(string id)
        {
            var newNote = GetNoteById(id);

            notesRepository.Delete(newNote);
        }
    }
}
