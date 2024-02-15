using System.ComponentModel.DataAnnotations;

namespace M2Hitel.Models
{
    public class HitelModel
    {
        [Required]
        [Display(Name = "Tevékenység")]
        public string tevekenyseg { get; set; }

        [Required]
        [Display(Name = "Időtartam")]
        public int idotartam { get; set; }

        [Display(Name = "Befejezés")]
        public DateTime befejezes { get; set; }


        //[Required]
        //[Range(5,40, ErrorMessage = "Kamat minimum 5% - maximum 40%")]
        //[Display(Name = "Kamat")]
        //public double R { get; set; }

        //[Required]
        //[Range(100000, 999999, ErrorMessage = "Összeg minimum 100.000e Ft")]
        //[Display(Name = "Összeg")]
        //public int PV { get; set; }

        //[Required]
        //[Range(3,30)]
        //[Display(Name = "Futamidő")]
        //public int T { get; set; }
    }
}
