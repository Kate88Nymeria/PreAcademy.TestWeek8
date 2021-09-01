using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Utilities.Forms;
using static PresentationLayer.Utilities.Helpers;
using static DbLayer.EroeAdoRepository;
using DbLayer;

namespace PresentationLayer
{
    public class EroeCRUD
    {
        public static readonly EroeAdoRepository HeroAR = new EroeAdoRepository();

        public static void CreaNuovoEroe(int userId)
        {
            Console.WriteLine("====== CREA NUOVO EROE ======");
            Console.WriteLine();

            Eroe eroeDaCreare = null;
           
            eroeDaCreare = InserimentoDatiEroe();
                
            eroeDaCreare.IdGiocatore = userId;
            Console.WriteLine("Eroe Inserito");

            HeroAR.AggiungiNuovoEroe(eroeDaCreare);
            ContinuaEsecuzione();
                
        }
        //public static void CreaNuovoEroe(int userId)
        //{
        //    Console.WriteLine("====== CREA NUOVO EROE ======");
        //    Console.WriteLine();

        //    bool isCorrect = false;

        //    Eroe eroeDaCreare = null;
        //    //bool verifiedHero = false;
        //    Eroe searchHero = null;

        //    do
        //    {
        //        eroeDaCreare = InserimentoDatiEroe();
        //        searchHero = SearchHero(eroeDaCreare.Nome);
        //        //verifiedHero = VerificaNomeEroe(eroeDaCreare.Nome); //true se presente
        //        //isCorrect = ExistHero(verifiedHero, userId, eroeDaCreare); //true se utilizzabile
        //        isCorrect = ExistHero(searchHero, userId, eroeDaCreare);
        //        if (!isCorrect)
        //        {
        //            Console.WriteLine("Riprova...");
        //            Console.WriteLine();
        //        }
        //        else
        //        {
        //            eroeDaCreare.IdGiocatore = userId;
        //            Console.WriteLine("Eroe Inserito");
        //            ContinuaEsecuzione();
        //        }
        //    } while (!isCorrect);
        //}

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
