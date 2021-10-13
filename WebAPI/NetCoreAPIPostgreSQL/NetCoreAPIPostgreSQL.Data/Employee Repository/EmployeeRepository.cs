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

    public class EmployeeRepository : IEmployeeRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public EmployeeRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM public.""Employees""
                        WHERE id_employee = @Id_Employee";
            var response = await db.ExecuteAsync(sql, new { Id_Employee = employee.Id_Employee });
            return response > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee
                        FROM public.""Employees"" ";
            return await db.QueryAsync<Employee>(sql, new { });
        }

        public async Task<Employee> GetEmployeeDetails(int id_employee)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee
                        FROM public.""Employees""
                        WHERE id_employee = @Id_Employee";
            return await db.QueryFirstOrDefaultAsync<Employee>(sql, new { Id_Employee = id_employee });
        }

        public async Task<bool> InsertEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Employees"" (id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee)
                        VALUES(@Id_Employee, @First_Name_Employee, @Second_Name_Employee, @First_Last_Name_Employee, @Second_Last_Name_Employee, @Phone_Employee, @Birth_Date_Employee, @Admission_Date_Employee, @Password_Employee, @User_Employee, @Id_Branch_Employee, @Id_Rol_Employee)";
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
            return response > 0;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var db = dbConnection();
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
            return response > 0;
        }
        /**
        public async Task<bool> InsertEmployeeFrontEnd(EmployeeFRONTEND employee)
        {
            var db = dbConnection();
            var id_branch_sql = @"
                                    SELECT id
                                    FROM public.""Branches""
                                    WHERE name = @Branch_Name";
            var id_branch = await db.QueryFirstOrDefaultAsync<Branch>(id_branch_sql, new { Branch_Name = employee.Branch_Name });
            var id_rol_sql = @"
                                SELECT id
                                FROM public.""Roles""
                                WHERE name = @Rol_Name";
            var ID_ROL = await db.QueryFirstOrDefaultAsync<Rol>(id_rol_sql, new { Rol_Name = employee.Rol_Name });

            var sql = @"
                        INSERT INTO public.""Employees"" (id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, admission_date, _password, _user, id_branch, id_rol)
                        VALUES(@Employee_Id, @First_Name, @Second_Name, @First_Last_Name, @Second_Last_Name, @Phone, @Birth_Date, @Admission_Date,@Password, @User, @Id, @Rol_Id)";
            var response = await db.ExecuteAsync(sql, new
            {
                employee.Employee_Id,
                employee.First_Name,
                employee.Second_Name,
                employee.First_Last_Name,
                employee.Second_Last_Name,
                employee.Phone,
                employee.Birth_Date,
                employee.Admission_Date,
                employee.Password,
                employee.User,
                id_branch.Id,
            });
            return response > 0;
        }**/
    }
}