using EmployeeTaskAPI.DTO;
using EmployeeTaskAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace EmployeeTaskAPI.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly DataContext _context;

        public EmployeeRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IList<EmployeeDetailsDTO> GetEmployees()
        {
            var employees = _context.Employees.Select(e => new EmployeeDetailsDTO
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                HiredDate = e.HiredDate,
                Tasks = e.Tasks.ToList()
            }).ToList();

            return employees;
        }

        public EmployeeDetailsDTO GetEmployee(int id)
        {
            EmployeeDetailsDTO employee = _context.Employees.Select(e => new EmployeeDetailsDTO
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                HiredDate = e.HiredDate,
                Tasks = e.Tasks.ToList()
            }).ToList().First(i => i.EmployeeId == id);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }

    }
}