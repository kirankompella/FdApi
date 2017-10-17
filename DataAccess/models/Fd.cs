using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DataAccess.models
{
    public class Fd
    {
        [BsonId]
        [BsonElement]
        public string InvestmentId {get;set;}
        [BsonElement]
        public decimal  InvestmentAmount {get; set;}
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime InvestmentDate {get; set;}
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime MaturityDate {get; set;}
        [BsonElement]
        public decimal? MaturityAmount {get; set;}
        [BsonElement]
        public decimal RateOfIntrest {get;set;}
        [BsonElement]
        public User InvestedBy{get; set;}
        [BsonElement]
        public User NominatedTo {get; set;}
        [BsonElement]
        public Company  InvestedIn {get; set;}
    }
}
