using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;

namespace Expense_Tracker.Models
{
    public class ExpenseDbContextcs : DbContext
    {
        public ExpenseDbContextcs(DbContextOptions options) : base(options)
        { }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ExpenseLimit> ExpenseLimit { get; set; }
    }
}
    

