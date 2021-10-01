using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.BranchRepository
{
    public interface IBranchRepository
    {
        Task<IEnumerable<Branch>> GetAllBranches();
        Task<Branch> GetBranchDetails(int id);
        Task<bool> InsertBranch(Branch branch);
        Task<bool> UpdateBranch(Branch branch);
        Task<bool> DeleteBranch(Branch branch);
    }
}
