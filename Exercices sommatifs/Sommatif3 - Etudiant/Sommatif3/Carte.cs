using Sommatif3.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif3
{
    internal class Carte
    {
        #region Attributs et Propriétés
        private ValeurCarte _valeur;
        public ValeurCarte Valeur { get { return _valeur; } }

        private CouleurCarte _couleur;
        public CouleurCarte Couleur {  get { return _couleur; } }

        public String Nom { get { return $"{Valeur} de {Couleur}"; } }
        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="valeur">Valeur de la carte</param>
        /// <param name="couleur">Couleur de la carte</param>
        public Carte(ValeurCarte valeur, CouleurCarte couleur) 
        { 
            _valeur = valeur;
            _couleur = couleur;
        }

    }
}
