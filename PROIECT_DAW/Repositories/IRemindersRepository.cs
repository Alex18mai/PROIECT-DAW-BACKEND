using PROIECT_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Repositories
{
    public interface IRemindersRepository
    {
        IQueryable<Reminder> GetRemindersIQueriable();
        void Create(Reminder reminder);
        void Update(Reminder reminder);
        void Delete(Reminder reminder);
    }
}
