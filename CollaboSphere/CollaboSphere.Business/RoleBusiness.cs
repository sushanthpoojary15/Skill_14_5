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
    public class RoleBusiness
    {
            private readonly IRoleRepository _roleRepository;
            public RoleBusiness(IRoleRepository roleRepository)
            {
                this._roleRepository = roleRepository;
            }

            public void AddRole(RoleModel roleModel)
            {
                Role role = new Role();
                role.RoleName = roleModel.RoleName;
                role.RoleDescription = roleModel.RoleDescription;
                

                this._roleRepository.AddRole(role);
                this._roleRepository.SaveChanges();
            }

            public void DeleteRole(int roleId)
            {
                this._roleRepository.DeleteRole(roleId);
                this._roleRepository.SaveChanges();
            }

            public RoleModel GetRole(int roleId)
            {
                var role = this._roleRepository.GetRole(roleId);
                if (role != null)
            {
                return new RoleModel
                {

                    RoleId = roleId,
                    RoleName = role.RoleName,
                    RoleDescription = role.RoleDescription,
                };
                
            }
            return null;

        }

            public List<RoleModel> GetRoles()
            {
                var roles = this._roleRepository.GetRoles();

                var roleModels = from role in roles
                                select new RoleModel
                                {
                                    RoleId = role.RoleId,
                                    RoleName = role.RoleName,
                                    RoleDescription = role.RoleDescription
                                };

                return roleModels.ToList();
            }

            public void UpdateRole(RoleModel roleModel)
            {
                Role role = new Role();
                role.RoleId = roleModel.RoleId;
                role.RoleName = roleModel.RoleName;
                role.RoleDescription = roleModel.RoleDescription;

                this._roleRepository.UpdateRole(role);
                this._roleRepository.SaveChanges();
            }
    }
 }






