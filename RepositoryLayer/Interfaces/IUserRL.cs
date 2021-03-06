using CommonLayer.Model;
using CommonLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        bool Registration(UserRegistration user);
        LoginResponse UserLogin(UserLogin user1);
        IEnumerable<User> GetAlldata();
        bool SendResetLink(string email);
        bool ResetPassword(ResetPassword resetPassword);
    }
}
