using PROIECT_DAW.Entities;
using PROIECT_DAW.Models;
using PROIECT_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Managers
{
    public class ToDoTasksManager : IToDoTasksManager
    {
        private readonly IToDoTasksRepository todotasksRepository;

        public ToDoTasksManager(IToDoTasksRepository todotasksRepository)
        {
            this.todotasksRepository = todotasksRepository;
        }

        public List<ToDoTask> GetToDoTasks()
        {
            return todotasksRepository.GetToDoTasksIQueriable().ToList();
        }

        public ToDoTask GetToDoTaskById(string id)
        {
            var todotasks = todotasksRepository
                  .GetToDoTasksIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return todotasks;
        }

        public List<ToDoTask> GetToDoTasksOrderedAsc()
        {
            var todotasks = todotasksRepository.GetToDoTasksWithNotes()
               .OrderBy(x => x.Name)
               .ToList();
            return todotasks;
        }

        public List<NumberOfTasks> GetNumberOfToDoTasks()
        {
            var numberoftasks = todotasksRepository
                  .GetToDoTasksIQueriable()
                  .GroupBy(x => x.Name,
                  (k, c) => new NumberOfTasks()
                  {
                      Name = k,
                      Number = c.Count()
                  })
                  .ToList();
            return numberoftasks;
        }


        public void Create(ToDoTaskCreationModel model)
        {
            var newToDoTask = new ToDoTask
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ToDoDate = model.ToDoDate,
                DoneStatus = model.DoneStatus
            };

            todotasksRepository.Create(newToDoTask);
        }
        public void Update(ToDoTaskCreationModel model)
        {
            var newToDoTask = GetToDoTaskById(model.Id);
            newToDoTask.Id = model.Id;
            newToDoTask.Name = model.Name;
            newToDoTask.Description = model.Description;
            newToDoTask.ToDoDate = model.ToDoDate;
            newToDoTask.DoneStatus = model.DoneStatus;

            todotasksRepository.Update(newToDoTask);
        }

        public void Delete(string id)
        {
            var newToDoTask = GetToDoTaskById(id);

            todotasksRepository.Delete(newToDoTask);
        }
    }
}
