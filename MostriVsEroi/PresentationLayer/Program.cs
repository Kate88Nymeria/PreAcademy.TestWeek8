using System;
using DbLayer;

namespace PresentationLayer
{
    class Program
    {
        public static readonly string ConnectionString = "Server = (localdb)\\mssqllocaldb; " +
            "Database = MostriVsEroi; Trusted_Connection = True;";
        public static readonly UtenteAdoRepository UserAR = new UtenteAdoRepository(ConnectionString);
        public static readonly EroeAdoRepository HeroAR = new EroeAdoRepository(ConnectionString);
        public static readonly MostroAdoRepository MonsterAR = new MostroAdoRepository(ConnectionString);

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
