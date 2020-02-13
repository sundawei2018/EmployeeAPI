using EmployeeTaskAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTaskAPI.DTO
{
    public class EmployeeDetailsDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }

        public List<ETask> Tasks { get; set; }
    }
}