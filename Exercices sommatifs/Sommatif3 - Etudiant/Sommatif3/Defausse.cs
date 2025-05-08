using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif3
{
    internal class Defausse : CollectionCartes
    {
        /// <summary>
        /// Propriété qui retourne la carte sur le dessus de la défausse
        /// </summary>
        public Carte? CarteDessus
        {
            get
            {
                Carte? carteDessus = null;
                if (NombreCartes > 0)
                    carteDessus = new Carte(_cartes.Last<Carte>().Valeur, _cartes.Last<Carte>().Couleur);

                return carteDessus;
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Defausse() : base()
        {
            // S'assure que la défausse est vide
            ViderDefausse();
        }

        /// <summary>
        /// Ajoute une carte sur le dessus de la défausse
        /// </summary>
        /// <param name="carte">Carte à placer sur le dessus de la défausse</param>
        public void AjouterCarteDessus(Carte carte)
        {
            _cartes.Add(new Carte(carte.Valeur, carte.Couleur));
        }

        /// <summary>
        /// Vide le contenu de la défausse
        /// </summary>
        public void ViderDefausse()
        {
            _cartes.Clear();
        }

        /// <summary>
        /// La défausse ne trie pas ses cartes.
        /// </summary>
        public override void Trier()
        {
        }
    }
}
