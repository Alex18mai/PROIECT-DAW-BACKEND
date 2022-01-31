using PROIECT_DAW.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly ProjectContext db;

        public NotesRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Note> GetNotesIQueriable()
        {
            var note = db.Notes;
            return note;
        }

        public void Create(Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
        }

        public void Update(Note note)
        {
            db.Notes.Update(note);
            db.SaveChanges();
        }

        public void Delete(Note note)
        {
            db.Notes.Remove(note);
            db.SaveChanges();
        }
    }
}
