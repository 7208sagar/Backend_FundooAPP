using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    /// <summary>
    ///This is an interface of the UserBL class
    /// </summary>
    public interface IUserBL
    {
        /// <summary>
        /// This method implements the User functionality
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Registration(UserRegistration user);

        /// <summary>
        ///  This method implements the Login functionality
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
        LoginResponse UserLogin(UserLogin user1);

        /// <summary>
        /// This method is implements for get all users Data
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAlldata();

        /// <summary>
        ///  /// This method is implements the forget password functionality
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool SendResetLink(string email);

        /// <summary>
        /// /// This method resets the password for the user registration functionality
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        public bool ResetPassword(ResetPassword resetPassword);
    }
}
