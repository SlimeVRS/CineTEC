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
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = employee.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, admission_date, _password, _user
                        FROM public.""Employees"" ";
            return await db.QueryAsync<Employee>(sql, new { });
        }

        public async Task<Employee> GetEmployeeDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, admission_date, _password, _user
                        FROM public.""Employees""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
        }

        public async Task<bool> InsertEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Employees"" (id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, admission_date, _password, _user)
                        VALUES(@Id, @First_Name, @Second_Name, @First_Last_Name, @Second_Last_Name, @Phone, @Birth_Date, @Admission_Date,@Password, @User)";
            var response = await db.ExecuteAsync(sql, new {
                employee.Id,
                employee.First_Name,
                employee.Second_Name,
                employee.First_Last_Name,
                employee.Second_Last_Name,
                employee.Phone,
                employee.Birth_Date,
                employee.Admission_Date,
                employee.Password,
                employee.User
            });
            return response > 0;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"
                    UPDATE public.""Employees""
                    SET first_name=@First_Name,
                        second_name=@Second_Name,
                        first_last_Name=@First_Last_Name,
                        second_last_Name=@Second_Last_Name,
                        phone=@Phone, 
                        birth_date=@Birth_Date,
                        admission_date=@Admission_Date,
                        _password=@Password,
                        _user=@User
                    WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new {
                employee.Id,
                employee.First_Name,
                employee.Second_Name,
                employee.First_Last_Name,
                employee.Second_Last_Name,
                employee.Phone,
                employee.Birth_Date,
                employee.Admission_Date,
                employee.Password,
                employee.User
            });
            return response > 0;
        }
    }
}