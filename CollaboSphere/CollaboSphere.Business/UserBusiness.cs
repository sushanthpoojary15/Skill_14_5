using CollaboSphere.Common.Model;
using CollaboSphere.DataAccess.Contracts;
using CollaboSphere.DataAccess.Entities;
using Microsoft.Identity.Client;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = CollaboSphere.DataAccess.Entities.User;

namespace CollaboSphere.Business
{
    public class UserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Response AddUser(UserModel userModel)
        {

            Response res = new Response();
            try
            {
                User user = new User();
            user.UserId = userModel.UserId;
            user.RoleId = userModel.RoleId;
            user.Username = userModel.Username;
            user.Email = userModel.Email;
            user.Password = userModel.Password == string.Empty ? "default" : userModel.Password;
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.LastLogin = userModel.LastLogin;
            user.IsActive = userModel.IsActive;

            this._userRepository.AddUser(user);
            this._userRepository.SaveChanges();
                res.ResponseMessage = "Successfully Added User";
                res.ResponseStatusCode = "200";
            }
            catch (Exception ex)
            {

                res.ResponseMessage = ex.Message;
                res.ResponseStatusCode = "500";
            }
            return res;
        }

        public Response DeleteUser(int userId)
        {

            Response res = new Response();
            try
            {
                this._userRepository.DeleteUser(userId);
                this._userRepository.SaveChanges();
                res.ResponseMessage = "Successfully Deleted User";
                res.ResponseStatusCode = "200";
            }
            catch (Exception ex)
            {

                res.ResponseMessage = ex.Message;
                res.ResponseStatusCode = "500";
            }
            return res;
        }

        public Response GetUser(int userId)
        {
            Response res = new Response();
            
            try
            {

                var user = this._userRepository.GetUser(userId);

                if (user != null)
                {
                    res.Result = new UserModel
                    {
                        Username = user.Username,
                        Email = user.Email,
                        UserId = user.UserId,
                        RoleId = user.RoleId,
                        Password = user.Password,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        LastLogin = user.LastLogin,
                        IsActive = user.IsActive
                    };
                    res.ResponseMessage = "Successfully fetched the data";
                    res.ResponseStatusCode = "200";
                    return res;

                }
                res.ResponseMessage = "Unable to fetch data";
                res.ResponseStatusCode = "200";

            }
            catch (Exception ex)
            {
                res.ResponseMessage = ex.Message;
                res.ResponseStatusCode = "500";
            }
            return res;

        }

        public UserModel GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetUsers()
        {
            var users = this._userRepository.GetUsers();
            var userModels = from user in users
                             select new UserModel
                             {
                                 Username = user.Username,
                                 Email = user.Email,
                                 UserId = user.UserId,
                                 RoleId = user.RoleId,
                                 Password = user.Password,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 LastLogin = user.LastLogin,
                                 IsActive = user.IsActive,

                             };
            return userModels.ToList();
        }

        public Response UpdateUser(UserModel userModel)
        {
            Response res = new Response();
            try
            {


                User user = new User();
                user.Username = userModel.Username;
                user.Email = userModel.Email;
                user.UserId = userModel.UserId;
                user.RoleId = userModel.RoleId;
                user.Password = userModel.Password;
                user.FirstName = user.FirstName;
                user.LastName = user.LastName;
                user.LastLogin = userModel.LastLogin;
                user.IsActive = userModel.IsActive;


                this._userRepository.UpdateUser(user);
                this._userRepository.SaveChanges();
                res.ResponseMessage ="Successfully updated User";
                res.ResponseStatusCode = "200";
            }
            catch (Exception ex)
            {

                res.ResponseMessage = ex.Message;
                res.ResponseStatusCode = "500";
            }
            return res;

        }

        //public User ValidateCredentials(UsreModel usreModel)
        //{
        //    var user = _userRepository.GetUserByUsername(username)

        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    if(!user.VerifyPassword(password))
        //    {
        //        return null;
        //    }
        //    return user;
        //}
    }
}
