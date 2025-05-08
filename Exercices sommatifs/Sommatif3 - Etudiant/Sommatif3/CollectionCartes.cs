using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif3
{
    internal abstract class CollectionCartes
    {
        #region Attributs et Propriétés
        protected List<Carte> _cartes;

        public int NombreCartes { get { return _cartes.Count; } }
        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public CollectionCartes() 
        { 
            _cartes = new List<Carte>();
        }

        /// <summary>
        /// Tri les cartes de la collection
        /// </summary>
        public abstract void Trier();
    }
}
