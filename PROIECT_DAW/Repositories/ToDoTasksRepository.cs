using PROIECT_DAW.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Repositories
{
    public class ToDoTasksRepository : IToDoTasksRepository
    {
        private readonly ProjectContext db;

        public ToDoTasksRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<ToDoTask> GetToDoTasksIQueriable()
        {
            var todotask = db.ToDoTasks;
            return todotask;
        }
        public IQueryable<ToDoTask> GetToDoTasksWithNotes()
        {
            var todotask = db.ToDoTasks.Include(x => x.ToDoTaskCategories).Include(y => y.Notes)
                .Join(db.Reminders, todotask => todotask.Id, reminder => reminder.ToDoTaskId,
                (todotask, reminder) => new ToDoTask 
                { 
                    Id = todotask.Id,
                    Name = todotask.Name,
                    Description = todotask.Description,
                    ToDoDate = todotask.ToDoDate,
                    DoneStatus = todotask.DoneStatus,
                    ToDoTaskCategories = todotask.ToDoTaskCategories,
                    Notes = todotask.Notes,
                    Reminder = reminder
                });
            return todotask;
        }

        public void Create(ToDoTask todotask)
        {
            db.ToDoTasks.Add(todotask);
            db.SaveChanges();
        }

        public void Update(ToDoTask todotask)
        {
            db.ToDoTasks.Update(todotask);
            db.SaveChanges();
        }

        public void Delete(ToDoTask todotask)
        {
            db.ToDoTasks.Remove(todotask);
            db.SaveChanges();
        }
    }
}
