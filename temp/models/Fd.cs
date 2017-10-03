using System;

namespace DataAccess.models
{
    public class Fd
    {
        public string InvestmentId {get;set;}
        public decimal  InvestmentAmount {get; set;}
        public DateTime InvestmentDate {get; set;}
        public DateTime MaturityDate {get; set;}
        public decimal? MaturityAmount {get; set;}
        public decimal RateOfIntrest {get;set;}
        public User InvestedBy{get; set;}
        public User NominatedTo {get; set;}
        public Company  InvestedIn {get; set;}
    }
}
