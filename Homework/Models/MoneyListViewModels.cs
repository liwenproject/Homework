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
        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BillingDate { get; set; }
        [Display(Name = "金額")]
        //[DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0}")]
        public double Amount { get; set; }
    }
}