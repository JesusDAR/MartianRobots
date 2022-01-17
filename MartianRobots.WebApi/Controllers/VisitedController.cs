using MartianRobots.WebApi.DTOs;
using MartianRobots.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Controllers
{
    [ApiController]
    [Route("/api/visited")]
    [EnableCors("CorsPolicy")]
    public class VisitedController : ControllerBase
    {
        private readonly IVisitedServices _visitedServices;
        public VisitedController(IVisitedServices visitedServices)
        {
            _visitedServices = visitedServices;
        }

        [HttpDelete()]
        public IActionResult DeleteVisited()
        {
            _visitedServices.DeleteVisited();
            return Ok();
        }

        [HttpGet()]
        public IActionResult GetAllVisited()
        {
            IEnumerable<VisitedDTO> visitedList = _visitedServices.GetAllVisited();
            return Ok(visitedList);
        }

    }
}
