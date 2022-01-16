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
            
            CreateMap<InformationDTO, Information>();
            CreateMap<Information, InformationDTO>();

            CreateMap<Visited, VisitedDTO>();
            CreateMap<VisitedDTO, Visited>();

            CreateMap<RobotInputDTO, RobotOutputDTO>();

            CreateMap<RobotInputDTO, Robot>()
                .ForMember(m => m.X_Initial, d => d.MapFrom(s => s.X))
                .ForMember(m => m.Y_Initial, d => d.MapFrom(s => s.Y))
                .ForMember(m => m.Or_Initial, d => d.MapFrom(s => s.Or));
            CreateMap<RobotOutputDTO, Robot>()
                .ForMember(m => m.X_End, d => d.MapFrom(s => s.X))
                .ForMember(m => m.Y_End, d => d.MapFrom(s => s.Y))
                .ForMember(m => m.Or_End, d => d.MapFrom(s => s.Or));
            CreateMap<Robot, RobotOutputDTO>()
                .ForMember(m => m.X, d => d.MapFrom(s => s.X_End))
                .ForMember(m => m.Y, d => d.MapFrom(s => s.Y_End))
                .ForMember(m => m.Or, d => d.MapFrom(s => s.Or_End));

        }
    }
}
