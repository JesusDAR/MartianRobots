using AutoMapper;
using MartianRobots.Core.Entities;
using MartianRobots.Core.Repositories.Interfaces;
using MartianRobots.WebApi.DTOs;
using MartianRobots.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Services
{
    public class InformationServices : IInformationServices
    {
        private readonly IInformationRepository _informationRepository;
        private readonly IMarsServices _marsServices;
        private readonly IRobotServices _robotServices;
        private readonly IVisitedServices _visitedServices;
        private readonly IMapper _mapper;
        public InformationServices(IMapper mapper, IInformationRepository informationRepository, IMarsServices marsServices, IRobotServices robotServices, IVisitedServices visitedServices)
        {
            _mapper = mapper;
            _informationRepository = informationRepository;
            _marsServices = marsServices;
            _robotServices = robotServices;
            _visitedServices = visitedServices;
        }
        public InformationDTO UpdateInformation(InformationDTO informationDTO)
        {
            informationDTO.Error = new ErrorDTO { };
            try
            {
                MarsDTO marsDTO = _marsServices.GetMars();
                IEnumerable<RobotOutputDTO> robots = _robotServices.GetAll();

                informationDTO.RobotsSucceeded = robots.Where(s => s.Success == true).Count();
                informationDTO.RobotsLost = robots.Where(s => s.Success == false).Count();
                informationDTO.SurfaceExplored = _visitedServices.GetAllVisited().Count();
                informationDTO.SurfaceUnexplored = ((marsDTO.X + 1) * (marsDTO.Y + 1)) - informationDTO.SurfaceExplored;
                Information information = _mapper.Map<Information>(informationDTO);
                _informationRepository.Update(information);

            }
            catch (Exception e)
            {
                informationDTO.Error.Message = e.Message;
            }
            return informationDTO;
        }

        public InformationDTO AddInformation()
        {
            InformationDTO informationDTO = new InformationDTO() { Error = new ErrorDTO { } };
            try
            {
                MarsDTO marsDTO = _marsServices.GetMars();
                informationDTO.SurfaceUnexplored = (marsDTO.X + 1) * (marsDTO.Y + 1);
                Information information = _mapper.Map<Information>(informationDTO);
                _informationRepository.Add(information);
            }
            catch (Exception e)
            {
                informationDTO.Error.Message = e.Message;
            }
            return informationDTO;
        }
        public void DeleteInformation()
        {
            try
            {
                _informationRepository.Delete();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public InformationDTO GetInformation()
        {
            InformationDTO informationDTO = new() { Error = new() };
            try
            {
                Information information = _informationRepository.Get();
                informationDTO = _mapper.Map<InformationDTO>(information);
            }
            catch (Exception e)
            {
                informationDTO.Error.Message = e.Message;
            }
            return informationDTO;
        }
    }
}
