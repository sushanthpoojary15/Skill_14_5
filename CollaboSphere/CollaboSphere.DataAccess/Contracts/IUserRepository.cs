
using CollaboSphere.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.DataAccess.Contracts
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        User GetUser(int userId);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int userId);

        void AssignUserToRole(int userId, int roleId);
        int SaveChanges();
    }
}
