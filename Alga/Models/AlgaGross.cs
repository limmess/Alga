//namespace Alga.Models
//{
//    public class AlgaGross
//    {

//        public static float AlgaGrossCalculate(float algaNet)
//        {

//            float pritaikytasNPD;
//            float pritaikytasPNPD = 0;
//            float pajamuMokestis_15 = 15F;
//            float sveikatosDraudimas_6 = 6F;
//            float papildomaPensija_3 = 3F;
//            float sodra_31 = 31.18F;
//            float algaGross = 0;

//            pritaikytasNPD = 380 - 0.5F * (algaGross - 380);
//            var rankos = algaGross - (algaGross - (380 - 0.5F * (algaGross - 380)) - pritaikytasPNPD) * pajamuMokestis_15 - algaGross * sveikatosDraudimas_6 - algaGross * papildomaPensija_3;


//            return algaGross;

//        }



//    }
//}


//Gyventojui taikytino NPD dydžio formulė(2017):

//NPD = Pagrindinis NPD + Papildomas NPD(PNPD)

//Pagrindinis NPD apskaičiuojamas taip:

//1) Jei asmens darbo užmokestis(„ant popieriaus“) yra didesnis negu 380 EUR(MMA, galiojantis einamųjų metų pirmąją dieną), tuomet neapmokestinamų pajamų dydis  skaičiuojamas pagal formulę:
//pagrindinis NPD = 310 EUR - 0,5 x(‘Mėnesinis darbo užmokestis‘ - 380 EUR)

//2) Jei mėnesinis darbo užmokestis „ant popieriaus“ bus didesnis nei 1 000 EUR, pagrindinis NPD bus lygus 0 (kitaip sakant, jis negali būti neigiamas).

//3) Jei mėnesinis darbo užmokestis(„ant popieriaus“) yra ne didesnis nei 380 EUR(MMA, galiojantis einamųjų metų pirmąją dieną), tuomet taikomas mėnesio NPD yra lygus 310 EUR.


//    'Papildomas neapmokestinamų pajamų' (PNPD) apskaičiuojamas taip:

//PNPD = (200 EUR x 'Auginamų vaikų skaičius‘) / 'Augintojų skaičius‘