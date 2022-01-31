using PROIECT_DAW.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Repositories
{
    public class RemindersRepository : IRemindersRepository
    {
        private readonly ProjectContext db;

        public RemindersRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Reminder> GetRemindersIQueriable()
        {
            var reminder = db.Reminders;
            return reminder;
        }

        public void Create(Reminder reminder)
        {
            db.Reminders.Add(reminder);
            db.SaveChanges();
        }

        public void Update(Reminder reminder)
        {
            db.Reminders.Update(reminder);
            db.SaveChanges();
        }

        public void Delete(Reminder reminder)
        {
            db.Reminders.Remove(reminder);
            db.SaveChanges();
        }
    }
}
