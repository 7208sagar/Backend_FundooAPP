﻿using BussinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
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

       

        public bool Login(UserLogin user1)
        {
            try
            {
                return this.userRL.GetLogin(user1);

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
            catch(Exception e)
            {
                throw;
            }
            

        }
    }
}