using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Models
{
    public class MoneyAddViewModels
    {
        [Display(Name = "序號")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "類別")]
        public int Category { get; set; }
        [Required]
        [Display(Name = "金額")]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
        [Required]
        [Display(Name = "日期")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Remote("EarlierSameToday", "Valid",AreaReference.UseRoot , ErrorMessage ="欄位 日期 不可大於今天")]
        public DateTime BillingDate { get; set; }
        [Required]
        [Display(Name = "備註")]
        [MaxLength(100)]
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