using MartianRobots.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Services.Interfaces
{
    public interface IInformationServices
    {
        public InformationDTO UpdateInformation(InformationDTO informationDTO);
        public InformationDTO AddInformation();
        public void DeleteInformation();
        public InformationDTO GetInformation();
    }
}
