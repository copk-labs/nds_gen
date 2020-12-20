using System;

namespace NDS_GEN
{
    internal class Program
    {
        public const string Version = "v-202012";
        public static int Main(string[] args)
        {
            Greetings();
            MainMenu();
            return 0;
        }

        private static void Greetings()
        {
            Console.WriteLine("NDS GEN " + Version);
            Console.WriteLine("Générateur de Notes de Service pour COPK LABS");
        }

        private static void MainMenu()
        {
            var choice = -1;
            Console.WriteLine("Menu Principal");
            while (choice != 0)
            {
                Console.WriteLine("Merci de choisir votre action:\n1-Créer une NDS\n2-Lire, Modifier, Exporter, Supprimer une NDS\n3-Crédits\n0-Quitter");
                choice = int.Parse(Console.ReadLine() ?? "-1");

                switch (choice)
                {
                    case 1: // Création de la NDS
                        Console.WriteLine("Créer une NDS");
                        break;
                    case 2: // Menu NDS
                        Console.WriteLine("Lire, Modifier, Exporter, Supprimer une NDS");
                        break;
                    case 3: // Crédit
                        Console.WriteLine("Outil créé par Charles Leroy (leroycharles@vivaldi.net)\n NDS GEN " + Version + "\nGénérateur de note de service pour COPK LABS");
                        Console.ReadLine();
                        break;
                    case 0:
                        Console.WriteLine("Sortie du Programme");
                        break;
                    default:
                        Console.WriteLine("Saisie Invalide");
                        break;
                }
            }
            
        }
    }
}