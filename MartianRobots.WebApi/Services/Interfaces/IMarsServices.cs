using MartianRobots.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MartianRobots.WebApi.Services.Interfaces
{
    public interface IMarsServices
    {
        public MarsDTO SetMars(MarsDTO marsDTO);
        public MarsDTO GetMars();
        public void DeleteMars();
        public void UpdateMars(MarsDTO marsDTO);
    }
}
