using CollaboSphere.Business;
using CollaboSphere.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollaboSphere.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XyzController : ControllerBase
    {
        private readonly XyzBusiness _xyzBusiness;
        public XyzController(XyzBusiness xyzBusiness)
        {
            this._xyzBusiness = xyzBusiness;
        }

        [HttpPost]
        public void AddOrUpdateXyz(XyzModel xyzModel)
        {
            if (xyzModel.Id == 0)
            {
                this._xyzBusiness.AddXyz(xyzModel);
            }
            else
            {
                this._xyzBusiness.UpdateXyz(xyzModel);
            }
        }

        [HttpGet]
        public List<XyzModel> GetXyzs()
        {
            return this._xyzBusiness.GetXyzs();
        }

        [HttpGet("{xyzId:int}")]
        public XyzModel GetXyz(int xyzId)
        {
            return this._xyzBusiness.GetXyz(xyzId);
        }

        [HttpDelete]
        public void DeleteXyz(int xyzId)
        {
            this._xyzBusiness.DeleteXyz(xyzId);
        }
    }
}
