using DataAccess.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository 
    {
        private readonly IMongoCollection<Fd> collection = null;

        public Repository()
        {
            string connectionString = "mongodb://kirankompella:i9l5qAhTdxyA23riDwu3g7XDyVqEcvIrGPTGYs7ZjXtks5Ii4JrELv8p9lbBvlBa8PKfwsAAD4diziGiigEe2A==@kirankompella.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            var dataBase = "FixedDeposits";
            var mongoClient = new MongoClient(connectionString);
            collection = mongoClient.GetDatabase(dataBase).GetCollection<Fd>(dataBase);

        }

        public async Task<IEnumerable<Fd>> GetAllFixedDeposits()
        {
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<Fd> GetFixedDeposit(string id)
        {
            var filter = Builders<Fd>.Filter.Eq("InvestmentId", id);
            return await collection
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task AddFixedDeposit(Fd item)
        {
            await collection.InsertOneAsync(item);
        }

        public async Task<DeleteResult> RemoveFixedDeposit(string id)
        {
            return await collection.DeleteOneAsync(
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
            return await collection.UpdateOneAsync(filter, update);
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
