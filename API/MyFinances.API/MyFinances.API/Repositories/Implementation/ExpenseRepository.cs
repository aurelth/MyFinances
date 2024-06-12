using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyFinances.API.Data;
using MyFinances.API.Models.Domain;
using MyFinances.API.Repositories.Interface;

namespace MyFinances.API.Repositories.Implementation
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
            => await _context.Expenses.ToListAsync();

        public async Task<Expense?> GetExpenseByIdAsync(int id)
            => await _context.Expenses.FindAsync(id);        

        public async Task<Expense?> UpdateExpenseAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense?> DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
                return expense;
            }

            return null;
        }    
    }
}
