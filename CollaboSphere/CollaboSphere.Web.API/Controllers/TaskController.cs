using CollaboSphere.Business;
using CollaboSphere.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollaboSphere.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskBusiness _taskBusiness;
        public TaskController(TaskBusiness taskBusiness)
        {
            this._taskBusiness = taskBusiness;
        }

        [HttpPost]
        public void AddOrUpdateTask(TaskModel taskModel)
        {
            if (taskModel.TaskId == 0)
            {
                this._taskBusiness.AddTask(taskModel);
            }
            else
            {
                this._taskBusiness.UpdateTask(taskModel);
            }
        }

        [HttpGet]
        public List<TaskModel> GetTasks()
        {
            return this._taskBusiness.GetTasks();
        }

        [HttpGet("{taskId:int}")]
        public TaskModel GetTask(int taskId)
        {
            return this._taskBusiness.GetTask(taskId);
        }

        [HttpDelete]
        public void DeleteTask(int taskId)
        {
            this._taskBusiness.DeleteTask(taskId);
        }
    }
}

