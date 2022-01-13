using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RepositoryLayer;
using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// UserController class 
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        private readonly IMemoryCache memoryCache;
        private readonly Context context;
        private readonly IDistributedCache distributedCache;
        public UserController(IUserBL userBL, IMemoryCache memoryCache, Context context, IDistributedCache distributedCache)
        {
            this.userBL = userBL;
            this.memoryCache = memoryCache;
            this.context = context;
            this.distributedCache = distributedCache;
        }
        [HttpPost]
        [Route("registerUsers")]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                if (this.userBL.Registration(user))
                {
                    return this.Ok(new { Success = true, message = "Registration Successful" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Registration unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

        /// <summary>
        /// Get All Users Data
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserInfo")]
        public IActionResult GetAlldata()
        {
            try
            {
                var userInfo = this.userBL.GetAlldata();
                if (userInfo != null)
                {
                    return this.Ok(new { Success = true, message = "User records found", userdata = userInfo });

                }
                return this.BadRequest(new { Success = false, message = " User records not found" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

        /// <summary>
        /// Login for the existing user
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin(UserLogin user1)
        {
            try
            {
                LoginResponse result = this.userBL.UserLogin(user1);
                if (result.EmailId != null)
                {
                    return this.Ok(new { Success = true, message = "Login Successful", data = result });
                }
                   return this.BadRequest(new { Success = false, message = "Login unsuccessful" });              
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("forgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email should not be null or empty");
            }
            try
            {
                if (this.userBL.SendResetLink(email))
                {
                    return Ok(new { Success = true, message = "Reset password link send successfully" });
                }
                else
                {
                    return Ok(new { Success = true, message = "Error in Reset password link send" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// Resets the Restpassword.
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route("resetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPassword resetPassword)
        {
            try
            {
                var result = this.userBL.ResetPassword(resetPassword);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Reset Password  Sucessfully", Data = resetPassword });
                }
                return this.BadRequest(new { Status = false, Message = "Failed to reset password:Email not exist in database or password is not matched" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllUsersUsingRedisCache()
        {
            var cacheKey = "UserList";
            string serializedUserList;
            var UserList = new List<User>();
            var redisUserList = await distributedCache.GetAsync(cacheKey);
            if (redisUserList != null)
            {
                serializedUserList = Encoding.UTF8.GetString(redisUserList);
                UserList = JsonConvert.DeserializeObject<List<User>>(serializedUserList);
            }
            else
            {
                UserList = await context.Users.ToListAsync();
                serializedUserList = JsonConvert.SerializeObject(UserList);
                redisUserList = Encoding.UTF8.GetBytes(serializedUserList);
                UserList = (List<User>)userBL.GetAlldata();
            }
            return Ok(UserList);
        }
    }
}
