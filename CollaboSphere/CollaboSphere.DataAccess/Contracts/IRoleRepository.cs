using CollaboSphere.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.DataAccess.Contracts
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();

        Role GetRole(int roleId);

        void AddRole(Role role);

        void UpdateRole(Role role);

        void DeleteRole(int roleId);

        int SaveChanges();
    }
}




