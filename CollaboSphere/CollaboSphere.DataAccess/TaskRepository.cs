using CollaboSphere.DataAccess.Contracts;
using CollaboSphere.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CollaboSphere.DataAccess.Entities.Task;


namespace CollaboSphere.DataAccess
{
        public class TaskRepository : ITaskRepository
        {
            private readonly CollaboSphereContext _collaboSphereContext;


        public TaskRepository(CollaboSphereContext collaboSphereContext)
            {
                this._collaboSphereContext = collaboSphereContext;
            }
            public void AddTask(Task task)
            {
                this._collaboSphereContext.Tasks.Add(task);
            }

        public void DeleteTask(int taskId)
            {
                var entityToBeDeleted = this._collaboSphereContext.Tasks.Where(c => c.TaskId == taskId).FirstOrDefault();
                if (entityToBeDeleted != null)
                {
                    var entry = this._collaboSphereContext.Entry(entityToBeDeleted);
                    entry.State = EntityState.Deleted;
                }
            }

            public Task GetTask(int taskId)
            {
                var entityToBeFetched = this._collaboSphereContext.Tasks.Where(c => c.TaskId == taskId).FirstOrDefault();
                return entityToBeFetched;
            }

            public List<Task> GetTasks()
            {
                return this._collaboSphereContext.Tasks.ToList();
            }

            public int SaveChanges()
            {
                return this._collaboSphereContext.SaveChanges();
            }

            public void UpdateTask(Task task)
            {
                var entityToUpdate = this._collaboSphereContext.Tasks.Find(task.TaskId);
                if (entityToUpdate != null)
                {
                    entityToUpdate.TaskId = task.TaskId;
                    entityToUpdate.TaskName = task.TaskName;
                }
            }

       
    }
 }
    

