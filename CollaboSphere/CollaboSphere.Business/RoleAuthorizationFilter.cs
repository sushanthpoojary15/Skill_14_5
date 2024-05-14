using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.Business
{
    public class RoleAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"] as JwtSecurityToken;
            var role = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (role == null || role != "Admin") 
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
