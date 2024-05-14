using CollaboSphere.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.DataAccess.Contracts
{
    public interface IProjectRepository
    {
        List<Project> GetProjects();

        Project GetProject(int projectId);

        void AddProject(Project project);

        void UpdateProject(Project project);

        void DeleteProject(int projectId);

        int SaveChanges();
    }
}
