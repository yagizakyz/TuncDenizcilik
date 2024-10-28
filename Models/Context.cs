using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuncDenizci.Models
{
    public class Context : DbContext
    {
        public IConfiguration Configuration { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=TuncDenizcilik; integrated security=true;");
        }

        public DbSet<IstanbulClass> IstanbulTable { get; set; }
        public DbSet<PersonClass> PersonTable { get; set; }
        public DbSet<FactoriesClass> FactoriesTable { get; set; }
        public DbSet<IndustryClass> IndustryTable { get; set; }
        public DbSet<ExpenseClass> ExpenseTable { get; set; }
        public DbSet<Expense21Class> Expense21Table { get; set; }
        public DbSet<MonthClass> MonthTable { get; set; }
    }
}
