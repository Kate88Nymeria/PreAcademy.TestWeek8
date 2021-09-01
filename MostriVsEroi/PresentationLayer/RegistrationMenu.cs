using System;
using BusinessLayer.Entities;
using static PresentationLayer.Utilities.Forms;
using static PresentationLayer.Utilities.Helpers;
using static DbLayer.UtenteAdoRepository;
using static PresentationLayer.Menu;
using static PresentationLayer.Program;

namespace PresentationLayer
{
    public class RegistrationMenu
    {
        public static void Registration()
        {
            Console.WriteLine("====== REGISTRAZIONE NUOVO UTENTE ======");
            Console.WriteLine();

            bool isCorrect = false;

            Utente utenteRegistrato = null;
            Utente utenteRicercato = null;

            do
            {
                utenteRegistrato = InserimentoDatiUtente();
                utenteRicercato = SearchUser(utenteRegistrato.Nickname);
                isCorrect = RegisterUser(utenteRicercato);
                if (!isCorrect)
                {
                    Console.WriteLine("Riprova...");
                    Console.WriteLine();
                }
                else
                {
                    utenteRegistrato.Admin = false;
                    UserAR.AggiungiNuovoUtente(utenteRegistrato);
                    Console.WriteLine("Registrazione avvenuta con successo!");
                    ContinuaEsecuzione();
                    MenuUser(utenteRegistrato);
                }
            } while (!isCorrect);
        }  
    }
}
