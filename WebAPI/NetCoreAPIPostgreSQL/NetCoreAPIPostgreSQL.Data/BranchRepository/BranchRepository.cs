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
                        WHERE id_branch = @Id_Branch";
            var response = await db.ExecuteAsync(sql, new { Id_Branch = branch.Id_Branch });
            return response > 0;
        }

        public async Task<IEnumerable<Branch>> GetAllBranches()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_branch, name_branch, cant_rooms_branch, address_branch
                        FROM public.""Branches""";
            return await db.QueryAsync<Branch>(sql, new { });
        }

        public async Task<Branch> GetBranchDetails(int id_branch)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_branch, name_branch, cant_rooms_branch, address_branch
                        FROM public.""Branches""
                        WHERE id_branch = @Id_Branch";
            return await db.QueryFirstOrDefaultAsync<Branch>(sql, new { Id_Branch = id_branch });
        }

        public async Task<bool> InsertBranch(Branch branch)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Branches"" (name_branch, cant_rooms_branch, address_branch)
                        VALUES(@Name_Branch, @Cant_Rooms_Branch, @Address_Branch)
                        ";
            var response = await db.ExecuteAsync(sql, new {
                branch.Name_Branch,
                branch.Cant_Rooms_Branch,
                branch.Address_Branch
            });
            return response > 0;
        }

        public async Task<bool> UpdateBranch(Branch branch)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Branches""
                        SET name_branch=@Name_Branch,
                            cant_rooms_branch=@Cant_Rooms_Branch,
                            address_branch=@Address_Branch
                        WHERE id_branch=@Id_Branch";
            var response = await db.ExecuteAsync(sql, new {
                branch.Id_Branch,
                branch.Name_Branch,
                branch.Cant_Rooms_Branch,
                branch.Address_Branch
            });
            return response > 0;
        }
    }
}
