using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyFirtWebApi.Context;
using MyFirtWebApi.Models;

namespace MyFirtWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class MatchesController : ControllerBase
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="matches"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [EnableCors("_myAllowSpecificOrigins")]
        public Matches Create(Matches matches)
        {
            using MatcheContext context = new MatcheContext();
            return context.Create(matches);
        }
    }
}
