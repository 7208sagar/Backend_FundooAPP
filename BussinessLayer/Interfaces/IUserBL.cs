using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface IUserBL
    {
        bool Registration(UserRegistration user);
        LoginResponse UserLogin(UserLogin user1);
        IEnumerable<User> GetAlldata();
        bool SendResetLink(string email);
        //public bool SendEmail(string emailAddress);
    }
}
