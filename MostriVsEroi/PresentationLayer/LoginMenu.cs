using System;
using BusinessLayer.Entities;
using static PresentationLayer.Utilities.Forms;
using static PresentationLayer.Utilities.Helpers;
using static DbLayer.UtenteAdoRepository;
using static PresentationLayer.MenuUser;
using static PresentationLayer.MenuAdmin;

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
                        Console.WriteLine(utenteAutenticato); //prova per verifica Admin, non viene riconosciuto come true, problema di riconoscimento bool-bit
                        ContinuaEsecuzione();

                        if (utenteAutenticato.Admin)
                        {
                            UsaAdmin(utenteAutenticato);
                        }
                        else
                        {
                            UsaUtente(utenteAutenticato);
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
