using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.DTOs
{
    public class ErrorDTO
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
    }
}
