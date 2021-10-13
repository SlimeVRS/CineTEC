using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Employee_Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeDetails(int id_employee);
        Task<bool> InsertEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(Employee employee);
        //Task<bool> InsertEmployeeFrontEnd(EmployeeFRONTEND employee);
    }
}
