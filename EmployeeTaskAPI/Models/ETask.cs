using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTaskAPI.Models
{
    public class ETask
    {
        [Key]
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Employee { get; set; }
    }
}