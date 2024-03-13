using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M6MovieClub.Models
{
    public class Movie
    {
        [Key]
        public string Uid { get; set; }

        public string Title { get; set; }

        public string OwnerId { get; set; }

        [NotMapped]
        public virtual SiteUser Owner { get; set; }

        public Movie()
        {
            Uid = Guid.NewGuid().ToString();
        }

    }
}
