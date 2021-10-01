using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.BranchRepository
{
    public class BranchRepository : IBranchRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public BranchRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteBranch(Branch branch)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE
                        FROM public.""Branches""
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = branch.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Branch>> GetAllBranches()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, name, cant_rooms, address
                        FROM public.""Branches""";
            return await db.QueryAsync<Branch>(sql, new { });
        }

        public async Task<Branch> GetBranchDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, name, cant_rooms, address
                        FROM public.""Branches""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Branch>(sql, new { Id = id });
        }

        public async Task<bool> InsertBranch(Branch branch)
        {
            var db = dbConnection();
            var sql = @"
INSERT INTO public.""Branches"" (name, cant_rooms, address)
VALUES(@Name, @Cant_Rooms, @Address)
";
            var response = await db.ExecuteAsync(sql, new {
                branch.Name,
                branch.Cant_Rooms,
                branch.Address
            });
            return response > 0;
        }

        public async Task<bool> UpdateBranch(Branch branch)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Branches""
                        SET name=@Name,
                            cant_rooms=@Cant_Rooms,
                            address=@Address
                        WHERE id=@Id";
            var response = await db.ExecuteAsync(sql, new {
                branch.Id,
                branch.Name,
                branch.Cant_Rooms,
                branch.Address
            });
            return response > 0;
        }
    }
}
