using AutoMapper;
using MyFinances.API.Models.Domain;
using MyFinances.API.Models.DTOs;
using MyFinances.API.Repositories.Interface;
using MyFinances.API.Services.Interface;

namespace MyFinances.API.Services.Implementation
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesAsync()
        {
            var expenses = await _repository.GetExpensesAsync();
            return _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
        }

        public async Task<ExpenseDTO> GetExpenseByIdAsync(int id)
        {
            var expense = await _repository.GetExpenseByIdAsync(id);
            return _mapper.Map<ExpenseDTO>(expense);
        }

        public async Task AddExpenseAsync(ExpenseDTO expenseDto)
        {
            var expense = _mapper.Map<Expense>(expenseDto);
            await _repository.AddExpenseAsync(expense);
        }

        public async Task UpdateExpenseAsync(ExpenseDTO expenseDto)
        {
            var expense = _mapper.Map<Expense>(expenseDto);
            await _repository.UpdateExpenseAsync(expense);
        }

        public async Task DeleteExpenseAsync(int id)
        {
            await _repository.DeleteExpenseAsync(id);
        }
    }
}
