using System;
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
        public decimal AlgaNet { get; set; }

        [Required]
        [Range(0, 10)]
        [Display(Name = "Vaiku Skaicius")]
        public int VaikuSkaicius { get; set; }

        public bool AuginaVaikusVienas { get; set; }



        public decimal AlgaGross
        {
            get { return Gross(AlgaNet, VaikuSkaicius); }
        }

        decimal Gross(decimal y, int pnpd)
        {
            decimal x = (y - 75 - 30m * pnpd) / 0.685m;

            decimal npd = 310 - 0.5m * (x - 380m);
            if (npd >= 310m) npd = 310m;
            if (npd <= 0m) npd = 0m;

            decimal s = (x - npd - 200m * pnpd) * 0.15m;
            if (s <= 0m) s = 0m;

            decimal gross = (y + s) / 0.91m;
            decimal grossRound = System.Math.Round(gross, 2, MidpointRounding.AwayFromZero);
            return grossRound;
        }




    }

}
