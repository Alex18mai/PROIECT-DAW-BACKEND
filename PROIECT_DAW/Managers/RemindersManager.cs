using PROIECT_DAW.Entities;
using PROIECT_DAW.Models;
using PROIECT_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Managers
{
    public class RemindersManager : IRemindersManager
    {
        private readonly IRemindersRepository remindersRepository;

        public RemindersManager(IRemindersRepository remindersRepository)
        {
            this.remindersRepository = remindersRepository;
        }

        public List<Reminder> GetReminders()
        {
            return remindersRepository.GetRemindersIQueriable().ToList();
        }

        public Reminder GetReminderById(string id)
        {
            var reminder = remindersRepository
                  .GetRemindersIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return reminder;
        }


        public void Create(ReminderCreationModel model)
        {
            var newReminder = new Reminder
            {
                Id = model.Id,
                Text = model.Text,
                RemindDate = model.RemindDate,
                ToDoTaskId = model.ToDoTaskId
            };

            remindersRepository.Create(newReminder);
        }
        public void Update(ReminderCreationModel model)
        {
            var newReminder = GetReminderById(model.Id);
            newReminder.Id = model.Id;
            newReminder.Text = model.Text;
            newReminder.RemindDate = model.RemindDate;
            newReminder.ToDoTaskId = model.ToDoTaskId;

            remindersRepository.Update(newReminder);
        }

        public void Delete(string id)
        {
            var newReminder = GetReminderById(id);

            remindersRepository.Delete(newReminder);
        }
    }
}
