using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Bill_Repository
{
    public class BillRepository : IBillRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public BillRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteBill(Bill bill)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE
                        FROM public.""Bills""
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = bill.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Bill>> GetAllBills()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, total, id_employee, id_client
                        FROM public.""Bills""";
            return await db.QueryAsync<Bill>(sql, new { });
        }

        public async Task<Bill> GetBillDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, total, id_employee,id_client
                        FROM public.""Bills""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Bill>(sql, new { Id = id});
        }

        public async Task<bool> InsertBill(Bill bill)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Bills"" (total, id_employee, id_client)
                        VALUES(@Total, @Id_Employee, @Id_Client)";
            var response = await db.ExecuteAsync(sql, new
            {
                bill.Total,
                bill.Id_Employee,
                bill.Id_Client
            });
            return response > 0;
        }

        public async Task<bool> UpdateBill(Bill bill)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Bills""
                        SET total = @Total,
                            id_employee = @Id_Employee,
                            id_employee = @Id_Client
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new
            {
                bill.Id,
                bill.Total,
                bill.Id_Employee,
                bill.Id_Client
            });
            return response > 0;
        }
    }
}
