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
    public class VisitedServices : IVisitedServices
    {
        private readonly IVisitedRepository _visitedRepository;
        private readonly IMapper _mapper;
        public VisitedServices(IMapper mapper, IVisitedRepository visitedRepository)
        {
            _mapper = mapper;
            _visitedRepository = visitedRepository;
        }
        public VisitedDTO Add(VisitedDTO visitedDTO)
        {
            try
            {
                Visited visited = _mapper.Map<Visited>(visitedDTO);
                _visitedRepository.Add(visited);
            }
            catch (Exception e)
            {
                visitedDTO.Error.Message = e.Message;
            }
            return visitedDTO;
        }
        public IEnumerable<VisitedDTO> GetAll()
        {
            try
            {
                return _visitedRepository.GetAll().Select(s => _mapper.Map<VisitedDTO>(s));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteVisited()
        {
            try
            {
                _visitedRepository.Delete();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
