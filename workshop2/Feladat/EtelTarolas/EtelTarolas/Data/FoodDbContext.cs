using EtelTarolas.Models;
using Microsoft.EntityFrameworkCore;

namespace EtelTarolas.Data
{
    public class FoodDbContext: DbContext
    {
        public DbSet<Food> Foods { get; set; }

        public FoodDbContext(DbContextOptions<FoodDbContext> opt) : base(opt)
        {
            
        }
    }
}
