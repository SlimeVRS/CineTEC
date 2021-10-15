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
        Task<IEnumerable<Branch>> GetAllBranches();     // Gets all the branches
        Task<Branch> GetBranchDetails(int id_branch);   // Gets a branch using id
        Task<bool> InsertBranch(Branch branch);         // Inserts a new branch
        Task<bool> UpdateBranch(Branch branch);         // Updates a branch
        Task<bool> DeleteBranch(Branch branch);         // Deletes a branch
    }
}
