using CollaboSphere.DataAccess.Contracts;
using CollaboSphere.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.DataAccess
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly CollaboSphereContext _collaboSphereContext;

        public ProjectRepository(CollaboSphereContext collaboSphereContext)
        {
            this._collaboSphereContext = collaboSphereContext;
        }
        public void AddProject(Project project)
        {
            this._collaboSphereContext.Projects.Add(project);
        }

        public void DeleteProject(int projectId)
        {
            var entityToBeDeleted = this._collaboSphereContext.Projects.Where(c => c.ProjectId == projectId).FirstOrDefault();
            if (entityToBeDeleted != null)
            {
                var entry = this._collaboSphereContext.Entry(entityToBeDeleted);
                entry.State = EntityState.Deleted;
            }
        }

        public Project GetProject(int projectId)
        {
            var entityToBeFetched = this._collaboSphereContext.Projects.Where(c => c.ProjectId == projectId).FirstOrDefault();
            return entityToBeFetched;
        }

        public List<Project> GetProjects()
        {
            return this._collaboSphereContext.Projects.ToList();
        }

        public int SaveChanges()
        {
            return this._collaboSphereContext.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            var entityToUpdate = this._collaboSphereContext.Projects.Find(project.ProjectId);
            if (entityToUpdate != null)
            {
                entityToUpdate.ProjectId = project.ProjectId;
                entityToUpdate.ProjectName = project.ProjectName;
                entityToUpdate.ProjectDescription = project.ProjectDescription;
                entityToUpdate.StartDate = project.StartDate;
                entityToUpdate.EndDate = project.EndDate;
                entityToUpdate.Status = project.Status;
                entityToUpdate.ProjectManagerId = project.ProjectManagerId;
            }
        }
    }
}
