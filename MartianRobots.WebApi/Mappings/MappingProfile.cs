using AutoMapper;
using MartianRobots.Core.Entities;
using MartianRobots.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MarsDTO, Mars>();
            CreateMap<Mars, MarsDTO>();
                //.ForMember(m => m.Id, d => d.MapFrom(s => s.X + s.Y));
        }
    }
}
