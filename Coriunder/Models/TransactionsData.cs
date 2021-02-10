using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coriunder.Models
{
    public class TransactionsData
    {
        public string CardHolderName { get; set; }

        public string Email { get; set; }

        public string CardNumber { get; set; }
       
        public int Month { get; set; }

        public string Year { get; set; }

        public string Cvv { get; set; }

        public string BillingAddress { get; set; }
        
        public string City { get; set; }
           
        public string ZipCode { get; set; }

        public string CountryCode { get; set; }    

        public string Phone { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string PersonalHashKey { get; set; }

        public string CompanyNumber { get; set; }

    }
}