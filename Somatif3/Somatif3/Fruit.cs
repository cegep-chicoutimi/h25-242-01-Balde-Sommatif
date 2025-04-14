using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somatif3
{
    internal abstract class Fruit
    {
        private int _maturite;
        protected int Maturite
        {
            get { return _maturite; }
            private set
            {
                if (value <= 0 || value >= 100) value = 0;
                _maturite = value;
            }
        }


        private DateTime _cueillette;
        public DateTime Cueillette
        {
            get { return _cueillette; }

            private set
            {
                if(value > DateTime.Now) value = DateTime.Now;
                _cueillette = value;
            }
        }

        protected string? _variete;

        protected string? Variete
        {
            get { return _variete; }

            private set
            {
                if (value == null) value = "Variete non definie";
                if (value.Trim() == "") value = "Variete non definie";
                _variete = value;
            }
        }

        public Fruit(int maturite, DateTime cueillette, string variete)
        {
            Maturite = maturite;
            Cueillette = cueillette;
            Variete = variete;
        }
    }
}
