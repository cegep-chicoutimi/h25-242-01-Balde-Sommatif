namespace sommatif3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carte c1 = new Carte(ValeurCarte.Deux, CouleurCarte.Trefle);
            Carte c4 = new Carte(ValeurCarte.Deux, CouleurCarte.Pique);
            Carte c2 = new Carte(ValeurCarte.Trois, CouleurCarte.Carreau);
            Carte c3 = new Carte(ValeurCarte.As, CouleurCarte.Coeur);


            Console.WriteLine("le nom est : " + c1.Nom);
            Console.WriteLine("le nom est : " + c2.Nom);
            Console.WriteLine("le nom est : " + c3.Nom);
            Console.WriteLine("le nom est : " + c4.Nom);


            Paquet p1 = new Paquet();

            
            p1.Melanger();

            Console.WriteLine();
            Carte c6 = p1.PrendreCarteDessus();
            Console.WriteLine("le nom est : " + c6.Nom);
            Console.WriteLine("Nombre de cartes : " + p1.NombreCartes);


            MainJoueur mainJoueur = new MainJoueur();
            mainJoueur.AjouterCarte(c6);
            mainJoueur.RetirerCarte(c6);
        }
    }
}
