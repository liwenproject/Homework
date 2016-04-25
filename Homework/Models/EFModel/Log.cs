namespace Homework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }

        public int Categoryyy { get; set; }

        public int Amounttt { get; set; }

        [StringLength(50)]
        public string ActionRemark { get; set; }

    }
}
