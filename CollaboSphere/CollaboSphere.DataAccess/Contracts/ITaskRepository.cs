using CollaboSphere.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CollaboSphere.DataAccess.Entities.Task;

namespace CollaboSphere.DataAccess.Contracts
{
    public interface ITaskRepository
    { 
        List<Task> GetTasks();

        Task GetTask(int taskId);

        void AddTask(Task task);

        void UpdateTask(Task task);

        void DeleteTask(int taskId);

        int SaveChanges();
    }
}

