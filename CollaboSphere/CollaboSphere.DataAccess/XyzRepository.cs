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
    public class XyzRepository : IXyzRepository
    {
        private readonly CollaboSphereContext _collaboSphereContext;

        public XyzRepository(CollaboSphereContext collaboSphereContext)
        {
            this._collaboSphereContext = collaboSphereContext;
        }
        public void AddXyz(Xyz xyz)
        {
            this._collaboSphereContext.Xyzs.Add(xyz);
        }

        public void DeleteXyz(int xyzId)
        {
            var entityToBeDeleted = this._collaboSphereContext.Xyzs.Where(c => c.Id == xyzId).FirstOrDefault();
            if (entityToBeDeleted != null)
            {
                var entry = this._collaboSphereContext.Entry(entityToBeDeleted);
                entry.State = EntityState.Deleted;
            }
        }

        public Xyz GetXyz(int xyzId)
        {
            var entityToBeFetched = this._collaboSphereContext.Xyzs.Where(c => c.Id == xyzId).FirstOrDefault();
            return entityToBeFetched;
        }

        public List<Xyz> GetXyzs()
        {
            return this._collaboSphereContext.Xyzs.ToList();
        }

        public int SaveChanges()
        {
            return this._collaboSphereContext.SaveChanges();
        }

        public void UpdateXyz(Xyz xyz)
        {
            var entityToUpdate = this._collaboSphereContext.Xyzs.Find(xyz.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Column1 = xyz.Column1;
                entityToUpdate.Column2 = xyz.Column2;
            }
        }
    }
}
