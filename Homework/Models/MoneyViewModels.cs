using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework.Models
{
    public class MoneyViewModels
    {
        public string Category { get; set; }
        public double Amount { get; set; }
        public DateTime BillingDate { get; set; }
        public string Memo { get; set; }
    }
}