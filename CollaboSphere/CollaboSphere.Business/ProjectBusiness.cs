using CollaboSphere.Common.Model;
using CollaboSphere.DataAccess.Contracts;
using CollaboSphere.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.Business
{
    public class ProjectBusiness
    {

            private readonly IProjectRepository _projectRepository;
            public ProjectBusiness(IProjectRepository projectRepository)
            {
                this._projectRepository = projectRepository;
            }

            public void AddProject(ProjectModel projectModel)
            {
                Project project = new Project();
                project.ProjectId = projectModel.ProjectId;
                project.ProjectName = projectModel.ProjectName;
                project.ProjectDescription = projectModel.ProjectDescription;
                project.StartDate= projectModel.StartDate;
                project.EndDate= projectModel.EndDate;
                project.Status = projectModel.Status;
                project.ProjectManagerId= projectModel.ProjectManagerId;

                this._projectRepository.AddProject(project);
                this._projectRepository.SaveChanges();
            }

            public void DeleteProject(int projectId)
            {
                this._projectRepository.DeleteProject(projectId);
                this._projectRepository.SaveChanges();
            }

            public ProjectModel GetProject(int projectId)
            {
                var project = this._projectRepository.GetProject(projectId);
                return new ProjectModel
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                    ProjectDescription=project.ProjectDescription,
                    StartDate=project.StartDate,
                    EndDate=project.EndDate,
                    Status = project.Status,
                    ProjectManagerId=project.ProjectManagerId
                };
            }

            public List<ProjectModel> GetProjects()
            {
                var projects = this._projectRepository.GetProjects();

                var projectModels = from project in projects
                                select new ProjectModel
                                {
                                    ProjectId = project.ProjectId,
                                    ProjectName = project.ProjectName,
                                    ProjectDescription = project.ProjectDescription,
                                    StartDate = project.StartDate,
                                    EndDate = project.EndDate,
                                    Status = project.Status,
                                    ProjectManagerId = project.ProjectManagerId
                                };

                return projectModels.ToList();
            }

            public void UpdateProject(ProjectModel projectModel)
            {
                Project project = new Project();
                project.ProjectId = projectModel.ProjectId;
                project.ProjectName = projectModel.ProjectName;
                project.ProjectDescription = projectModel.ProjectDescription;
                project.StartDate = projectModel.StartDate;
                project.EndDate = projectModel.EndDate;
                project.Status = projectModel.Status;
                project.ProjectManagerId = projectModel.ProjectManagerId;

                this._projectRepository.UpdateProject(project);
                this._projectRepository.SaveChanges();
            }
        }
}
