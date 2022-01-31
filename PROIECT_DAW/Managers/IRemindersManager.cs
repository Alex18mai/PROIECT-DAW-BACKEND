using PROIECT_DAW.Entities;
using PROIECT_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Managers
{
    public interface IRemindersManager
    {
        List<Reminder> GetReminders();
        Reminder GetReminderById(string id);

        void Create(ReminderCreationModel model);
        void Update(ReminderCreationModel model);
        void Delete(string id);
    }
}
