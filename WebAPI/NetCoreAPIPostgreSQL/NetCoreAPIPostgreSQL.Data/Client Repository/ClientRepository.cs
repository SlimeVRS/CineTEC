using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Client_Repository
{
    public class ClientRepository : IClientRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public ClientRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteClient(Client client)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE
                        FROM public.""Clients""
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = client.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, _password, _user
                        FROM public.""Clients"" ";
            return await db.QueryAsync<Client>(sql, new { });
        }

        public async Task<Client> GetClientDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, _password, _user
                        FROM public.""Clients""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Client>(sql, new { Id = id });
        }

        public async Task<bool> InsertClient(Client client)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Clients"" (id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, _password, _user)
                        VALUES(@Id, @First_Name, @Second_Name, @First_Last_Name, @Second_Last_Name, @Phone, @Birth_Date, @Password, @User)";
            var response = await db.ExecuteAsync(sql, new {
                client.Id,
                client.First_Name,
                client.Second_Name,
                client.First_Last_Name,
                client.Second_Last_Name,
                client.Phone,
                client.Birth_Date,
                client.Password,
                client.User
            });
            return response > 0;
        }

        public async Task<bool> UpdateClient(Client client)
        {
            var db = dbConnection();
            var sql = @"
                    UPDATE public.""Clients""
                    SET first_name=@First_Name,
                        second_name=@Second_Name,
                        first_last_Name=@First_Last_Name,
                        second_last_Name=@Second_Last_Name,
                        phone=@Phone, 
                        birth_date=@Birth_Date,
                        _password=@Password,
                        _user=@User
                    WHERE id = @Id";
            var respone = await db.ExecuteAsync(sql, new {
                client.Id,
                client.First_Name,
                client.Second_Name,
                client.First_Last_Name,
                client.Second_Last_Name,
                client.Phone,
                client.Birth_Date,
                client.Password,
                client.User
            });
            return respone > 0;
        }
    }
}