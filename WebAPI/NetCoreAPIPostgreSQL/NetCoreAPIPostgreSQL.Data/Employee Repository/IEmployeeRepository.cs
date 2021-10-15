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
        Task<IEnumerable<Employee>> GetAllEmployees();                              // Gets all the employees
        Task<Employee> GetEmployeeDetails(int id_employee);                         // Gets a employee by id
        Task<bool> InsertEmployee(Employee employee);                               // Inserts a new employee
        Task<bool> UpdateEmployee(Employee employee);                               // Updates an employee
        Task<bool> DeleteEmployee(Employee employee);                               // Deletes an employee
        Task<bool> InsertEmployeeFrontEnd(EmployeeFRONTEND employee);               // Inserts an employee using names of the branch and rol
        Task<Employee> GetEmployeeByUserPassword(string user, string password);     // Gets an employee using the password and user
        Task<bool> UpdateEmlpoyeeFromFrontEnd(EmployeeFRONTEND employee);           // Updates an employee using names of the branch and rol
    }
}
