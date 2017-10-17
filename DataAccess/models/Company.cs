using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.models
{
    public class Company
    {
        [BsonElement]
        public string CompanyId {get;set;}
        [BsonElement]
        public string Name {get; set;}
    }
}
