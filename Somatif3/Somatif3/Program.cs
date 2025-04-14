namespace Somatif3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banane banane1 = new Banane(25, new DateTime (2024, 01, 12, 12,56,56), " Cavendish");
            Banane banane2 = new Banane(90, new DateTime (2026, 01, 12, 12,56,56), " Cavendish");
            Banane banane3 = new Banane(120, new DateTime (2026, 01, 12, 12,56,56), " Cavendish");
            Banane banane4 = new Banane(66, new DateTime (2026, 01, 12, 12,56,56), " Cavendish");


            Console.WriteLine(banane1.DescriptionBanane());
            Console.WriteLine(banane2.DescriptionBanane());
            Console.WriteLine(banane3.DescriptionBanane());
            Console.WriteLine(banane4.DescriptionBanane());


            Pomme pomme = new Pomme(true, 70, new DateTime(2024, 01, 12, 12, 56, 56), "pomme1");
            Pomme pomme1 = new Pomme(true, 70, new DateTime(2024, 01, 12, 12, 56, 56), "pomme1");
            Pomme pomme2 = new Pomme(true, 190, new DateTime(2026, 01, 12, 12, 56, 56), "pomme3");

            Console.WriteLine();


            Console.WriteLine(pomme.DescriptionPomme());
            Console.WriteLine(pomme1.DescriptionPomme());
            Console.WriteLine(pomme2.DescriptionPomme());

            Console.WriteLine("Comparaise des pommes");
            if(pomme.PommePareille(pomme1) == true)
            {
                Console.WriteLine("ILS SONT IDENTIQUE");
            }
            else
            {
                Console.WriteLine("ILS SONT pas IDENTIQUE");
            }


            if (pomme.PommePareille(pomme2) == true)
            {
                Console.WriteLine("ILS SONT IDENTIQUE");
            }
            else
            {
                Console.WriteLine("ILS SONT pas IDENTIQUE");
            }





        }
    }
}
