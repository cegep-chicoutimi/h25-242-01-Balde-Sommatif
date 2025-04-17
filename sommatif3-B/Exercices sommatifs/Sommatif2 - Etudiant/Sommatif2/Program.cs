using BibliothequeFonctionsDeBase;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sommatif2
{
    internal class Program
    {
        static string[] varietesBananes = ["Cavendish", "Bio", "Plantain", "Rouge", "Naine", "Inconnue"];
        static string[] varietesPommes = ["McIntosh", "Cortland", "Empire", "Honeycrisp", "Pink lady", "Inconnue"];

        static void Main(string[] args)
        {
            List<Banane> bananes = new List<Banane>();
            List<Pomme> pommes = new List<Pomme>();

            InitialiserFruits(bananes, pommes);

            int selection;
            do
            {
                // Afficher le menu et demander le choix de l'utilisateur
                Console.Clear();
                AfficherMenu();
                selection = FonctionsDeBase.LireEntierMinMax("Quelle est votre sélection (0 à 2) : ", 0, 2);
                Console.Clear();

                // Appliquer le choix de l'utilisateur
                switch (selection)
                {
                    case 0:
                        FonctionsDeBase.AfficherLigne("Au revoir", ConsoleColor.Yellow);
                        break;
                    case 1:
                        ConsulterFruitsEnStock(bananes, pommes);
                        break;
                    case 2:
                        DetruireFruitsInadequats(bananes, pommes);
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Entrée pour continuer...");
                Console.ReadKey();

            } while (selection != 0);

            FonctionsDeBase.MasquerTexte();
        }

        static void AfficherMenu()
        {
            FonctionsDeBase.AfficherTitre("Menu principal", 60, ConsoleColor.Yellow);

            FonctionsDeBase.AfficherLigne("0. Quitter");
            FonctionsDeBase.AfficherLigne("1. Consulter le stock de fruits");
            FonctionsDeBase.AfficherLigne("2. Détruire les fruits inadéquats");

            Console.WriteLine();
        }

        /// <summary>
        /// Génère aléatoirement une quantité de fruits
        /// </summary>
        /// <param name="bananes">Liste de bananes</param>
        /// <param name="pommes">Liste des pommes</param>
        static void InitialiserFruits(List<Banane> bananes, List<Pomme> pommes)
        {
            Random random = new Random();

            // Déterminer le nombre de fruits
            int nbBananes = random.Next(200, 301);
            int nbPommes = random.Next(200, 301);

            // Ajouter les bananes
            for (int i = 1; i < nbBananes; i++)
            {
                // Déterminer maturite
                int maturite = random.Next(0, 101);

                // Déterminer date cueillette
                DateTime cueillette = new DateTime(
                    DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    DateTime.Now.Hour, random.Next(0, DateTime.Now.Minute + 1), 0);

                // Déterminer variété
                string variete = varietesBananes[random.Next(0, 5)];

                bananes.Add(new Banane(maturite, cueillette, variete));
            }

            // Ajouter les pommes
            for (int i = 1; i < nbPommes; i++)
            {
                // Déterminer maturite
                int maturite = random.Next(0, 101);

                // Déterminer date cueillette
                DateTime cueillette = new DateTime(
                    DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    DateTime.Now.Hour, random.Next(0, DateTime.Now.Minute + 1), 0);

                // Déterminer variété
                string variete = varietesPommes[random.Next(0, 5)];

                // Détermine s'il la pomme a un ver
                bool ver = false;
                if (random.Next(1, 11) == 10) ver = true;

                pommes.Add(new Pomme(maturite, cueillette, variete, ver));
            }

        }

        /// <summary>
        /// Afficher l'état des stocks du type de fruit sélectionné par l'utilisateur
        /// </summary>
        /// <param name="bananes">Liste des bananes</param>
        /// <param name="pommes">Liste des pommes</param>
        static void ConsulterFruitsEnStock(List<Banane> bananes, List<Pomme> pommes)
        {
            
            // Listes des fruits
            string[] varietesBananes = ["Cavendish", "Bio", "Plantain", "Rouge", "Naine", "Inconnue"];
            string[] varietesPommes = ["McIntosh", "Cortland", "Empire", "Honeycrisp", "Pink lady", "Inconnue"];

            FonctionsDeBase.AfficherLigne("Menu de chois de fruits : ");
            FonctionsDeBase.AfficherLigne("1.Banane ");
            FonctionsDeBase.AfficherLigne("2.Pomme ");
            int selection = FonctionsDeBase.LireEntierMinMax("Quelle est votre sélection (1 à 2) : ", 1, 2);
            Console.Clear();

            // les compteurs
            int compteur1 = 0;
            int compteur2 = 0;
            int compteur3 = 0;
            int compteur4 = 0;
            int compteur5 = 0;
            int compteur6 = 0;
            

            // Appliquer le choix de l'utilisateur
            switch (selection)
            {
                case 1:
                    foreach (Banane banane in bananes)
                    {
                        if (varietesBananes[0].Equals(banane.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur1++;
                        }
                        else if (varietesBananes[1].Equals(banane.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur2 ++;
                        }
                        else if (varietesBananes[2].Equals(banane.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur3++;
                        }
                        else if (varietesBananes[3].Equals(banane.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur4++;
                        }
                        else if (varietesBananes[4].Equals(banane.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur5++;
                        }
                        else if (varietesBananes[5].Equals(banane.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur6++;
                        }
                        
                    }

                    //Affichage
                    Console.WriteLine($"La quantite Total de {varietesBananes[0]} est : {compteur1}");
                    Console.WriteLine($"La quantite Total de {varietesBananes[1]} est : {compteur2}");
                    Console.WriteLine($"La quantite Total de {varietesBananes[2]} est : {compteur3}");
                    Console.WriteLine($"La quantite Total de {varietesBananes[3]} est : {compteur4}");
                    Console.WriteLine($"La quantite Total de {varietesBananes[4]} est : {compteur5}");
                    Console.WriteLine($"La quantite Total de {varietesBananes[5]} est : {compteur6}");

                    break;
                case 2:
                    foreach (Pomme pomme in pommes)
                    {
                        if (varietesPommes[0].Equals(pomme.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur1++;
                        }
                        else if (varietesPommes[1].Equals(pomme.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur2++;
                        }
                        else if (varietesPommes[2].Equals(pomme.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur3++;
                        }
                        else if (varietesPommes[3].Equals(pomme.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur4++;
                        }
                        else if (varietesPommes[4].Equals(pomme.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur5++;
                        }
                        else if (varietesPommes[5].Equals(pomme.Variete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            compteur6++;
                        }

                    }


                    //Affichages
                    Console.WriteLine($"La quantite Total de {varietesPommes[0]} est : {compteur1}");
                    Console.WriteLine($"La quantite Total de {varietesPommes[1]} est : {compteur2}");
                    Console.WriteLine($"La quantite Total de {varietesPommes[2]} est : {compteur3}");
                    Console.WriteLine($"La quantite Total de {varietesPommes[3]} est : {compteur4}");
                    Console.WriteLine($"La quantite Total de {varietesPommes[4]} est : {compteur5}");
                    Console.WriteLine($"La quantite Total de {varietesPommes[5]} est : {compteur6}");
                    break;
                
                default:
                    break;
            }


            
        }

        /// <summary>
        /// Retire des stocks les fruits périmés ou inadéquats
        /// </summary>
        /// <param name="bananes"></param>
        /// <param name="pommes"></param>
        static void DetruireFruitsInadequats(List<Banane> bananes, List<Pomme> pommes)
        {
            
            //Menu
            FonctionsDeBase.AfficherLigne("Menu de chois de fruits : ");
            FonctionsDeBase.AfficherLigne("1.Banane ");
            FonctionsDeBase.AfficherLigne("2.Pomme ");
            int selection = FonctionsDeBase.LireEntierMinMax("Quelle est votre sélection (1 à 2) : ", 1, 2);

            //Chois selon l'utilisateur
            switch (selection)
            {
                case 1:
                    for(int i = bananes.Count-1; i >= 0; i--)
                    {
                        TimeSpan diff = DateTime.Now - bananes[i].Cueillette;
                        if(bananes[i].Couleur == "noire" || diff.TotalMinutes > 5)
                        {
                            FonctionsDeBase.AfficherLigne("Destruction : " + bananes[i].DescriptionBanane());
                            bananes.Remove(bananes[i]);
                            
                        }
                    }
                    break;
                case 2:
                    for (int i = pommes.Count - 1; i >= 0; i--)
                    {
                        TimeSpan diff = DateTime.Now - pommes[i].Cueillette;
                        if (pommes[i].Ver == true || diff.TotalMinutes > 5)
                        {
                            FonctionsDeBase.AfficherLigne("Destruction : " + pommes[i].DescriptionPomme());
                            pommes.Remove(pommes[i]);

                        }
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
