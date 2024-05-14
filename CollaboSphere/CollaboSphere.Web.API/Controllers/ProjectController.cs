using CollaboSphere.Business;
using CollaboSphere.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollaboSphere.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectBusiness _projectBusiness;
        public ProjectController(ProjectBusiness projectBusiness)
        {
            this._projectBusiness = projectBusiness;
        }

        [HttpPost]
        public void AddOrUpdateProject(ProjectModel projectModel)
        {
            if (projectModel.ProjectId == 0)
            {
                this._projectBusiness.AddProject(projectModel);
            }
            else
            {
                this._projectBusiness.UpdateProject(projectModel);
            }
        }

        [HttpGet]
        public List<ProjectModel> GetProjects()
        {
            return this._projectBusiness.GetProjects();
        }

        [HttpGet("{projectId:int}")]
        public ProjectModel GetProject(int projectId)
        {
            return this._projectBusiness.GetProject(projectId);
        }

        [HttpDelete]
        public void DeleteProject(int projectId)
        {
            this._projectBusiness.DeleteProject(projectId);
        }
    }
}
