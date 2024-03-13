using M3SuperHeroManager.Models;
using Microsoft.EntityFrameworkCore;

namespace M3SuperHeroManager.Data
{
    public class HeroDbContext : DbContext
    {
        public DbSet<SuperHero> Heroes { get; set; }
        public HeroDbContext(DbContextOptions<HeroDbContext> opt) : base(opt)
        {

        }
    }
}
