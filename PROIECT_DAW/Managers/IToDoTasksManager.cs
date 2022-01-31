using PROIECT_DAW.Entities;
using PROIECT_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Managers
{
    public interface IToDoTasksManager
    {
        List<ToDoTask> GetToDoTasks();
        ToDoTask GetToDoTaskById(string id);
        List<ToDoTask> GetToDoTasksOrderedAsc();
        List<NumberOfTasks> GetNumberOfToDoTasks();

        void Create(ToDoTaskCreationModel model);
        void Update(ToDoTaskCreationModel model);
        void Delete(string id);
    }
}
