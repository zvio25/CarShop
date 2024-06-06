using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CarDetailsDTO : CarDTO
    {
        public int MaxSpeed {  get; set; }
        public string Color { get; set; }
        public int MotorCapalist { get; set; }
    }
}