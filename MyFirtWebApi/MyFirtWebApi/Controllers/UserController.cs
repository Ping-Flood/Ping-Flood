using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MyFirtWebApi.Context;
using MyFirtWebApi.Models;

namespace MyFirtWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// _connectionString
        /// </summary>
        private readonly string _connectionString = "Data Source=192.168.250.65;Initial Catalog=pingflood;User ID=sa;Password=shawi123@";

        /// <summary>
        /// _logger
        /// </summary>
        private readonly ILogger<UserController> _logger;

        //UserController
        public UserController(ILogger<UserController> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> Get(int userId)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(_connectionString);

                cnn.Open();

                List<User> users;

                using (UserContext context = new UserContext())
                {
                    users = context.Users
                       .ToList();
                }

                cnn.Close();

                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public User Create(User user)
        {
            SqlConnection cnn = new SqlConnection(_connectionString);

            try
            {
                cnn.Open();

                using (UserContext context = new UserContext())
                {
                    Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<User> u = context.Users.Add(user);
                    //u.
                    //var result = this.Get(u)
                }

                cnn.Close();

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
