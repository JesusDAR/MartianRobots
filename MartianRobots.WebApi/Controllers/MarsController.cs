using MartianRobots.WebApi.DTOs;
using MartianRobots.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Controllers
{
    [ApiController]
    [Route("/api/robots")]
    public class MarsController : ControllerBase
    {
        private readonly IMarsServices _marsServices;
        public MarsController(IMarsServices marsServices)
        {
            _marsServices = marsServices;
        }

        [HttpGet()]
        public IActionResult GetSize()
        {
            return Ok();
        }

        [HttpPost()]
        public IActionResult SetSize([FromBody] MarsDTO marsDTO)
        {
            return Ok();
        }
    }
}
