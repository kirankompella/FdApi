using DataAccess.models;
using MongoDB.Driver;

namespace DataAccess
{
    public class FdContext
    {
        private readonly IMongoDatabase _database = null;

        public FdContext(string connectionString,string database)
        {
            var client = new MongoClient(connectionString);
            if (client != null)
                _database = client.GetDatabase(database);
        }

        public IMongoCollection<Fd> FixedDeposits
        {
            get
            {
                return _database.GetCollection<Fd>("FixedDeposits");
            }
        }
    }
}
