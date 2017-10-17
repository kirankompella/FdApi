using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DataAccess.models
{
    public class User
    {
        [BsonElement]
        public string UserId {get; set;}
        [BsonElement]
        public string Name { get; set; }
    }
}
