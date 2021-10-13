using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.ClassificationRepository
{
    public interface IClassificationRepository
    {
        Task<IEnumerable<Classification>> GetAllClassifications();
        Task<Classification> GetClassificationDetails(int id_clasiff);
        Task<bool> InsertClassification(Classification classification);
        Task<bool> UpdateClassification(Classification classification);
        Task<bool> DeleteClassification(Classification classification);
    }
}
