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
    public class RoleRepository : IRoleRepository
    {
        private readonly CollaboSphereContext _collaboSphereContext;

        public RoleRepository(CollaboSphereContext collaboSphereContext)
        {
            this._collaboSphereContext = collaboSphereContext;
        }
        public void AddRole(Role role)
        {
            this._collaboSphereContext.Roles.Add(role);
        }

        public void DeleteRole(int roleId)
        {
          var role = _collaboSphereContext.Roles.FirstOrDefault(r => r.RoleId == roleId);
            if (role != null)
            {
                _collaboSphereContext.Roles.Remove(role);       
                _collaboSphereContext.SaveChanges();
            }
        }

        public Role GetRole(int roleId)
        {
            return _collaboSphereContext.Roles.FirstOrDefault(r => r.RoleId == roleId);
        }

        public List<Role> GetRoles()
        {
            return this._collaboSphereContext.Roles.ToList();
        }

        public int SaveChanges()
        {
            return this._collaboSphereContext.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            var entityToUpdate = this._collaboSphereContext.Roles.Find(role.RoleId);
            if (entityToUpdate != null)
            {
                entityToUpdate.RoleName = role.RoleName;
                entityToUpdate.RoleDescription = role.RoleDescription;
            }
        }
    }
}









