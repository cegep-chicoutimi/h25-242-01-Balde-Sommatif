using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sommatif3._1
{
    internal class Carte
    {
        public ValeurCarte Valeur { get { return _valeur; } } 
        public CouleurCarte Couleur { get { return _couleur; }   }
        private ValeurCarte _valeur;
        private CouleurCarte _couleur;
        
        public string Nom {
            get 
            { return $"{Valeur} de {Couleur}"; } 
        }



        public Carte(ValeurCarte valeur, CouleurCarte couleur)
        {
            
            _valeur = valeur ;
            _couleur = couleur ;
        } 
    }
}
