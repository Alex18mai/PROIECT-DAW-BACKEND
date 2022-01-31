using PROIECT_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Repositories
{
    public interface INotesRepository
    {
        IQueryable<Note> GetNotesIQueriable();
        void Create(Note note);
        void Update(Note note);
        void Delete(Note note);
    }
}
