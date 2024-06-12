using MyFinances.API.Models.Domain;

namespace MyFinances.API.Repositories.Interface
{
    public interface IExpenseRepository
    {
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<Expense?> GetExpenseByIdAsync(int id);        
        Task<Expense?> UpdateExpenseAsync(Expense expense);
        Task<Expense?> DeleteExpenseAsync(int id);
    }
}
