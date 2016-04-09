using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework.Models
{
    public class MoneyListViewModels
    {
        [Display(Name = "類別")]
        public string Category { get; set; }
        [Display(Name = "金額")]
        public double Amount { get; set; }
        [Display(Name = "日期")]
        public DateTime BillingDate { get; set; }
        [Display(Name = "備註")]
        public string Memo { get; set; }
    }
}