using System;
using BusinessLayer.Entities;
using static BusinessLayer.Utilities.Forms;
using static BusinessLayer.Utilities.Helpers;
using static DbLayer.UtenteAdoRepository;
using static PresentationLayer.Menu;

namespace PresentationLayer
{
    public class LoginMenu
    {
        public static void Login()
        {
            Console.WriteLine("====== ACCESSO UTENTE ======");
            Console.WriteLine();

            bool isCorrect = false;

            Utente utenteAutenticato = null;
            Utente utenteRicercato = null;

            do
            {
                utenteAutenticato = InserimentoDatiUtente();
                utenteRicercato = SearchUser(utenteAutenticato.Nickname);
                isCorrect = LoginUser(utenteRicercato);
                if (!isCorrect)
                {
                    Console.WriteLine("Riprova...");
                    Console.WriteLine();
                }
                else
                {
                    if(utenteAutenticato.Password == utenteRicercato.Password)
                    {
                        Console.WriteLine("Login avvenuto correttamente");
                        ContinuaEsecuzione();

                        if (utenteRicercato.Admin)
                        {
                            MenuAdmin(utenteRicercato);
                        }
                        else
                        {
                            MenuUser(utenteRicercato);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Password errata! Riprova...");
                        isCorrect = false;
                    }
                }
            } while (!isCorrect);
        }
    }
}
