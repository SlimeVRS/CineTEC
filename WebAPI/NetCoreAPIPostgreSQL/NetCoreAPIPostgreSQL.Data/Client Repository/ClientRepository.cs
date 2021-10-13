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
                        WHERE id_client = @Id_Client";
            var response = await db.ExecuteAsync(sql, new { Id_Client = client.Id_Client });
            return response > 0;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_client, first_name_client, second_name_client, first_last_name_client, second_last_name_client, phone_client, birth_date_client, password_client, user_client
                        FROM public.""Clients"" ";
            return await db.QueryAsync<Client>(sql, new { });
        }

        public async Task<Client> GetClientDetails(int id_client)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_client, first_name_client, second_name_client, first_last_name_client, second_last_name_client, phone_client, birth_date_client, password_client, user_client
                        FROM public.""Clients""
                        WHERE id_client = @Id_Client";
            return await db.QueryFirstOrDefaultAsync<Client>(sql, new { Id_Client = id_client });
        }

        public async Task<bool> InsertClient(Client client)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Clients"" (id_client, first_name_client, second_name_client, first_last_name_client, second_last_name_client, phone_client, birth_date_client, password_client, user_client)
                        VALUES(@Id_Client, @First_Name_Client, @Second_Name_Client, @First_Last_Name_Client, @Second_Last_Name_Client, @Phone_Client, @Birth_Date_Client, @Password_Client, @User_Client)";
            var response = await db.ExecuteAsync(sql, new {
                client.Id_Client,
                client.First_Name_Client,
                client.Second_Name_Client,
                client.First_Last_Name_Client,
                client.Second_Last_Name_Client,
                client.Phone_Client,
                client.Birth_Date_Client,
                client.Password_Client,
                client.User_Client
            });
            return response > 0;
        }

        public async Task<bool> UpdateClient(Client client)
        {
            var db = dbConnection();
            var sql = @"
                    UPDATE public.""Clients""
                    SET first_name_client = @First_Name_Client,
                        second_name_client = @Second_Name_Client,
                        first_last_name_client = @First_Last_Name_Client,
                        second_last_name_client = @Second_Last_Name_Client,
                        phone_client = @Phone_Client, 
                        birth_date_client = @Birth_Date_Client,
                        password_client = @Password_Client,
                        user_client = @User_Client
                    WHERE id_client = @Id_Client";
            var respone = await db.ExecuteAsync(sql, new {
                client.Id_Client,
                client.First_Name_Client,
                client.Second_Name_Client,
                client.First_Last_Name_Client,
                client.Second_Last_Name_Client,
                client.Phone_Client,
                client.Birth_Date_Client,
                client.Password_Client,
                client.User_Client
            });
            return respone > 0;
        }

        public async Task<Client> GetClientByUserPassword(string user, string password)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT password_client, user_client
                        FROM public.""Clients""
                        WHERE password_client = @Passwrod_client AND user_client = @User_Client";
            return await db.QueryFirstOrDefaultAsync<Client>(sql, new
            {
                Passwrod_client = password,
                User_Client = user
            });
        }
    }
}