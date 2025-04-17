using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif2
{
    internal abstract class Fruit
    {
        #region Attribut et propriétés
        private int _maturite;
        protected int Maturite
        {
            get { return _maturite; }
            private set
            {
                // Validation : Maturité entre 0 et 100
                if (value < 0 || value > 100) value = 0;

                _maturite = value;
            }
        }

        private DateTime _cueillette;
        public DateTime Cueillette
        {
            get { return _cueillette; }
            set
            {
                // Validation
                if (value >  DateTime.Now) value = DateTime.Now;

                _cueillette = value;
            }
        }

        private string? _variete;
        public string? Variete
        {
            get { return _variete; }
            private set 
            {
                // Validation
                if (string.IsNullOrEmpty(value)) value = "Aucune variété";

                _variete = value; 
            }
        }

        #endregion

        // Constructeur
        protected Fruit(int maturite, DateTime cueillette, string? variete)
        {
            Maturite = maturite;
            Variete = variete;
            Cueillette = cueillette;
        }

    }
}
