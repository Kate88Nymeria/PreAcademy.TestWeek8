using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Utilities.Forms;
using static BusinessLayer.Utilities.Helpers;
using static DbLayer.EroeAdoRepository;
using DbLayer;
using System.Data;

namespace Services
{
    public class EroeCRUD
    {
        public static readonly EroeAdoRepository HeroAR = new EroeAdoRepository();


        public static void CreaNuovoEroe(int userId)
        {
            if (HeroAR.Init())
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
        }


        public static void EliminaEroe(Utente user)
        {
            if (HeroAR.Init())
            {
                Console.WriteLine("====== ELIMINA EROE ======");
                Console.WriteLine();

                List<DataRow> records = HeroAR.ListaEroiUtente(user.Id);

                if (records.Count > 0)
                {
                    HeroAR.StampaListaEroi(user);

                    Console.WriteLine("Inserisci l'ID dell'Eroe da Eliminare");
                    int idEroe = CheckInt();

                    Console.WriteLine();
                    Console.WriteLine("Eroe Eliminato Correttamente");

                    HeroAR.EliminaEroe(idEroe);
                }
                else
                {
                    Console.WriteLine("Non ci sono Eroi inseriti");
                    ContinuaEsecuzione();
                }
            }
        }


        public static Eroe ScegliEroe(Utente user)
        {
            Eroe eroeScelto = null;

            if (HeroAR.Init())
            {
                Console.WriteLine("====== SCEGLI EROE ======");
                Console.WriteLine();

                List<DataRow> records = HeroAR.ListaEroiUtente(user.Id);

                if (records.Count > 0)
                {
                    HeroAR.StampaListaEroi(user);

                    Console.WriteLine("Inserisci l'ID dell'Eroe col quale giocare");
                    int idEroe = CheckInt();

                    DataRow rigaScelta = heroDs.Tables["Eroi"].Rows.Find(idEroe);

                    eroeScelto = new Eroe()
                    {
                        Id = idEroe,
                        Nome = rigaScelta.Field<string>("Nome"),
                        Livello = rigaScelta.Field<int>("Livello"),
                        PuntiAccumulati = rigaScelta.Field<int>("Punti"),
                        IdArma = rigaScelta.Field<int>("IdArmi"),
                        IdCategoria = rigaScelta.Field<int>("IdCategorie"),
                        IdGiocatore = rigaScelta.Field<int>("IdUtenti")
                    };

                    Console.WriteLine();
                    Console.WriteLine(eroeScelto);
                }
                else
                {
                    Console.WriteLine("Non ci sono Eroi inseriti");
                    ContinuaEsecuzione();
                }
            }
            return eroeScelto;
        }

        public static List<Eroe> GetListHero(Utente u)
        {
            List<Eroe> eroi = new List<Eroe>();
            Eroe e = null;

            List<DataRow> righe = HeroAR.ListaEroiUtente(u.Id);

            if (righe.Count > 0)
            {
                foreach (DataRow rigaScelta in righe)
                {
                    e = new Eroe()
                    {
                        Id = rigaScelta.Field<int>("Id"),
                        Nome = rigaScelta.Field<string>("Nome"),
                        Livello = rigaScelta.Field<int>("Livello"),
                        PuntiAccumulati = rigaScelta.Field<int>("Punti"),
                        IdArma = rigaScelta.Field<int>("IdArmi"),
                        IdCategoria = rigaScelta.Field<int>("IdCategorie"),
                        IdGiocatore = u.Id
                    };

                    eroi.Add(e);
                }
            }
            return eroi;
        }

        //public static List<Eroe> GetListHeroForStats()
        //{
        //    List<Eroe> eroi = new List<Eroe>();
        //    Eroe e = null;

        //    List<DataRow> righe = HeroAR.ListaEroi();

        //    if (righe.Count > 0)
        //    {
        //        foreach (DataRow rigaScelta in righe)
        //        {
        //            e = new Eroe()
        //            {
        //                Id = rigaScelta.Field<int>("Id"),
        //                Nome = rigaScelta.Field<string>("Nome"),
        //                Livello = rigaScelta.Field<int>("Livello"),
        //                PuntiAccumulati = rigaScelta.Field<int>("Punti"),
        //                IdArma = rigaScelta.Field<int>("IdArmi"),
        //                IdCategoria = rigaScelta.Field<int>("IdCategorie"),
        //                IdGiocatore = rigaScelta.Field<int>("IdArmi")
        //            };

        //            eroi.Add(e);
        //        }
        //    }
        //    return eroi;
        //}

        public static void AggiornaDbEroi(Eroe e)
        {
            if (HeroAR.Init())
            {
                HeroAR.ModificaEroe(e);
            }
        }
    }
}
