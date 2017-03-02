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
        [Display(Name = "Salary NET")]
        [DataType(DataType.Currency)]
        public decimal AlgaNet { get; set; }

        [Required]
        [Range(0, 10)]
        [Display(Name = "Number of Children")]
        public int VaikuSkaicius { get; set; }

        public bool AuginaVaikusVienas { get; set; }


        [Display(Name = "Salary Gross")]
        [DataType(DataType.Currency)]
        public decimal AlgaGross => Models.AlgaGross.Gross(AlgaNet, VaikuSkaicius, AuginaVaikusVienas);
    }

}
