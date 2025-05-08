using Sommatif3.Enumerations;
using BibliothequeFonctionsDeBase;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;

namespace Sommatif3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int NOMBRE_JOUEURS = 5;

            FonctionsDeBase.AfficherTitre("Simulateur d'un version simplifiée du jeu Mojo", 60);
            Console.WriteLine();
            FonctionsDeBase.AfficherLigne("Appuyer sur Entrée pour démarrer...", ConsoleColor.DarkGray);
            Console.ReadKey();

            // Composants du jeu
            Defausse defausse = new Defausse();
            Paquet paquet = new Paquet();

            List<MainJoueur> mains = new List<MainJoueur>();
            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                mains.Add(new MainJoueur());
            }

            int[] pointage = new int[NOMBRE_JOUEURS];

            // Démarer les parties
            int continuer = 0;
            int nombrePartieJouee = 0;
            do
            {
                // Initialiser partie
                InitialiserPartie(paquet, mains, defausse);

                // Jouer partie
                nombrePartieJouee++;
                Console.Clear();
                FonctionsDeBase.AfficherTitre($"Débuter la partie #{nombrePartieJouee}");

                Console.WriteLine();
                FonctionsDeBase.AfficherLigne("Appuyer sur Entrée pour jouer la partie...", ConsoleColor.DarkGray);
                Console.ReadKey();

                JouerPartie(paquet, mains, defausse);

                // Mettre à jour le pointage
                CumulerPointage(pointage, mains);

                // Afficher pointage cummulé
                Console.Clear();
                FonctionsDeBase.AfficherTitre($"Pointage après {nombrePartieJouee} partie(s) jouée(s)", 60);
                AfficherPointage(pointage);

                // Continuer ou quitter ?
                Console.WriteLine();
                Console.WriteLine();
                continuer = FonctionsDeBase.LireEntierMinMax("Voulez-vous jouer une autre partie (1) ou quitter (2) ? ", 1, 2);
            }
            while (continuer == 1);

            FonctionsDeBase.MasquerTexte();
        }

        /// <summary>
        /// Initialise les objets d'une partie
        /// </summary>
        /// <param name="paquet">Paquet de cartes standard</param>
        /// <param name="mains">Mains des joueurs</param>
        /// <param name="defausse">Défausse du jeu</param>
        static void InitialiserPartie(Paquet paquet, List<MainJoueur> mains, Defausse defausse)
        {
            // TODO  Implémenter InitialiserPartie

            // Chaque partie débute avec une paquet neuf bien brassé,
            // chaque joueurs ayant 3 cartes de ce paquet en main et
            // 1 carte du paquet placée dans la défausse

            paquet = new Paquet();
            paquet.Melanger();

            for (int i = 0; i < mains.Count; i++)
            {
                if (mains[i].NombreCartes > 0)
                {
                    foreach(MainJoueur main in mains)
                    {
                        foreach(Carte carte in main.Cartes)
                        {
                            main.RetirerCarte(carte);
                        }
                    }
                }
                for (int j = 0; j < 3; j++)
                {
                    mains[i].AjouterCarte(paquet.PrendreCarteDessus());
                }

            }

            defausse.AjouterCarteDessus(paquet.PrendreCarteDessus());
        }

        /// <summary>
        /// Algorithme pour joueur une partie du jeu simplifié de Mojo
        /// </summary>
        /// <param name="paquet">Paquet de cartes standard</param>
        /// <param name="mains">Mains des joueurs</param>
        /// <param name="defausse">Défausse du jeu</param>
        static void JouerPartie(Paquet paquet, List<MainJoueur> mains, Defausse defausse)
        {
            // Vérifier que les composant sont bons
            if (paquet == null) return;
            if (mains == null) return;
            if (mains.Count == 0) return;
            if (defausse == null) return;

            // Initialiser variable de la partie
            bool partieTerminee = VerifierSiGagnant(mains);
            int indexJoueur = 0;

            // Jouer le tour de chaque joueur jusqu'à obtenir un gagnant
            while (partieTerminee == false)
            {
                // Si défausse vide, ajouter une carte sur le dessus
                if (defausse.NombreCartes == 0)
                {
                    Carte? carte = PigerCarte(paquet);
                    if (carte != null)
                        defausse.AjouterCarteDessus(carte);
                }

                if (defausse.CarteDessus != null)
                {
                    // Assurer que le dessus de la défausse n'est pas un roi
                    while (defausse.CarteDessus.Valeur >= ValeurCarte.Dix)
                    {
                        Carte? carte = PigerCarte(paquet);
                        if (carte != null)
                            defausse.AjouterCarteDessus(carte);
                    }

                    // Jouer joueur suivant
                    if (indexJoueur >= mains.Count)
                        indexJoueur = 0;

                    // Afficher état du tour
                    AfficherEtatTour(indexJoueur, mains, defausse.CarteDessus);

                    // Jouer une carte sinon piger une carte
                    Carte? carteAJouer = ChercherCarteAJouer(mains[indexJoueur], defausse.CarteDessus);
                    if (carteAJouer != null)
                    {
                        defausse.AjouterCarteDessus(carteAJouer);
                        mains[indexJoueur].RetirerCarte(carteAJouer);
                        FonctionsDeBase.AfficherLigne($"Le joueur joue la carte {carteAJouer.Nom} et il possède {mains[indexJoueur].NombreCartes} carte(s) en main :", ConsoleColor.Green);
                    }
                    else
                    {
                        Carte? carte = PigerCarte(paquet);
                        if (carte != null)
                            mains[indexJoueur].AjouterCarte(carte);
                        FonctionsDeBase.AfficherLigne($"Le joueur a pigé une carte et il possède {mains[indexJoueur].NombreCartes} carte(s) en main :", ConsoleColor.Red);

                    }
                    foreach (Carte carte in mains[indexJoueur].Cartes)
                    {
                        FonctionsDeBase.AfficherLigne($"\t{carte.Nom}");
                    }

                    // Vérifier si le joueur a gagné
                    if (mains[indexJoueur].NombreCartes == 0)
                    {
                        partieTerminee = true;
                        Console.WriteLine();
                        FonctionsDeBase.AfficherLigne($"Le joueur #{indexJoueur} a gagné !");
                    }
                    else
                    {
                        indexJoueur++;
                        Console.WriteLine();
                        FonctionsDeBase.AfficherLigne("Appuyer sur Entrée pour jouer le tour du prochain joueur...", ConsoleColor.DarkGray);
                        Console.ReadKey();
                        Console.WriteLine();
                    }
                }
                else
                {
                    // Une erreur est survenue
                    // Vider les mains des joueurs et terminer la partie
                    foreach (MainJoueur main in mains)
                    {
                        while (main.NombreCartes > 0)
                            main.RetirerCarte(main.Cartes.First());
                    }
                    partieTerminee = true;

                    Console.WriteLine();
                    Console.WriteLine();
                    FonctionsDeBase.AfficherLigne("Une erreur est survenue et la partie ne peut se poursuivre.");
                }
            }

            Console.WriteLine();
            FonctionsDeBase.AfficherLigne("Fin de la partie.");
        }

        /// <summary>
        /// Détermine s'il y a un gagnant parmi les joueurs
        /// </summary>
        /// <param name="mains">Mains des joueurs</param>
        /// <returns></returns>
        static bool VerifierSiGagnant(List<MainJoueur> mains)
        {
            // TODO Implémenter la méthode VerifierSiGagnant

            // Un joueur a gagné lorsqu'il n'a plus de cartes dans sa main
            bool gagne = false;
            foreach(MainJoueur main in mains)
            {
                if(main.NombreCartes == 0)
                {
                    gagne = true;
                }
                
            }

            return gagne;
        }

        /// <summary>
        /// Cherche si la main du joueur contient une carte à jouer et la retourne
        /// </summary>
        /// <param name="main">Main du joueur</param>
        /// <param name="dessusDefausse">Carte sur le dessus de la défausse</param>
        /// <returns>Carte pouvant être jouée ou null si aucune n'est trouvée</returns>
        static Carte? ChercherCarteAJouer(MainJoueur main, Carte dessusDefausse)
        {
            // Une carte peut être jouée si sa valeur est plus grande ou égale à celle sur la défausse
            // ou si c'est un As lorsqu'aucune carte n'a remplie la première condition

            // TODO Implémenter la 2e possibilité de trouver une carte à jouer (As)

            Carte? carteTrouvee = null;

            if (main.NombreCartes > 0)
            {
                main.Trier();

                // Rechercher une carte plus grande ou égale à celle sur la défausse
                foreach (Carte carte in main.Cartes)
                {
                    if (carteTrouvee == null && carte.Valeur >= dessusDefausse.Valeur)
                        carteTrouvee = carte;
                    
                }
                if (carteTrouvee == null && main.Cartes[0].Valeur == ValeurCarte.As)
                {
                    carteTrouvee = main.Cartes[0];
                }
                
            }
            
            
            return carteTrouvee;
        }

        /// <summary>
        /// Affiche le nombre de cartes dans les mains des joueurs au début du tours et la carte sur la défausse
        /// </summary>
        /// <param name="indexJoueur">Index du joueur en cours</param>
        /// <param name="mains">Mains des joueurs</param>
        /// <param name="carteDessusDefausse">Carte sur le dessus de la défausse</param>
        static void AfficherEtatTour(int indexJoueur, List<MainJoueur> mains, Carte carteDessusDefausse)
        {
            Console.Clear();
            FonctionsDeBase.AfficherTitre($"Tour du joueur #{indexJoueur}");
            Console.WriteLine();

            FonctionsDeBase.AfficherLigne("Mains des joueurs au début du tour");

            for (int i = 0; i < mains.Count; i++)
            {
                if (i == indexJoueur)
                    FonctionsDeBase.AfficherLigne($"\tJoueur {i} : {mains[i].NombreCartes} cartes", ConsoleColor.DarkYellow);
                else
                    FonctionsDeBase.AfficherLigne($"\tJoueur {i} : {mains[i].NombreCartes} cartes");
            }
            Console.WriteLine();
            FonctionsDeBase.AfficherLigne($"Défausse : {carteDessusDefausse.Nom}");
            Console.WriteLine();
        }

        /// <summary>
        /// Accumule les points obtenus par les joueurs : chaque carte en main compte pour 1 point
        /// </summary>
        /// <param name="pointage">Tableau des points accumulés par les joueurs</param>
        /// <param name="mains">Mains des joueurs</param>
        static void CumulerPointage(int[] pointage, List<MainJoueur> mains)
        {
            if (pointage.Length == mains.Count)
            {
                for (int i = 0; i < pointage.Length; i++)
                    pointage[i] += mains[i].NombreCartes;
            }
        }

        /// <summary>
        /// Affiche les points obtenus par les joueurs et indique quel joueur est le meneur
        /// </summary>
        /// <param name="pointage">Tableau des points accumulés par les joueurs</param>
        static void AfficherPointage(int[] pointage)
        {
            int min = int.MaxValue;
            int minIndex = int.MaxValue;

            for (int i = 0;i < pointage.Length;i++)
            {
                FonctionsDeBase.AfficherLigne($"Joueur #{i} : {pointage[i]} points");

                if (pointage[i] < min)
                {
                    min = pointage[i];
                    minIndex = i;
                }
            }

            Console.WriteLine();
            FonctionsDeBase.AfficherLigne($"Le meneur est Joueur #{minIndex} avec {min} points.");

        }

        /// <summary>
        /// Pige une carte dans le paquet et s'assure que le paquet a toujours des cartes.
        /// </summary>
        /// <param name="paquet">Paquet de cartes standard</param>
        /// <returns>Carte pigée sur le dessus du paquet</returns>
        static Carte? PigerCarte(Paquet paquet)
        {
            if (paquet.NombreCartes == 0)
            {
                paquet.Initialiser();
                paquet.Melanger();
            }
            Carte? carte = paquet.PrendreCarteDessus();

            return carte;
        }

    }
}
