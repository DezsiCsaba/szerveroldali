using M3SuperHeroManager.Models;

namespace M3SuperHeroManager.Data
{
    public interface ISuperHeroRepository
    {
        void Create(SuperHero hero);
        void Delete(string name);
        IEnumerable<SuperHero> Read();
        SuperHero? Read(string name);
        SuperHero? ReadFromId(string id);
        void Update(SuperHero hero);
    }
}