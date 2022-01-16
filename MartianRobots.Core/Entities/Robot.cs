using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Core.Entities
{
    public class Robot
    {
        public int Id { get; set; }
        public int X_Initial { get; set; }
        public int Y_Initial { get; set; }
        public string Or_Initial { get; set; }
        public int X_End { get; set; }
        public int Y_End { get; set; }
        public string Or_End { get; set; }
        public bool Success { get; set; }
    }
}
