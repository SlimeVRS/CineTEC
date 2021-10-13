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
        Task<IEnumerable<Bill>> GetAllBills();
        Task<Bill> GetBillDetails(int id_bill);
        Task<bool> InsertBill(Bill bill);
        Task<bool> UpdateBill(Bill bill);
        Task<bool> DeleteBill(Bill bill);
    }
}
