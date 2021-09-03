using System;
using BusinessLayer.Entities;

namespace BusinessLayer.Utilities
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

        public static int CheckLevel()
        {
            int level;

            do
            {
                level = CheckInt();

                if(level < 1 || level > 5)
                {
                    Console.WriteLine("Errore: livello inserito non valido. Inserisci un numero tra 1 e 5:");
                }
            } while (level < 1 || level > 5);

            return level;
        }

    }
}
