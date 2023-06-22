using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace payc.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TaxCalculation> TaxCalculations { get; set; }
    }
}
