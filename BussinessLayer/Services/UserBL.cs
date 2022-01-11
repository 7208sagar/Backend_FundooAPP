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
    /// <summary>
    /// This is a class for UserBL
    /// </summary>
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        /// <summary>
        /// Initializes a new instance of the UserBL class
        /// </summary>
        /// <param name="userRL"></param>
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        /// <summary>
        /// This methods implements the Register for user functionality
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method implements the Login functionality
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method implements the Get all Users Data functionality
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAlldata()
        {
            return this.userRL.GetAlldata();
        }

        /// <summary>
        ///  This method is implements the forget password functionality
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool SendResetLink(string email)
        {
            try
            {
                return this.userRL.SendResetLink(email);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// This method resets the password for the user registration functionality
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        public bool ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                bool result = this.userRL.ResetPassword(resetPassword);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

