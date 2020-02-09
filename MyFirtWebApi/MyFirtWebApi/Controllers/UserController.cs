using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyFirtWebApi.Context;
using MyFirtWebApi.Models;

namespace MyFirtWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        public Users Get(int userId)
        {
            using UserContext context = new UserContext();
            return context.Detail(userId);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [EnableCors("_myAllowSpecificOrigins")]
        public Users Create(Users user)
        {
            using UserContext context = new UserContext();
            return context.Create(user);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public Users Login(Users user)
        {
            using UserContext context = new UserContext();
            return context.Authenticate(user);
        }
    }
}
