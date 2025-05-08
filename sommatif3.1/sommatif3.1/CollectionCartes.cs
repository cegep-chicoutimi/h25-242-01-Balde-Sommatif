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

        // getteur
        public int NombreCartes
        { get { return _cartes.Count; } }

        //Constructeur
        protected CollectionCartes ()
        {
            _cartes = new List<Carte> ();
        }

        // Methode abstract
        public abstract void Trier();
        
    }
}
