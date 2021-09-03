using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.EroeCRUD;
using static Services.MostroCRUD;
using static Services.ArmaCRUD;
using static Services.GiocoService;
using static PresentationLayer.Menu;

namespace PresentationLayer
{
    public class Gioco
    {
        public static void IniziaGioco(Utente user)
        {
            bool continua = true;
            Utente utenteGiocato = null;

            do
            {
                Eroe hero = ScegliEroe(user);
                bool usaStessoEroe = true;

                if (hero != null)
                {
                    Eroe eroeAttivo = null;
                    if (MonsterAR.Init())
                    {
                        Console.WriteLine();
                        do
                        {
                            Mostro monster = ScegliMostro(hero);
                            Console.WriteLine();

                            if (monster != null)
                            {
                                eroeAttivo = StartPartita(hero, monster, user);
                                utenteGiocato = CheckGameUser(hero, eroeAttivo, user);
                            }

                            continua = ContinueGame(eroeAttivo, utenteGiocato);
                            if (continua)
                            {
                                usaStessoEroe = UseSameHero(eroeAttivo);
                            }
                            else
                            {
                                return;
                            }
                        } while (usaStessoEroe);
                    }
                }
            } while (continua);

            //if (utenteGiocato.Admin)  //se l'utente diventa admin non apre il menù admin
            //{
            //    MenuAdmin(utenteGiocato);
            //}
            //else
            //{
            //    MenuUser(utenteGiocato);
            //}
        }
    }
}
