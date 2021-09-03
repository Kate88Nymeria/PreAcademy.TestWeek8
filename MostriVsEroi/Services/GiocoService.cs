using BusinessLayer.Entities;
using static BusinessLayer.Utilities.Helpers;
using static Services.EroeCRUD;
using static Services.ArmaCRUD;
using static DbLayer.EroeAdoRepository;
using static Services.UserServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Services
{
    public class GiocoService
    {
        public static Eroe StartPartita(Eroe hero, Mostro monster, Utente user)
        {
            Eroe eroeAttivo = SelectTypeOfMovement(hero, monster, user);

            return eroeAttivo;
        }

        public static bool UseSameHero(Eroe hero)
        {
            bool continuare = false;
            int scelta;
            bool sameHero = true;

            do
            {
                Console.WriteLine("Vuoi Usare lo stesso Eroe?");
                Console.WriteLine("[ 1 ] - Si");
                Console.WriteLine("[ 2 ] - No");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        continuare = true;
                        sameHero = true;
                        break;
                    case 2:
                        Console.Clear();
                        continuare = true;
                        sameHero = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (!continuare);
            return sameHero;
        }

        public static bool ContinueGame(Eroe hero, Utente user)
        {
            bool continuare = false;
            int scelta;
            bool prosegui = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("[ 1 ] - Gioca Ancora");
                Console.WriteLine("[ 2 ] - Torna al Menù");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        continuare = true;
                        prosegui = true;
                        break;
                    case 2:
                        Console.Clear();
                        continuare = true;
                        prosegui = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (!continuare);
            return prosegui;
        }

        public static Eroe SelectTypeOfMovement(Eroe h, Mostro m, Utente u)
        {
            bool continuare = true;
            int scelta;

            Eroe eroeAttivo = new Eroe();
            Eroe eroeAggiornato = new Eroe();

            do
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine();
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("[ 1 ] - Attaccare");
                Console.WriteLine("[ 2 ] - Fuggire");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        eroeAttivo = Attack(h, m, u);
                        eroeAggiornato = CheckGame(h, eroeAttivo, u);
                        AggiornaDbEroi(eroeAggiornato);
                        continuare = false;
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        eroeAttivo = Escape(h, m, u);
                        eroeAggiornato = CheckGame(h, eroeAttivo, u);
                        AggiornaDbEroi(eroeAggiornato);
                        Console.Clear();
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);
            return eroeAttivo;
        }

        public static Eroe Attack(Eroe h, Mostro m, Utente u)
        {
            Arma armaEroe = TrovaArmaDaPersonaggio(h);
            Arma armaMostro = TrovaArmaDaPersonaggio(m);
            int nuoviPuntiVitaEroe = h.PuntiVita;
            int nuoviPuntiVitaMostro = m.PuntiVita;
            int contaTurno = 1;

            Eroe eroeAttivo = new Eroe()
            {
                Id = h.Id,
                IdArma = h.IdArma,
                IdCategoria = h.IdCategoria,
                IdGiocatore = h.IdGiocatore,
                Nome = h.Nome,
                Categoria = h.Categoria,
                TipoArma = h.TipoArma,
                PuntiAccumulati = h.PuntiAccumulati,
                Livello = h.Livello
            };

            do
            {
                Console.WriteLine($"TURNO {contaTurno}:");
                Console.WriteLine($"{h.Nome} attacca {m.Nome} con {armaEroe.Nome}");

                nuoviPuntiVitaMostro -= armaEroe.PuntiDanno;
                Console.WriteLine($"Hai tolto {armaEroe.PuntiDanno} Punti Vita al Mostro");
                Console.WriteLine();
                contaTurno++;

                if (nuoviPuntiVitaMostro <= 0)
                {
                    Console.WriteLine("Hai vinto!");
                    int puntiVinti = CalcolaPuntiAttacco(m.Livello);
                    eroeAttivo.PuntiAccumulati += puntiVinti;
                    Console.WriteLine($"{h.Nome} ha accumulato {puntiVinti} punti. Punti totali: {eroeAttivo.PuntiAccumulati}");
                    ContinuaEsecuzione();
                }
                else
                {
                    Console.WriteLine($"Il Mostro ha ancora {nuoviPuntiVitaMostro} Punti Vita");
                    ContinuaEsecuzione();
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 120));
                    Console.WriteLine();
                    Console.WriteLine($"TURNO {contaTurno}:");
                    Console.WriteLine($"{m.Nome} attacca {h.Nome} con {armaMostro.Nome}");

                    nuoviPuntiVitaEroe -= armaMostro.PuntiDanno;
                    Console.WriteLine($"Il Mostro ti ha tolto {armaMostro.PuntiDanno} Punti Vita");

                    Console.WriteLine();
                    contaTurno++;

                    if (nuoviPuntiVitaEroe <= 0)
                    {
                        Console.WriteLine("Hai Perso...");
                        ContinuaEsecuzione();
                    }
                    else
                    {
                        Console.WriteLine($"Hai ancora {nuoviPuntiVitaMostro} Punti Vita");
                        ContinuaEsecuzione();
                        Console.WriteLine();
                        Console.WriteLine(new string('-', 120));
                        Console.WriteLine();
                    }
                }
            } while (nuoviPuntiVitaEroe > 0 && nuoviPuntiVitaMostro > 0);

            return eroeAttivo;
        }

        public static Eroe AttackFailedEscape(Eroe h, Mostro m, Utente u)
        {
            Arma armaEroe = TrovaArmaDaPersonaggio(h);
            Arma armaMostro = TrovaArmaDaPersonaggio(m);
            int nuoviPuntiVitaEroe = h.PuntiVita;
            int nuoviPuntiVitaMostro = m.PuntiVita;
            int contaTurno = 1;

            Eroe eroeAttivo = new Eroe()
            {
                Id = h.Id,
                IdArma = h.IdArma,
                IdCategoria = h.IdCategoria,
                IdGiocatore = h.IdGiocatore,
                Nome = h.Nome,
                Categoria = h.Categoria,
                TipoArma = h.TipoArma,
                PuntiAccumulati = h.PuntiAccumulati,
                Livello = h.Livello
            };

            do
            {
                Console.WriteLine($"TURNO {contaTurno}:");
                Console.WriteLine($"{m.Nome} attacca {h.Nome} con {armaMostro.Nome}");

                nuoviPuntiVitaEroe -= armaMostro.PuntiDanno;
                Console.WriteLine($"Il Mostro ti ha tolto {armaMostro.PuntiDanno} Punti Vita");
                
                Console.WriteLine();
                contaTurno++;

                if (nuoviPuntiVitaEroe <= 0)
                {
                    Console.WriteLine("Hai perso...");
                    ContinuaEsecuzione();
                }
                else
                {
                    Console.WriteLine($"Hai ancora {nuoviPuntiVitaMostro} Punti Vita");
                    ContinuaEsecuzione();
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 120));
                    Console.WriteLine();

                    Console.WriteLine($"TURNO {contaTurno}:");
                    Console.WriteLine($"{h.Nome} attacca {m.Nome} con {armaEroe.Nome}");
                    

                    nuoviPuntiVitaMostro -= armaEroe.PuntiDanno;
                    Console.WriteLine($"Hai tolto {armaEroe.PuntiDanno} Punti Vita al Mostro");
                    
                    Console.WriteLine();
                    contaTurno++;

                    if (nuoviPuntiVitaMostro <= 0)
                    {
                        Console.WriteLine("Hai vinto!");
                        int puntiVinti = CalcolaPuntiAttacco(m.Livello);
                        eroeAttivo.PuntiAccumulati += puntiVinti;
                        Console.WriteLine($"{h.Nome} ha accumulato {puntiVinti} punti. Punti totali: {eroeAttivo.PuntiAccumulati}");
                        ContinuaEsecuzione();
                    }
                    else
                    {
                        Console.WriteLine($"Il Mostro ha ancora {nuoviPuntiVitaMostro} Punti Vita");
                        ContinuaEsecuzione();
                        Console.WriteLine();
                        Console.WriteLine(new string('-', 120));
                        Console.WriteLine();
                    }
                }
            } while (nuoviPuntiVitaEroe > 0 && nuoviPuntiVitaMostro > 0);

            return eroeAttivo;
        }

        public static Eroe Escape(Eroe h, Mostro m, Utente u)
        {
            bool[] checkFuga = { true, false };
            Random rnd = new Random();
            int fugaIndex = rnd.Next(0, checkFuga.Length);

            if (checkFuga[fugaIndex])
            {
                Eroe eroeFuggito = new Eroe()
                {
                    Id = h.Id,
                    IdArma = h.IdArma,
                    IdCategoria = h.IdCategoria,
                    IdGiocatore = h.IdGiocatore,
                    Nome = h.Nome,
                    Categoria = h.Categoria,
                    TipoArma = h.TipoArma,
                    PuntiAccumulati = h.PuntiAccumulati,
                    Livello = h.Livello
                };
                Console.WriteLine("Fuga avvenuta con successo");
                int puntiPersi = CalcolaPuntiFuga(m.Livello);
                eroeFuggito.PuntiAccumulati -= puntiPersi;
                Console.WriteLine($"{h.Nome} ha perso {puntiPersi} punti. Punti totali: {eroeFuggito.PuntiAccumulati}");
                ContinuaEsecuzione();
                return h;
            }
            else
            {
                Console.WriteLine("Oh no! Non sei riuscito a fuggire...");
                ContinuaEsecuzione();
                Eroe eroeNonFuggito = AttackFailedEscape(h, m, u);
                return eroeNonFuggito;
            }
            return h;
        }

        private static void CheckPuntiAccumulati(Eroe h)
        {
            if (h.PuntiAccumulati > 29 && h.Livello == 1)
            {
                AumentaLivello(h);
            }
            if (h.PuntiAccumulati > 59 && h.Livello == 2)
            {
                AumentaLivello(h);
            }
            if (h.PuntiAccumulati > 89 && h.Livello == 3)
            {
                AumentaLivello(h);
            }
            if (h.PuntiAccumulati > 119 && h.Livello == 4)
            {
                AumentaLivello(h);
            }
        }

        private static void AumentaLivello(Eroe e)
        {
            e.Livello += 1;
            e.PuntiAccumulati = 0;
        }

        private static int CalcolaPuntiAttacco(int livelloMostro)
        {
            int puntiVinti = livelloMostro * 10;

            return puntiVinti;
        }

        private static int CalcolaPuntiFuga(int livelloMostro)
        {
            int puntiPersi = livelloMostro * 5;

            return puntiPersi;
        }

        public static bool CheckAdmin(Eroe e, Utente u)
        {
            if (e.Livello == 3)
            {
                if (!u.Admin)
                {
                    u.Admin = true;
                    Console.Clear();
                    Console.WriteLine("------*** Adesso sei un utente Admin! ***------");
                    ContinuaEsecuzione();
                }
            }
            return u.Admin;
        }

        private static Eroe CheckGame(Eroe eroeDiPartenza, Eroe eroeModificato, Utente u)
        {
            if(eroeDiPartenza.PuntiAccumulati != eroeModificato.PuntiAccumulati)
            {
                CheckPuntiAccumulati(eroeModificato);

                u.Admin = CheckAdmin(eroeModificato, u);

                AggiornaDbUtenti(u);
            }

            return eroeModificato;
        }

        public static Utente CheckGameUser(Eroe eroeDiPartenza, Eroe eroeModificato, Utente u)
        {
            if (eroeDiPartenza.PuntiAccumulati != eroeModificato.PuntiAccumulati)
            {
                u.Admin = CheckAdmin(eroeModificato, u);

                AggiornaDbUtenti(u);
            }

            return u;
        }

        //public static void OttieniStat()
        //{
        //    int limiteClassifica = 10;

        //    List<Utente> utenti = GetListUserForStats();
        //    List<Eroe> eroi = GetListHeroForStats();

        //    List<Eroe> topTenHero = new List<Eroe>();

        //    if(eroi.Count > limiteClassifica)
        //    {
        //        for (int i = 0; i < limiteClassifica; i++)
        //        {
        //            //if(eroi[i].Livello > eroi[++i].Livello)
        //            //{
        //            //    topTenHero.Add()
        //            //}
        //        }
        //    }
            
        //}
    }
}
