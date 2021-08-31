using System;
using BusinessLayer.Entities;

namespace PresentationLayer.Utilities
{
    public class Helpers
    {
        public static int CheckInt()
        {
            bool isInt = false;
            int numero;

            do
            {
                isInt = int.TryParse(Console.ReadLine(), out numero);
                if (!isInt)
                {
                    Console.WriteLine("Errore: non hai inserito un numero intero. Riprova:");
                }
            } while (!isInt);

            return numero;
        }

        public static void ContinuaEsecuzione()
        {
            Console.WriteLine();
            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadKey();
        }

        public static string CheckValidString()
        {
            string stringa;

            do
            {
                stringa = Console.ReadLine();

                if (String.IsNullOrEmpty(stringa))
                {
                    Console.WriteLine("Errore: non hai inserito alcun carattere. Riprova: ");
                }
                else if(stringa.Length > 20)
                {
                    Console.WriteLine("Errore: sono ammessi al massimo 20 caratteri. Riprova: ");
                }
            } while (String.IsNullOrEmpty(stringa) || stringa.Length > 20);

            return stringa;
        }

    }
}
