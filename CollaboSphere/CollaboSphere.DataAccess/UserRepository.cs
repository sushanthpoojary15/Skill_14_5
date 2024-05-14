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
    public class UserRepository : IUserRepository
    {
        private readonly CollaboSphereContext _collaboSphereContext;

        public UserRepository()
        {
            _collaboSphereContext = new CollaboSphereContext();
        }

        public void AddUser(User user)
        {
            this._collaboSphereContext.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            var userToBeDeleted = this._collaboSphereContext.Users.Where(c => c.UserId == userId).ToList();
            if (userToBeDeleted != null)
            {
                var entry = this._collaboSphereContext.Entry(userId);
                entry.State = EntityState.Deleted;
            }
        }

        public User GetUser(int userId)
        {
            var userToBeFetched = this._collaboSphereContext.Users.FirstOrDefault(u => u.UserId == userId);
            return userToBeFetched;
        }


        public List<User> GetUsers()
        {
            return this._collaboSphereContext.Users.ToList();
        }

        public int SaveChanges()
        {
            return this._collaboSphereContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var userToUpdate = this._collaboSphereContext.Users.Find(user.UserId);
            if (userToUpdate != null)
            {
                userToUpdate.Username = user.Username;
                userToUpdate.Password = user.Password;
                userToUpdate.Role = user.Role;
                userToUpdate.RoleId = user.RoleId;
                userToUpdate.Email = user.Email;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Documents = user.Documents;
                userToUpdate.LastLogin = user.LastLogin;
                userToUpdate.IsActive = user.IsActive;

            }
        }
        public void AssignUserToRole(int userId, int roleId)
        {
            var assignuser = this._collaboSphereContext.Users.Where(c => c.UserId == userId).FirstOrDefault();
            if (assignuser != null)
            {
                assignuser.RoleId = roleId;
                this._collaboSphereContext.SaveChanges();
            }
    
        }
    }
}