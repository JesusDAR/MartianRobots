using MartianRobots.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Services.Interfaces
{
    public interface IVisitedServices
    {
        public VisitedDTO AddVisited(VisitedDTO visitedDTO);
        public IEnumerable<VisitedDTO> GetAllVisited();
        public void DeleteVisited();
    }
}