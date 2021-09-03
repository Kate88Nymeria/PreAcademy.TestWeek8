using BusinessLayer.Entities;
using System;
using static PresentationLayer.LoginMenu;
using static PresentationLayer.RegistrationMenu;
using static BusinessLayer.Utilities.Helpers;
using static Services.EroeCRUD;
using static Services.MostroCRUD;
using static Services.StatServices;
using static Services.GiocoService;
using static PresentationLayer.Gioco;

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
                Console.Clear();
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

        public static void MenuUser(Utente user)
        {
            bool continuare = true;
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("[ 1 ] - Gioca");
                Console.WriteLine("[ 2 ] - Crea Nuovo Eroe");
                Console.WriteLine("[ 3 ] - Elimina Eroe");
                Console.WriteLine("[ 0 ] - Esci");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        IniziaGioco(user);
                        break;
                    case 2:
                        Console.Clear();
                        CreaNuovoEroe(user.Id);
                        break;
                    case 3:
                        Console.Clear();
                        EliminaEroe(user);
                        break;
                    case 0:
                        continuare = false;
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);
        }

        public static void MenuAdmin(Utente admin)
        {
            bool continuare = true;
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("[ 1 ] - Gioca");
                Console.WriteLine("[ 2 ] - Crea Nuovo Eroe");
                Console.WriteLine("[ 3 ] - Elimina Eroe");
                Console.WriteLine("[ 4 ] - Crea Nuovo Mostro");
                Console.WriteLine("[ 5 ] - Mostra Classifica Globale");
                Console.WriteLine("[ 0 ] - Esci");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        IniziaGioco(admin);
                        break;
                    case 2:
                        Console.Clear();
                        CreaNuovoEroe(admin.Id);
                        break;
                    case 3:
                        Console.Clear();
                        EliminaEroe(admin);
                        break;
                    case 4:
                        Console.Clear();
                        CreaNuovoMostro();
                        break;
                    case 5:
                        Console.Clear();
                        StampaClassifica();
                        break;
                    case 0:
                        continuare = false;
                        Console.WriteLine();
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
