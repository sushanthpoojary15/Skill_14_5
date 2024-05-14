using CollaboSphere.Business;
using CollaboSphere.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollaboSphere.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleBusiness _roleBusiness;
        public RoleController(RoleBusiness roleBusiness)
        {
            this._roleBusiness = roleBusiness;
        }

        [HttpPost]
        public void AddOrUpdateRole(RoleModel roleModel)
        {
            if (roleModel.RoleId == 0)
            {
                this._roleBusiness.AddRole(roleModel);
            }
            else
            {
                this._roleBusiness.UpdateRole(roleModel);
            }
        }
        [HttpGet]
        public List<RoleModel> GetRoles()
        {
            return this._roleBusiness.GetRoles();
        }

        [HttpGet("{roleId:int}")]
        public RoleModel Getrole(int roleId)
        {
            return this._roleBusiness.GetRole(roleId);
        }

        [HttpDelete]
        public void DeleteRole(int roleId)
        {
            this._roleBusiness.DeleteRole(roleId);
        }

    }
}


