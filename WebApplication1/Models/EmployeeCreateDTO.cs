using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmployeeCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}