using MartianRobots.WebApi.DTOs;
using MartianRobots.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Controllers
{
    [ApiController]
    [Route("/api/robot")]
    [EnableCors("CorsPolicy")]
    public class RobotController : ControllerBase
    {
        private readonly IRobotServices _robotServices;
        public RobotController(IRobotServices robotServices)
        {
            _robotServices = robotServices;
        }

        [HttpPost()]
        public IActionResult MoveRobot([FromBody] RobotInputDTO robotInputDTO)
        {
            RobotOutputDTO robotOutputDTO = _robotServices.MoveRobot(robotInputDTO);
            return Ok(robotOutputDTO);
        }

        [HttpDelete()]
        public IActionResult DeleteRobots()
        {
            _robotServices.DeleteRobots();
            return Ok();
        }
    }
}
