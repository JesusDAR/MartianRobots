using AutoMapper;
using MartianRobots.Core.Entities;
using MartianRobots.Core.Repositories;
using MartianRobots.Core.Repositories.Interfaces;
using MartianRobots.WebApi.DTOs;
using MartianRobots.WebApi.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Services
{
    public class MarsServices : IMarsServices
    {
        private readonly IMarsRepository _marsRepository;
        private readonly IMapper _mapper;
        public MarsServices(IMarsRepository marsRepository, IMapper mapper)
        {
            _marsRepository = marsRepository;
            _mapper = mapper;
        }
        public MarsDTO SetMars(MarsDTO marsDTO)
        {
            marsDTO.Error = new ErrorDTO { };
            try
            {
                if (GetMars() != null)
                    UpdateMars(marsDTO);
                else
                {
                    Mars mars = _mapper.Map<Mars>(marsDTO);
                    _marsRepository.Add(mars);
                }
            }
            catch (Exception e)
            {
                marsDTO.Error.Message = e.Message;
            }
            return marsDTO;
        }
        public MarsDTO GetMars()
        {
            Mars mars = _marsRepository.Get();
            MarsDTO marsDTO = _mapper.Map<MarsDTO>(mars);
            return marsDTO;
        }
        public void DeleteMars()
        {
            _marsRepository.Delete();
        }
        public void UpdateMars(MarsDTO marsDTO)
        {
            Mars mars = _mapper.Map<Mars>(marsDTO);
            _marsRepository.Update(mars);
        }
    }
}
