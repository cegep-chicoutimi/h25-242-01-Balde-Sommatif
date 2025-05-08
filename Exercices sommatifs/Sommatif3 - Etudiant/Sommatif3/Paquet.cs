using Sommatif3.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif3
{
    internal class Paquet : CollectionCartes
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Paquet() : base()
        {
            Initialiser();
        }

        #region Méthodes

        /// <summary>
        /// Tri les cartes au format "usine" par couleur et par valeur
        /// </summary>
        public override void Trier()
        {
            // Solution avancée utilisant LINQ
            _cartes = _cartes.OrderBy(c => c.Couleur).ThenBy(c => c.Valeur).ToList();
        }

        /// <summary>
        /// Mélange les cartes du paquet de manière aléatoire
        /// </summary>
        public void Melanger()
        {
            // Solution avancée utilisant LINQ
            Random rand = new Random();
            _cartes = _cartes.OrderBy(x => rand.Next()).ToList();
        }

        /// <summary>
        /// Retire la carte du dessus de la pile du paquet et la retourne
        /// </summary>
        /// <returns>Carte prise sur le dessus du paquet</returns>
        public Carte? PrendreCarteDessus()
        {
            Carte? carteDessus = null;

            if (_cartes.Count > 0)
            {
                // Récupère la première carte et la retire de la collection de cartes
                carteDessus = _cartes[0];
                _cartes.RemoveAt(0);
            }

            return carteDessus;
        }

        /// <summary>
        /// Vide le paquet et insère les 52 cartes d'un paquet standard
        /// </summary>
        public void Initialiser()
        {
            // Vider la collection de cartes
            _cartes.Clear();

            // Solution avancée pour obtenir des listes de couleurs et de valeurs
            List<CouleurCarte> couleurs = Enum.GetValues(typeof(CouleurCarte))
                                         .Cast<CouleurCarte>()
                                         .ToList();
            List<ValeurCarte> valeurs = Enum.GetValues(typeof(ValeurCarte))
                                         .Cast<ValeurCarte>()
                                         .ToList();

            // Ajout d'une carte pour chaque combinaison valeur-couleur
            foreach (CouleurCarte couleur in couleurs)
            {
                foreach (ValeurCarte valeur in valeurs)
                {
                    _cartes.Add(new Carte(valeur, couleur));
                }
            }
        }

        #endregion    
    }
}
