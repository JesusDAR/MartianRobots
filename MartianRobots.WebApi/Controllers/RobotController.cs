using MartianRobots.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Controllers
{
    [ApiController]
    [Route("/api/robots")]
    public class RobotController : ControllerBase
    {
        private readonly IRobotServices _robotServices;
        public RobotController(IRobotServices robotServices)
        {
            _robotServices = robotServices;
        }
    }
}
