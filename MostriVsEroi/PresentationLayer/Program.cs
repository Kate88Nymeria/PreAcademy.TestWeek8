using System;
using DbLayer;

namespace PresentationLayer
{
    class Program
    {
        public static readonly UtenteAdoRepository UserAR = new UtenteAdoRepository();
        static void Main(string[] args)
        {
            Console.WriteLine("====== Mostri vs Eroi ======");
            Console.WriteLine();

            if (UserAR.Init())
            {
                Menu.Start();
            }

            Console.WriteLine();
            Console.WriteLine("Premi un tasto per chiudere il gioco");
            Console.ReadKey();
        }
    }
}
