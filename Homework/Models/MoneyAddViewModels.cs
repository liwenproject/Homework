using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Models
{
    public class MoneyAddViewModels
    {
        [Required]
        [Display(Name = "類別")]
        public int Category { get; set; }
        [Required]
        [Display(Name = "金額")]
        public double Amount { get; set; }
        [Required]
        [Display(Name = "日期")]
        [DataType(DataType.Date)]
        public DateTime BillingDate { get; set; }
        [Display(Name = "備註")]
        public string Memo { get; set; }

        //public IEnumerable<SelectListItem> CategoryValues
        //{
        //    get
        //    {
        //        return new[]
        //        {
        //        new SelectListItem { Value = "Income", Text = "收入" },
        //        new SelectListItem { Value = "Expense", Text = "支出" },
        //        };
        //    }
        //}
    }


}