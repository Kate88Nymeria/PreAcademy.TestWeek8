using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Utilities.Helpers;
using static PresentationLayer.EroeCRUD;

namespace PresentationLayer
{
    public class MenuUser
    {
        public static void UsaUtente(Utente user)
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
                        CreaNuovoEroe(user);
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
    }
}
