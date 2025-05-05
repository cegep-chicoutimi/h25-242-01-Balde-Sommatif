using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sommatif3._1
{
    internal abstract class CollectionCartes
    {
        protected List<Carte> _cartes;

        public int NombreCartes
        { get { return _cartes.Count; } }

        protected CollectionCartes ()
        {
            _cartes = new List<Carte> ();
        }


        public abstract void Trier();
        
    }
}
