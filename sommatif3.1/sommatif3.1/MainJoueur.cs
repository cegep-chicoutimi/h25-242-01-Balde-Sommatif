using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sommatif3._1
{
    internal class MainJoueur : CollectionCartes
    {
        public List<Carte> Cartes { get { return _cartes; }  }

        private List<Carte> _cartes;
        public MainJoueur() 
        { 
            _cartes = new List<Carte>();
        }

        public override void Trier()
        {
            // Solution avancée utilisant LINQ
            _cartes = _cartes.OrderBy(c => c.Couleur).ThenBy(c => c.Valeur).ToList();

        }



        public void AjouterCarte(Carte carte)
        {

            // Vérifier que la carte n'est pas déjà dans la main
            if (!ContientCarte(carte))
                // Ajouter la carte
                _cartes.Add(new Carte(carte.Valeur, carte.Couleur));
        }



        public void RetirerCarte(Carte carte)
        {
            int indexCarte = 0;
            bool trouve = false;
            // Cherche la carte et la retire lorsque trouvée
            while (indexCarte < _cartes.Count && trouve == false)
            {
                if (_cartes[indexCarte].Nom == carte.Nom)
                {
                    _cartes.Add(_cartes[indexCarte]);
                    trouve = true;
                }
            }
        }



        public bool ContientCarte(Carte carte)
        {

            int indexCarte = 0;
            bool trouve = false;
            // Cherche la carte et quitte la boucle lorsque trouvée
            while (indexCarte < _cartes.Count && trouve == false)
            {
                if (_cartes[indexCarte].Nom == carte.Nom)
                    trouve = true;
            }
            return trouve;
        }
    }
}
