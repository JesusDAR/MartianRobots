using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.DTOs
{
    public class VisitedDTO
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ErrorDTO Error { get; set; }
    }
}
