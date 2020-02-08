using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MyFirtWebApi.Context;

namespace MyFirtWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        string connectionString = "Data Source=192.168.250.65;Initial Catalog=pingflood;User ID=sa;Password=shawi123@";

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            SqlConnection cnn = new SqlConnection(connectionString);

            List<User> users;

            try
            {
                cnn.Open();

                using (var db = new UserContext())
                {
                    users = db.Users
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
    }
}
