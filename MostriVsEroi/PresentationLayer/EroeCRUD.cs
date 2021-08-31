using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Utilities.Forms;
using static PresentationLayer.Utilities.Helpers;
using static PresentationLayer.Program;
using static DbLayer.EroeAdoRepository;

namespace PresentationLayer
{
    public class EroeCRUD
    {
        public static void CreaNuovoEroe(Utente user)
        {
            Console.WriteLine("====== CREA NUOVO EROE ======");
            Console.WriteLine();

            bool isCorrect = false;

            Eroe eroeDaCreare = null;
            Eroe eroeRicercato = null;

            do
            {
                eroeDaCreare = InserimentoDatiEroe();
                eroeRicercato = SearchHero(eroeDaCreare.Nome);
                isCorrect = ExistHero(eroeRicercato, user);
                if (!isCorrect)
                {
                    Console.WriteLine("Riprova...");
                    Console.WriteLine();
                }
                else
                {
                    eroeDaCreare.UtenteAutenticato = user;
                    Console.WriteLine("Eroe Inserito");
                    ContinuaEsecuzione();
                }
            } while (!isCorrect);
        }

        public static void EliminaEroe(Utente user)
        {
            Console.WriteLine("====== ELIMINA EROE ======");
            Console.WriteLine();
            HeroAR.StampaListaEroi(user);

            Console.WriteLine("Inserisci l'ID dell'Eroe da Eliminare");
            int idEroe = CheckInt();

            Console.WriteLine();
            Console.WriteLine("Eroe Eliminato Correttamente");

            HeroAR.EliminaEroe(idEroe);
        }
    }
}
