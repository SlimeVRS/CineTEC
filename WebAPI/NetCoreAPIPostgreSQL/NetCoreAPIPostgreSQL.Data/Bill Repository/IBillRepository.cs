using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Bill_Repository
{
    public interface IBillRepository
    {
        Task<IEnumerable<Bill>> GetAllBills();      // Gets all the bills
        Task<Bill> GetBillDetails(int id_bill);     // Gets a bill using id
        Task<bool> InsertBill(Bill bill);           // Inserts a new bill
        Task<bool> UpdateBill(Bill bill);           // Updates a bill
        Task<bool> DeleteBill(Bill bill);           // Deletes a bill
    }
}
