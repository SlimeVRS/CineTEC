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
                        WHERE id_bill = @Id_Bill";
            var response = await db.ExecuteAsync(sql, new { Id_Bill = bill.Id_Bill });
            return response > 0;
        }

        public async Task<IEnumerable<Bill>> GetAllBills()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_bill, total_bill, id_employee_bill, id_client_bill
                        FROM public.""Bills""";
            return await db.QueryAsync<Bill>(sql, new { });
        }

        public async Task<Bill> GetBillDetails(int id_bill)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_bill, total_bill, id_employee_bill, id_client_bill
                        FROM public.""Bills""
                        WHERE id_bill = @Id_Bill";
            return await db.QueryFirstOrDefaultAsync<Bill>(sql, new { Id_Bill = id_bill});
        }

        public async Task<bool> InsertBill(Bill bill)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Bills"" (total_bill, id_employee_bill, id_client_bill)
                        VALUES(@Total_Bill, @Id_Employee_Bill, @Id_Client_Bill)";
            var response = await db.ExecuteAsync(sql, new
            {
                bill.Total_Bill,
                bill.Id_Employee_Bill,
                bill.Id_Client_Bill
            });
            return response > 0;
        }

        public async Task<bool> UpdateBill(Bill bill)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Bills""
                        SET total_bill = @Total_Bill,
                            id_employee_bill = @Id_Employee_Bill,
                            id_client_bill = @Id_Client_Bill
                        WHERE id_bill = @Id_Bill";
            var response = await db.ExecuteAsync(sql, new
            {
                bill.Id_Bill,
                bill.Total_Bill,
                bill.Id_Employee_Bill,
                bill.Id_Client_Bill
            });
            return response > 0;
        }
    }
}
