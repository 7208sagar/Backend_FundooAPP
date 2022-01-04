using BussinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositoryLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }    
        public LoginResponse UserLogin(UserLogin user1)
        {
            try
            {
                return this.userRL.UserLogin(user1);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool Registration(UserRegistration user)
        {
            try
            {
                return this.userRL.Registration(user);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public IEnumerable<User> GetAlldata()
        {
            return this.userRL.GetAlldata();
        }

        public bool SendResetLink(string email)
        {
            return this.userRL.SendResetLink(email);
        }

        //public bool SendEmail(string emailAddress)
        //{
        //    try
        //    {
        //        bool result = this.userRL.SendEmail(emailAddress);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}

