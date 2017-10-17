using DataAccess.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FdRepository : IFdRepository
    {
        private readonly FdContext _context = null;

        public FdRepository(string connectionString, string dataBase)
        {
            _context = new FdContext(connectionString,dataBase);
        }

        public async Task<IEnumerable<Fd>> GetAllFixedDeposits()
        {
            return await _context.FixedDeposits.Find(_ => true).ToListAsync();
        }

        public async Task<Fd> GetFixedDeposit(string id)
        {
            var filter = Builders<Fd>.Filter.Eq("InvestmentId", id);
            return await _context.FixedDeposits
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task AddFixedDeposit(Fd item)
        {
            await _context.FixedDeposits.InsertOneAsync(item);
        }

        public async Task<DeleteResult> RemoveFixedDeposit(string id)
        {
            return await _context.FixedDeposits.DeleteOneAsync(
                         Builders<Fd>.Filter.Eq("InvestmentId", id));
        }

        public async Task<UpdateResult> UpdateFixedDeposit(Fd fd)
        {
            var filter = Builders<Fd>.Filter.Eq(s => s.InvestmentId, fd.InvestmentId);
            var update = Builders<Fd>.Update
                                .Set(s => s.InvestedBy, fd.InvestedBy)
                                .Set(s => s.InvestedIn, fd.InvestedIn)
                                .Set(s => s.InvestmentAmount, fd.InvestmentAmount)
                                .Set(s => s.InvestmentDate, fd.InvestmentDate)
                                .Set(s => s.MaturityAmount, fd.MaturityAmount)
                                .Set(s => s.MaturityDate, fd.MaturityDate)
                                .Set(s => s.NominatedTo, fd.NominatedTo)
                                .Set(s => s.RateOfIntrest, fd.RateOfIntrest)
                                .CurrentDate(s => DateTime.Now);
            return await _context.FixedDeposits.UpdateOneAsync(filter, update);
        }

        public async Task UpdateBulkFixedDeposits(IEnumerable<Fd> fixedDeposits)
        {
            foreach (var fd in fixedDeposits)
            {
                await UpdateFixedDeposit(fd);
            }
        }
    }
}
