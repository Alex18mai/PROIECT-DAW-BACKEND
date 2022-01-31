using PROIECT_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Repositories
{
    public interface IToDoTasksRepository
    {
        IQueryable<ToDoTask> GetToDoTasksIQueriable();
        IQueryable<ToDoTask> GetToDoTasksWithNotes();
        void Create(ToDoTask todotask);
        void Update(ToDoTask todotask);
        void Delete(ToDoTask todotask);
    }
}
