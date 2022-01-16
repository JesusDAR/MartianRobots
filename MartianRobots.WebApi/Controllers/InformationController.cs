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
    [Route("/api/information")]
    [EnableCors("CorsPolicy")]
    public class InformationController : ControllerBase
    {
        private readonly IInformationServices _informationServices;
        public InformationController(IInformationServices informationServices)
        {
            _informationServices = informationServices;
        }

        [HttpDelete()]
        public IActionResult DeleteInformation()
        {
            _informationServices.DeleteInformation();
            return Ok();
        }

        [HttpPost()]
        public IActionResult UpdateInformation([FromBody]InformationDTO informationDTO)
        {
            _informationServices.UpdateInformation(informationDTO);
            return Ok(informationDTO);
        }

        [HttpGet()]
        public IActionResult AddInformation()
        {
             InformationDTO informationDTO = _informationServices.AddInformation();
            return Ok(informationDTO);
        }
    }
}
