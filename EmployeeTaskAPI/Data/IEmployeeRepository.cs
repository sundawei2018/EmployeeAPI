using EmployeeTaskAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeTaskAPI.Data
{
    public interface IEmployeeRepository
    {
        IList<EmployeeDetailsDTO> GetEmployees();

        EmployeeDetailsDTO GetEmployee(int id);

        IHttpActionResult DeleteEmployee(int id);


    }
}
