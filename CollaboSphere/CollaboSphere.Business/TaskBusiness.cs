using CollaboSphere.Common.Model;
using CollaboSphere.DataAccess.Contracts;
using CollaboSphere.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CollaboSphere.DataAccess.Entities.Task;

namespace CollaboSphere.Business
{
    public class TaskBusiness
    {
        private readonly ITaskRepository _taskRepository;
        public TaskBusiness(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        public void AddTask(TaskModel taskModel)
        {
            Task task = new Task();
            task.TaskId = taskModel.TaskId;
            task.TaskName = taskModel.TaskName;

            this._taskRepository.AddTask(task);
            this._taskRepository.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            this._taskRepository.DeleteTask(taskId);
            this._taskRepository.SaveChanges();
        }

        public TaskModel GetTask(int taskId)
        {
            var task = this._taskRepository.GetTask(taskId);
            return new TaskModel
            {
                TaskId = task.TaskId,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription
            };
        }

        public List<TaskModel> GetTasks()
        {
            var tasks = this._taskRepository.GetTasks();

            var taskModels = from task in tasks
                            select new TaskModel
                            {
                                TaskId = task.TaskId,
                                TaskName = task.TaskName,
                                TaskDescription = task.TaskDescription
                            };

            return taskModels.ToList();
        }

        public void UpdateTask(TaskModel taskModel)
        {
            Task task = new Task();
            task.TaskId = taskModel.TaskId;
            task.TaskName = taskModel.TaskName;
            task.TaskDescription = taskModel.TaskDescription;

            this._taskRepository.UpdateTask(task);
            this._taskRepository.SaveChanges();
        }
    }
}

