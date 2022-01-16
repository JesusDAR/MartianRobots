using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.DTOs
{
    public class InformationDTO
    {
        public int RobotsSucceeded { get; set; }
        public int RobotsLost { get; set; }
        public int SurfaceExplored { get; set; }
        public int SurfaceUnexplored { get; set; }
        public ErrorDTO Error { get; set; }
    }
}
