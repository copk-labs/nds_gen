using System;

namespace NDS_GEN
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            Greetings();
            return 0;
        }

        private static void Greetings()
        {
            Console.WriteLine("NDS GEN V-202012");
            Console.WriteLine("Générateur de Notes de Service pour COPK LABS");
        }
    }
}