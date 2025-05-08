using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sommatif3._1
{
    internal class Carte
    {
        // propriete 
        public ValeurCarte Valeur { get { return _valeur; } } 
        public CouleurCarte Couleur { get { return _couleur; }   }
        private ValeurCarte _valeur;
        private CouleurCarte _couleur;
        
        // getteur
        public string Nom {
            get 
            { return $"{Valeur} de {Couleur}"; } 
        }


        // constructeur
        public Carte(ValeurCarte valeur, CouleurCarte couleur)
        {

            // Validation : vérifier si la valeur est définie dans l'enum
            if (Enum.IsDefined(typeof(ValeurCarte), valeur))
                _valeur = valeur;
            else
                _valeur = ValeurCarte.As; // Valeur par défaut

            if (Enum.IsDefined(typeof(CouleurCarte), couleur))
                _couleur = couleur;
            else
                _couleur = CouleurCarte.Coeur; // Couleur par défaut
        } 
    }
}
