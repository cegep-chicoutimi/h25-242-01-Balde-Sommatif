using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somatif3
{
    internal class Banane : Fruit
    {
        // Attribut
        private string? _couleur;
        public string? Couleur {
            get {

                if (Maturite >= 0 && Maturite <= 69)
                {
                    return "verte";
                }
                else if (Maturite >= 70 && Maturite <= 89)
                    return "jaune";
                else if (Maturite >= 90 && Maturite <= 100)
                    return "noire";
                return "sans couleur";
            } 
        }

        //constructeur
        public Banane(int maturite, DateTime cueillette, string variete) : base (maturite, cueillette, variete)
        {

        }

        //Methode
        public string DescriptionBanane()
        {
            return $"Banane {Variete}, de couleur {Couleur}. Cueillie le {Cueillette}. Maturité {Maturite}";
        }


    }
}
