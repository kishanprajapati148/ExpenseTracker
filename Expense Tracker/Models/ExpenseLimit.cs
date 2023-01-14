using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Expense_Tracker.Models
{
    public class ExpenseLimit
    {
        [Key]
        public int ExpenseLimitId { get; set; }
        public int Expense_Limit { get; set; }

    }
}
