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
        Task<IEnumerable<Classification>> GetAllClassifications();          // Gets all the classifications
        Task<Classification> GetClassificationDetails(int id_clasiff);      // Gets a classification using id
        Task<bool> InsertClassification(Classification classification);     // Inserts a new classification
        Task<bool> UpdateClassification(Classification classification);     // Updates a classifiaction
        Task<bool> DeleteClassification(Classification classification);     // Deletes a classification
    }
}
