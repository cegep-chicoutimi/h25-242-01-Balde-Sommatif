using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sommatif3.Enumerations;

namespace Sommatif3
{
    internal class MainJoueur : CollectionCartes
    {
        // Propriété et Attribut
        public List<Carte> Cartes { get { return new List<Carte>(_cartes); } }

        /// <summary>
        /// Constructeur
        /// </summary>
        public MainJoueur() : base()
        {
        }

        #region Méthodes

        /// <summary>
        /// Tri les cartes par valeur et par couleur
        /// </summary>
        public override void Trier()
        {
            // Solution avancée utilisant LINQ
            _cartes = _cartes.OrderBy(c => c.Valeur).ThenBy(c => c.Couleur).ToList();
        }

        /// <summary>
        /// Ajoute une carte à la main et réorganise la main
        /// </summary>
        /// <param name="carte">Carte à ajouter</param>
        public void AjouterCarte(Carte carte)
        {
            // Vérifier que la carte n'est pas déjà dans la main
            if (!ContientCarte(carte))
                // Ajouter la carte
                _cartes.Add(new Carte(carte.Valeur, carte.Couleur));
        }

        /// <summary>
        /// Retire une carte de la main
        /// </summary>
        /// <param name="carte">Carte à ajouter</param>
        public void RetirerCarte(Carte carte)
        {
            int indexCarte = 0;
            bool trouve = false;

            // Cherche la carte et la retire lorsque trouvée
            while (indexCarte < _cartes.Count && trouve == false)
            {
                if (_cartes[indexCarte].Nom == carte.Nom)
                {
                    _cartes.Remove(_cartes[indexCarte]);
                    trouve = true;
                }
                indexCarte++;
            }
        }

        /// <summary>
        /// Détermine si la main contient une carte
        /// </summary>
        /// <param name="carte">Carte recherchée</param>
        /// <returns>Vrai si la carte est présente dans la main</returns>
        private bool ContientCarte(Carte carte)
        {
            int indexCarte = 0;
            bool trouve = false;

            // Cherche la carte et quitte la boucle lorsque trouvée
            while (indexCarte < _cartes.Count && trouve == false)
            {
                if (_cartes[indexCarte].Nom == carte.Nom)
                    trouve = true;

                indexCarte++;
            }

            return trouve;
        }

        #endregion
    }
}
