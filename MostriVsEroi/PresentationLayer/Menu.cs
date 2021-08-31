using System;
using static PresentationLayer.LoginMenu;
using static PresentationLayer.RegistrationMenu;
using static PresentationLayer.Utilities.Helpers;

namespace PresentationLayer
{
    public class Menu
    {
        public static void Start()
        {
            bool continuare = true;
            int scelta;

            do
            {
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("[ 1 ] - Accedi");
                Console.WriteLine("[ 2 ] - Registrati");
                Console.WriteLine("[ 0 ] - Esci");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        Login();
                        break;
                    case 2:
                        Console.Clear();
                        Registration();
                        break;
                    case 0:
                        continuare = false;
                        Console.WriteLine();
                        Console.WriteLine("Alla prossima partita");
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);
        }
    }
}
