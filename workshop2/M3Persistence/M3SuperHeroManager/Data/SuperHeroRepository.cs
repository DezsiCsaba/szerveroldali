using M3SuperHeroManager.Models;

namespace M3SuperHeroManager.Data
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        HeroDbContext context;

        public SuperHeroRepository(HeroDbContext context)
        {
            this.context = context;
        }

        public void Create(SuperHero hero)
        {
            var heroesSameName = context.Heroes.FirstOrDefault(t => t.Name == hero.Name);
            if (heroesSameName != null)
            {
                throw new ArgumentException("Hero with this name already exists");
            }
            context.Heroes.Add(hero);
            context.SaveChanges();
        }

        public IEnumerable<SuperHero> Read()
        {
            System.Threading.Thread.Sleep(2000);
            return context.Heroes;
        }

        public SuperHero? Read(string name)
        {
            return context.Heroes.FirstOrDefault(t => t.Name == name);
        }

        public SuperHero? ReadFromId(string id)
        {
            return context.Heroes.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(string name)
        {
            var hero = Read(name);
            context.Heroes.Remove(hero);
            context.SaveChanges();
        }

        public void Update(SuperHero hero)
        {
            var old = Read(hero.Name);
            old.Alien = hero.Alien;
            old.Power = hero.Power;
            old.Side = hero.Side;
            context.SaveChanges();
        }


    }
}
