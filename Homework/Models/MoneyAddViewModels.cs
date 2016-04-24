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
        //[備註與問題] 若想做成預設(第一次載入) int/DateTime 空白且不會出現驗證錯誤訊息，該如何做
        // 試了改成 int? 和 DateTime? 則預設可空白。是否有更好的寫法? 
        // 但驗證錯誤訊息的部分，因為 [Required] 加上預設空白 都還是會顯示錯誤訊息

        [Required]
        [Display(Name = "類別")]
        public int Category { get; set; }
        [Required]
        [Display(Name = "金額")]
        [Range(1, int.MaxValue)]
        //[DefaultValue(1)]  //=> 不work，待查
        public int Amount { get; set; }
        [Required]
        [Display(Name = "日期")]
        //[DataType(DataType.Date)]
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