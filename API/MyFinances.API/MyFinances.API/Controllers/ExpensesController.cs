using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinances.API.Models.DTOs;
using MyFinances.API.Services.Interface;

namespace MyFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpensesController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetExpenses()
        {
            return Ok(await _service.GetExpensesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDTO>> GetExpense(int id)
        {
            var expense = await _service.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult> AddExpense(ExpenseDTO expenseDto)
        {
            await _service.AddExpenseAsync(expenseDto);
            return CreatedAtAction(nameof(GetExpense), new { id = expenseDto.Id }, expenseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, ExpenseDTO expenseDto)
        {
            if (id != expenseDto.Id)
            {
                return BadRequest();
            }
            await _service.UpdateExpenseAsync(expenseDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _service.DeleteExpenseAsync(id);
            return NoContent();
        }
    }
}
