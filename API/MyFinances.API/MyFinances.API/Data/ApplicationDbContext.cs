using Microsoft.EntityFrameworkCore;
using MyFinances.API.Models.Domain;

namespace MyFinances.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
    }
}
