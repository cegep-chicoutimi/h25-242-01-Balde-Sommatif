using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somatif3
{
    internal class Pomme : Fruit
    {
        //Getteur et setteur
        public bool Ver {  get; private set; }

        //Constructeur
        public Pomme(bool ver, int maturite, DateTime cueillette, string variete) : base(maturite, cueillette, variete)
        {
            this.Ver = ver;
        }

        //Methode

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DescriptionPomme()
        {
            string ver = "sans ver";
            if(Ver == true)
            {
                ver = "ave ver";
            }
            return $"Pomme {Variete},  {ver}. Cueillie le {Cueillette}. Maturité {Maturite}";
        }

        //Methode
        public bool PommePareille(Pomme autrePomme)
        {
            if(this.Maturite == autrePomme.Maturite && this.Variete == autrePomme.Variete)
            {
                return true;
            }
            return false;
        }


    }
}
