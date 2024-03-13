using System.ComponentModel.DataAnnotations;

namespace EtelTarolas.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Kcal { get; set; }

        [Required]
        public string Cathegory {  get; set; }

        [Required]
        public int Price { get; set; }

        public Food()
        {
            Id = int.Parse(Guid.NewGuid().ToString());
        }


    }
}
