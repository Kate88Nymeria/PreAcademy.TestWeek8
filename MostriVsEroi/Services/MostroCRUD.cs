using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Utilities.Forms;
using static BusinessLayer.Utilities.Helpers;
using static DbLayer.MostroAdoRepository;
using DbLayer;
using System.Data;

namespace Services
{
    public class MostroCRUD
    {
        public static readonly MostroAdoRepository MonsterAR = new MostroAdoRepository();
        public static void CreaNuovoMostro()
        {
            if (MonsterAR.Init())
            {
                Console.WriteLine("====== CREA NUOVO MOSTRO ======");
                Console.WriteLine();

                Mostro mostroDaCreare = null;

                mostroDaCreare = InserimentoDatiMostro();

                Console.WriteLine("Mostro Inserito");

                MonsterAR.AggiungiNuovoMostro(mostroDaCreare);
                ContinuaEsecuzione();
            }
        }


        public static Mostro ScegliMostro(Eroe e)
        {
            Mostro mostroScelto = new Mostro();
            if (MonsterAR.Init())
            {
                Console.WriteLine("====== ESTRAZIONE MOSTRO ======");
                Console.WriteLine();

                List<DataRow> righe = MonsterAR.ListaRigheMostri();

                if (righe.Count > 0)
                {
                    Random rnd = new Random();

                    int scelta = rnd.Next(0, righe.Count);

                    DataRow rigaScelta = righe[scelta];

                    if(rigaScelta != null)
                    {
                        mostroScelto.Id = rigaScelta.Field<int>("Id");
                        mostroScelto.Nome = rigaScelta.Field<string>("Nome");
                        mostroScelto.Livello = rigaScelta.Field<int>("Livello");
                        mostroScelto.IdCategoria = rigaScelta.Field<int>("IdCategorie");
                        mostroScelto.IdArma = rigaScelta.Field<int>("IdArmi");


                        if (mostroScelto.Livello <= e.Livello)
                        {
                            Console.WriteLine("{0,-10}{1,-30}{2,-9}{3,12}{4,10}",
                                             "Id", "Nome", "Livello", "Categoria", "Arma");
                            Console.WriteLine(new string('-', 120));
                            Console.WriteLine(mostroScelto);
                            return mostroScelto;
                        }
                        else
                        {
                            return ScegliMostro(e);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nessun mostro selezionato");
                    }
                }
                else
                {
                    Console.WriteLine("Non ci sono Mostri inseriti");
                    mostroScelto = null;
                    ContinuaEsecuzione();
                }
            }
            return mostroScelto;
        }
        public static void MostraRigheMostri()
        {
            Mostro mostro = null;

            if (MonsterAR.Init())
            {
                Console.WriteLine("====== SCEGLI MOSTRO ======");
                Console.WriteLine();

                List<DataRow> records = MonsterAR.ListaRigheMostri();

                if (records.Count > 0)
                {
                    MonsterAR.StampaListaRigheMostri(records);
                }
                else
                {
                    Console.WriteLine("Non ci sono Mostri inseriti");
                    ContinuaEsecuzione();
                }
            }
        }
    }
}
