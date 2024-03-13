namespace M3SuperHeroManager.Models
{
    public class SuperHeroCreateViewModel
    {
        public SuperHero Hero { get; set; }
        public IEnumerable<SuperHero> Others { get; set; }
    }
}
