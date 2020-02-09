using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyFirtWebApi.Context;
using MyFirtWebApi.Models;

namespace MyFirtWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class DemandController : ControllerBase
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        public Demands Get(int id)
        {
            using DemandContext context = new DemandContext();
            return context.Detail(id);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="demand"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [EnableCors("_myAllowSpecificOrigins")]
        public Demands Create(Demands demand)
        {
            using DemandContext context = new DemandContext();
            return context.Create(demand);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="demand"></param>
        /// <returns></returns>
        [HttpGet("GetDemandList")]
        public IEnumerable<Demands> GetDemandList(bool isSeeker, bool isVolonteer)
        {
            using DemandContext context = new DemandContext();
            return context.GetDemandList(isSeeker, isVolonteer);
        }
    }
}
