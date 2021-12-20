using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        Context context;
        public UserRL(Context context)
        {
            this.context = context;
        }
        public bool Registration(UserRegistration user)
        {
            try
            {
                User newUser = new User();
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.EmailId = user.EmailId;
                newUser.Password = user.Password;
                newUser.Createat = DateTime.Now;
                
                
                this.context.Users.Add(newUser);
               
                int result= this.context.SaveChanges();
                if (result>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch(Exception e)
            {
                throw;
            }
        }
    }
}
