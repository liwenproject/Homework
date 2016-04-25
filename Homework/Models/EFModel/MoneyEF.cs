namespace Homework.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    public partial class MoneyEF : DbContext
    {
        public MoneyEF()
            : base("name=MoneyEF")
        {
        }

        public virtual DbSet<AccountBook> AccountBook { get; set; }
        public virtual DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
