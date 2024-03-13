using M3SuperHeroManager.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace M3SuperHeroManager.Models
{
    public enum HeroSide
    {
        [Display(Name = "Civil")]
        civil = 0,
        [Display(Name = "Good")]
        good = 1,
        [Display(Name = "Bad")]
        bad = 2,
    }

    [ModelBinder(BinderType = typeof(SuperHeroModelBinder))]
    public class SuperHero
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        [ShowTable]
        public string Name { get; set; }

        [Required]
        [Range(1,10)]
        [ShowTable]
        public int Power { get; set; }

        [ShowTable]
        public bool Alien { get; set; }

        [Required]
        [ShowTable]
        public HeroSide Side { get; set; }

        [StringLength(200)]
        public string? ImageFileName { get; set; }

        
        public string? ContentType { get; set; }

        public byte[]? Data { get; set; }

        public SuperHero()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
