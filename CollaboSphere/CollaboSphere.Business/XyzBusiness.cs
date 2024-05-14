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
    public class XyzBusiness
    {
        private readonly IXyzRepository _xyzRepository;
        public XyzBusiness(IXyzRepository xyzRepository)
        {
            this._xyzRepository = xyzRepository;
        }

        public void AddXyz(XyzModel xyzModel)
        {
            Xyz xyz = new Xyz();
            xyz.Column1 = xyzModel.Column1;
            xyz.Column2 = xyzModel.Column2;

            this._xyzRepository.AddXyz(xyz);
            this._xyzRepository.SaveChanges();
        }

        public void DeleteXyz(int xyzId)
        {
            this._xyzRepository.DeleteXyz(xyzId);
            this._xyzRepository.SaveChanges();
        }

        public XyzModel GetXyz(int xyzId)
        {
            var xyz = this._xyzRepository.GetXyz(xyzId);
            return new XyzModel
            {
                Id = xyz.Id,
                Column1 = xyz.Column1,
                Column2 = xyz.Column2
            };
        }

        public List<XyzModel> GetXyzs()
        {
            var xyzs = this._xyzRepository.GetXyzs();

            var xyzModels = from xyz in xyzs
                            select new XyzModel
                            {
                                Id = xyz.Id,
                                Column1 = xyz.Column1,
                                Column2 = xyz.Column2
                            };

            return xyzModels.ToList();
        }

        public void UpdateXyz(XyzModel xyzModel)
        {
            Xyz xyz = new Xyz();
            xyz.Id = xyzModel.Id;
            xyz.Column1 = xyzModel.Column1;
            xyz.Column2 = xyzModel.Column2;

            this._xyzRepository.UpdateXyz(xyz);
            this._xyzRepository.SaveChanges();
        }
    }
}
