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
    [Route("/api/mars")]
    public class MarsController : ControllerBase
    {
        private readonly IMarsServices _marsServices;
        public MarsController(IMarsServices marsServices)
        {
            _marsServices = marsServices;
        }

        [HttpGet()]
        public IActionResult GetMars()
        {
            MarsDTO marsDTO = _marsServices.GetMars();
            return Ok(marsDTO);
        }

        [HttpPost()]
        public IActionResult SetMars([FromBody] MarsDTO marsDTO)
        {
            _marsServices.SetMars(marsDTO);
            return Ok();
        }
    }
}
