using DataAccess.models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository
    {
        Task<IEnumerable<Fd>> GetAllFixedDeposits();
        Task<Fd> GetFixedDeposit(string id);
        Task AddFixedDeposit(Fd fd);
        Task<DeleteResult> RemoveFixedDeposit(string id);
        Task<UpdateResult> UpdateFixedDeposit(Fd fd);
        Task UpdateBulkFixedDeposits(IEnumerable<Fd> fixedDeposits);

    }
}
