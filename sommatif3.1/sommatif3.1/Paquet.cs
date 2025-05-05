using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sommatif3._1
{
    internal class Paquet : CollectionCartes
    {
        public List<Carte> Cartes;
        public Paquet() 
        {
            Initialiser();
        }

        public override void Trier()
        {
            // Solution avancée utilisant LINQ
            _cartes = _cartes.OrderBy(c => c.Couleur).ThenBy(c => c.Valeur).ToList();

        }

        public void Melanger()
        {

            // Solution avancée utilisant LINQ
            Random rand = new Random();
            _cartes = _cartes.OrderBy(x => rand.Next()).ToList();

        }

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

    }
}
