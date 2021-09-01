using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Utilities.Forms;
using static PresentationLayer.Utilities.Helpers;
using static DbLayer.MostroAdoRepository;
using DbLayer;

namespace PresentationLayer
{
    public class MostroCRUD
    {
        public static readonly MostroAdoRepository MonsterAR = new MostroAdoRepository();
        public static void CreaNuovoMostro()
        {
            Console.WriteLine("====== CREA NUOVO MOSTRO ======");
            Console.WriteLine();

            bool isCorrect = false;

            Mostro mostroDaCreare = null;
            Mostro mostroRicercato = null;

            do
            {
                mostroDaCreare = InserimentoDatiMostro();
                mostroRicercato = SearchMonster(mostroDaCreare.Nome);
                isCorrect = ExistMonster(mostroRicercato);
                if (!isCorrect)
                {
                    Console.WriteLine("Riprova...");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Mostro Inserito");
                    ContinuaEsecuzione();
                }
            } while (!isCorrect);
        }
    }
}
