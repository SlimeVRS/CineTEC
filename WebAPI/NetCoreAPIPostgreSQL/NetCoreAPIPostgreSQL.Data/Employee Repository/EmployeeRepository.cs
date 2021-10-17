using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Employee_Repository
{
    // Repository of Employees
    public class EmployeeRepository : IEmployeeRepository
    {
        // Varible connection with postgreSQL
        private PostgreSQLConfiguration _connectionString;

        // Assignation of all the necessary information
        public EmployeeRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        // Connection with postgreSQL
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        // Delete method for an employee
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        DELETE FROM public.""Employees""
                        WHERE id_employee = @Id_Employee";
            // Waiting of the response if a row were deleted
            var response = await db.ExecuteAsync(sql, new { Id_Employee = employee.Id_Employee });
            // Returns if one or more employees were deleted
            return response > 0;
        }

        // Get method for all the seats
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee
                        FROM public.""Employees"" ";
            // Returns all the employees
            return await db.QueryAsync<Employee>(sql, new { });
        }

        // Get method for one employee using id
        public async Task<Employee> GetEmployeeDetails(int id_employee)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee
                        FROM public.""Employees""
                        WHERE id_employee = @Id_Employee";
            // Returns a employee by id
            return await db.QueryFirstOrDefaultAsync<Employee>(sql, new { Id_Employee = id_employee });
        }

        // Creates a new employee
        public async Task<bool> InsertEmployee(Employee employee)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        INSERT INTO public.""Employees"" (id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee)
                        VALUES(@Id_Employee, @First_Name_Employee, @Second_Name_Employee, @First_Last_Name_Employee, @Second_Last_Name_Employee, @Phone_Employee, @Birth_Date_Employee, @Admission_Date_Employee, @Password_Employee, @User_Employee, @Id_Branch_Employee, @Id_Rol_Employee)";

            // New employee's attributes
            var response = await db.ExecuteAsync(sql, new {
                employee.Id_Employee,
                employee.First_Name_Employee,
                employee.Second_Name_Employee,
                employee.First_Last_Name_Employee,
                employee.Second_Last_Name_Employee,
                employee.Phone_Employee,
                employee.Birth_Date_Employee,
                employee.Admission_Date_Employee,
                employee.Password_Employee,
                employee.User_Employee,
                employee.Id_Branch_Employee,
                employee.Id_Rol_Employee
            });

            // Returns true if one or more employees were added
            return response > 0;
        }

        // Update for a employee
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                    UPDATE public.""Employees""
                    SET first_name_employee=@First_Name_Employee,
                        second_name_employee=@Second_Name_Employee,
                        first_last_name_employee=@First_Last_Name_Employee,
                        second_last_name_employee=@Second_Last_Name_Employee,
                        phone_employee=@Phone_Employee, 
                        birth_date_employee=@Birth_Date_Employee,
                        admission_date_employee=@Admission_Date_Employee,
                        password_employee=@Password_Employee,
                        user_employee=@User_Employee,
                        id_branch_employee=@Id_Branch_Employee,
                        id_rol_employee = @Id_Rol_Employee
                    WHERE id_employee = @Id_Employee";

            // The attributes of the employee
            var response = await db.ExecuteAsync(sql, new {
                employee.Id_Employee,
                employee.First_Name_Employee,
                employee.Second_Name_Employee,
                employee.First_Last_Name_Employee,
                employee.Second_Last_Name_Employee,
                employee.Phone_Employee,
                employee.Birth_Date_Employee,
                employee.Admission_Date_Employee,
                employee.Password_Employee,
                employee.User_Employee,
                employee.Id_Branch_Employee,
                employee.Id_Rol_Employee
            });
            // Returns true if one or more employees were modified
            return response > 0;
        }
        
        // Insert method from front end
        public async Task<bool> InsertEmployeeFrontEnd(EmployeeFRONTEND employee)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var id_branch_sql = @"
                                    SELECT id_branch
                                    FROM public.""Branches""
                                    WHERE name_branch = @Branch_Name";
            var id_branch = await db.QueryFirstOrDefaultAsync<Branch>(id_branch_sql, new { Branch_Name = employee.Id_Branch_Employee });
            var id_rol_sql = @"
                                SELECT id_rol
                                FROM public.""Roles""
                                WHERE name_rol = @Rol_Name";
            var id_rol = await db.QueryFirstOrDefaultAsync<Rol>(id_rol_sql, new { Rol_Name = employee.Id_Rol_Employee });
            if (id_branch == null || id_rol == null)
                return false;
            var sql = @"
                        INSERT INTO public.""Employees"" (id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee)
                        VALUES(@Id_Employee, @First_Name_Employee, @Second_Name_Employee, @First_Last_Name_Employee, @Second_Last_Name_Employee, @Phone_Employee, @Birth_Date_Employee, @Admission_Date_Employee, @Password_Employee, @User_Employee, @Id_Branch, @Id_Rol)";
            var response = await db.ExecuteAsync(sql, new
            {
                employee.Id_Employee,
                employee.First_Name_Employee,
                employee.Second_Name_Employee,
                employee.First_Last_Name_Employee,
                employee.Second_Last_Name_Employee,
                employee.Phone_Employee,
                employee.Birth_Date_Employee,
                employee.Admission_Date_Employee,
                employee.Password_Employee,
                employee.User_Employee,
                id_branch.Id_Branch,
                id_rol.Id_Rol

            });
            return response > 0;
        }

        public async Task<Employee> GetEmployeeByUserPassword(string user, string password)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT password_employee, user_employee
                        FROM public.""Employees""
                        WHERE password_employee = @Password_Employee AND user_employee = @User_Employee";
            return await db.QueryFirstOrDefaultAsync<Employee>(sql, new
            {
                Password_Employee = password,
                User_Employee = user
            });
        }

        public async Task<bool> UpdateEmlpoyeeFromFrontEnd(EmployeeFRONTEND employee)
        {
            var db = dbConnection();

            var id_branch_sql = @"
                                    SELECT id_branch
                                    FROM public.""Branches""
                                    WHERE name_branch = @Branch_Name";
            var id_branch = await db.QueryFirstOrDefaultAsync<Branch>(id_branch_sql, new { Branch_Name = employee.Id_Branch_Employee });
            var id_rol_sql = @"
                                SELECT id_rol
                                FROM public.""Roles""
                                WHERE name_rol = @Rol_Name";
            var id_rol = await db.QueryFirstOrDefaultAsync<Rol>(id_rol_sql, new { Rol_Name = employee.Id_Rol_Employee });
            if (id_branch == null || id_rol == null)
                return false;
            var sql = @"
                        UPDATE public.""Employees""
                        SET first_name_employee=@First_Name_Employee,
                            second_name_employee=@Second_Name_Employee,
                            first_last_name_employee=@First_Last_Name_Employee,
                            second_last_name_employee=@Second_Last_Name_Employee,
                            phone_employee=@Phone_Employee, 
                            birth_date_employee=@Birth_Date_Employee,
                            admission_date_employee=@Admission_Date_Employee,
                            password_employee=@Password_Employee,
                            user_employee=@User_Employee,
                            id_branch_employee=@Id_Branch,
                            id_rol_employee = @Id_Rol
                        WHERE id_employee = @Id_Employee";
            var response = await db.ExecuteAsync(sql, new
            {
                employee.Id_Employee,
                employee.First_Name_Employee,
                employee.Second_Name_Employee,
                employee.First_Last_Name_Employee,
                employee.Second_Last_Name_Employee,
                employee.Phone_Employee,
                employee.Birth_Date_Employee,
                employee.Admission_Date_Employee,
                employee.Password_Employee,
                employee.User_Employee,
                id_branch.Id_Branch,
                id_rol.Id_Rol
            });
            return response > 0;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeDetailsWithNames()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, name_branch, name_rol
                        FROM public.""Employees""
                        INNER JOIN public.""Roles""
                        ON id_rol_employee = id_rol
                        INNER JOIN public.""Branches""
                        ON id_branch_employee = id_branch";
            return await db.QueryAsync<Employee>(sql, new { });
        }
    }
}