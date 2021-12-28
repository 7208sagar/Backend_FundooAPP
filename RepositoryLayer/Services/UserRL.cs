using CommonLayer.Model;
using CommonLayer.ResponseModel;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private const string Secret = "FundooApp";
        Context context;
        public UserRL(Context context)
        {
            this.context = context;
        }

        public LoginResponse UserLogin(UserLogin UserLogin)
        {
            try
            {
                var existingLogin = this.context.Users.Where(x => x.EmailId == UserLogin.EmailId && x.Password == UserLogin.Password).FirstOrDefault();

                if (existingLogin.Id != 0 && existingLogin.EmailId != null)
                {
                    LoginResponse login = new LoginResponse();
                    string token = "";
                    token = GenerateJWTToken(existingLogin.EmailId);
                    login.Id = existingLogin.Id;
                    login.FirstName = existingLogin.FirstName;
                    login.LastName = existingLogin.LastName;
                    login.EmailId = existingLogin.EmailId;
                    login.Createat = existingLogin.Createat;
                    login.Modifiedat = existingLogin.Modifiedat;
                    login.token = token;
                    return login;
                   
                }
                else
                {
                    return null ;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private string GenerateJWTToken(string EmailId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("FundooApp"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("EmailId",EmailId)
            };

            var token = new JwtSecurityToken("Sagar", EmailId, claims,
             expires: DateTime.Now.AddMinutes(15),
             signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
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

        public IEnumerable<User> GetAlldata()
        {
            return context.Users.ToList();
        }
    }
}
