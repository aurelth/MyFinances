using MyFinances.API.Models.DTOs;

namespace MyFinances.API.Services.Interface
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDTO>> GetExpensesAsync();
        Task<ExpenseDTO> GetExpenseByIdAsync(int id);
        Task AddExpenseAsync(ExpenseDTO expenseDto);
        Task UpdateExpenseAsync(ExpenseDTO expenseDto);
        Task DeleteExpenseAsync(int id);
    }
}
