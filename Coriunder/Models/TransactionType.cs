using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coriunder.Models
{
    public enum TransactionType
    {
        Debit = 0, 
        AuthorizationOnly = 1,
        Capture = 2,
        ChargeCC = 3
       
    }
}