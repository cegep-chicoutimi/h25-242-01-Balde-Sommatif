using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif2
{
    internal class Banane : Fruit
    {
        // Attribut et propriété
        public string Couleur
        {
            get
            {
                // Maturité -> [0-69] : verte, [70-89] : jaune, [90-100] : noire
                string couleur;

                switch (Maturite)
                {
                    case >= 0 and < 70:
                        couleur = "jaune";
                        break;
                    case >= 70 and < 90:
                        couleur = "jaune";
                        break;
                    case >= 90 and <= 100:
                        couleur = "noire";
                        break;
                    default:
                        couleur = "maturité invalide";
                        break;
                }

                return couleur;
            }
        }

        // Constructeur
        public Banane(int maturite, DateTime cueillette, string? variete) : base(maturite, cueillette, variete)
        {
        }

        // Description du fruit
        public string DescriptionBanane()
        {
            return $"Banane {Variete}, de couleur {Couleur}. Cueillie le {Cueillette:g}. Maturité : {Maturite}";
        }
    }
}
