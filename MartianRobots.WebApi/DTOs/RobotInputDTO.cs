using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.DTOs
{
    public class RobotInputDTO
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Or { get; set; }
        public string Movements { get; set; }
    }
}
