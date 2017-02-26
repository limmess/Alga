using System.ComponentModel.DataAnnotations;

namespace Alga.Models
{
    public class Asmuo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Vardas { get; set; }

        [Required]
        [StringLength(50)]
        public string Pavarde { get; set; }

        [Required]
        [Display(Name = "Algos dydis NET")]
        [DataType(DataType.Currency)]
        public float AlgaNet { get; set; }

    }
}