using CollaboSphere.Business;
using CollaboSphere.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollaboSphere.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;
        public UserController(UserBusiness userBusiness)
        {
            this._userBusiness = userBusiness;
        }

        [HttpPost]
        public Response AddUser(UserModel userModel)
        {
            Response res = new Response();
            if (userModel.UserId == 0)
            {
                 res=this._userBusiness.AddUser(userModel);
            }
            else
            {
               res= this._userBusiness.UpdateUser(userModel);
            }
            return res;
        }

        [HttpPost("UpdateUser")]
        public Response UpdateUser(UserModel userModel)
        {
            Response res = new Response();
            if (userModel.UserId == 0)
            {
               res= this._userBusiness.AddUser(userModel);
            }
            else
            {
                res=this._userBusiness.UpdateUser(userModel);
            }
            return res;
        }

        [HttpGet]
        public List<UserModel> GetUsers()
        {

            return this._userBusiness.GetUsers();
        }

        [HttpGet("{userId:int}")]
        public Response GetUser(int userId)
        {
            return this._userBusiness.GetUser(userId);
        }

        [HttpDelete]
        public Response DeleteUser(int userId)
        {
            return this._userBusiness.DeleteUser(userId);
        }

    }
}
