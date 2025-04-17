using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif2
{
    internal class Pomme : Fruit
    {
        // Attribut et propriété
        private bool _ver;
        public bool Ver
        {
            get { return _ver; }
            private set { _ver = value; }
        }

        // Construction
        public Pomme(int maturite, DateTime cueillette, string? variete, bool ver) : base(maturite, cueillette, variete)
        {
            Ver = ver;
        }

        // Description du fruit
        public string DescriptionPomme()
        {
            string avecVer = "avec un ver";
            if (!Ver) avecVer = "sans ver";

            return $"Pomme {Variete}, {avecVer}. Cueillie le {Cueillette:g}. Maturité : {Maturite}";
        }

        // Comparaison entre 2 pommes
        public bool PommePareille(Pomme autrePomme)
        {
            bool resultat = false;

            // Si l'autre pomme n'est pas nulle et que la maturité et la variété sont les mêmes
            if (autrePomme != null)
                if (this.Maturite == autrePomme.Maturite && this.Variete == autrePomme.Variete)
                    resultat = true;

            return resultat;
        }
    }
}
