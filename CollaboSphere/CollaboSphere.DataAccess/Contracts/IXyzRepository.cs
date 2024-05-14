using CollaboSphere.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.DataAccess.Contracts
{
    public interface IXyzRepository
    {
        List<Xyz> GetXyzs();

        Xyz GetXyz(int xyzId);

        void AddXyz(Xyz xyz);

        void UpdateXyz(Xyz xyz);

        void DeleteXyz(int xyzId);

        int SaveChanges();
    }
}
