using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Utilities.Helpers;
using static PresentationLayer.EroeCRUD;
using static PresentationLayer.MostroCRUD;

namespace PresentationLayer
{
    public class MenuAdmin
    {
        public static void UsaAdmin(Utente admin)
        {
            bool continuare = true;
            int scelta;

            Console.Clear();

            do
            {
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
                        //gioco
                        break;
                    case 2:
                        Console.Clear();
                        CreaNuovoEroe(admin);
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
