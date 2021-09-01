using System;
using BusinessLayer.Entities;
using static PresentationLayer.Utilities.Helpers;

namespace PresentationLayer.Utilities
{
    public class Forms
    {
        #region Utente
        public static Utente InserimentoDatiUtente()
        {
            Utente user = new Utente();

            Console.WriteLine("Inserisci Nickname");
            string username = CheckValidString();

            Console.WriteLine();

            Console.WriteLine("Inserisci Password");
            string password = CheckValidString();

            user.Nickname = username;
            user.Password = password;

            return user;
        }

        public static bool LoginUser(Utente user)
        {
            if (user == null)
            {
                Console.WriteLine("Nickname inesistente");
                return false;
            }
            return true;
        }

        public static bool RegisterUser(Utente user)
        {
            if (user != null)
            {
                Console.WriteLine("Nickname già esistente");
                return false;
            }
            return true;
        }

        #endregion

        #region Eroe
        public static Eroe InserimentoDatiEroe()
        {
            Console.WriteLine("Inserisci il Nome dell'Eroe");
            string name = CheckValidString();

            Console.Clear();
            Console.WriteLine($"Nome Eroe: {name}");

            string categoria = SelectTypeOfHero();

            Console.Clear();

            Console.WriteLine($"Nome Eroe: {name}\t{categoria.ToUpper()}");
            Console.WriteLine();

            Arma arma = null;

            if (categoria == "Guerriero")
            {
                arma = SelectWarriorArm();
            }
            else
            {
                arma = SelectMagicianArm();
            }

            Eroe hero = new Eroe(name, categoria, arma);

            return hero;
        }


        //public static bool ExistHero(bool exists, int userId, Eroe hero)
        //{
        //    if (exists && hero.IdGiocatore == userId)
        //    {
        //        Console.WriteLine("Nome Eroe già esistente per questo utente");
        //        return false;
        //    }
        //    return true;
        //}
        public static bool ExistHero(Eroe eroeCercato, int userId, Eroe hero)
        {
            if (eroeCercato != null && hero.IdGiocatore == userId)
            {
                Console.WriteLine("Nome Eroe già esistente per questo utente");
                return false;
            }
            return true;
        }

        public static string SelectTypeOfHero()
        {
            bool continuare = true;
            int scelta;
            string categoria = "";

            do
            {
                Console.WriteLine("Quale tipo di Eroe vuoi creare?");
                Console.WriteLine("[ 1 ] - Guerriero");
                Console.WriteLine("[ 2 ] - Mago");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        categoria = "Guerriero";
                        continuare = false;
                        break;
                    case 2:
                        Console.Clear();
                        categoria = "Mago";
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);

            return categoria;
        }

        public static Arma SelectWarriorArm()
        {
            bool continuare = true;
            int scelta;

            Arma arma = new Arma();

            do
            {
                Console.WriteLine("Quale Arma vuoi scegliere?");
                Console.WriteLine("[ 1 ] - Alabarda");
                Console.WriteLine("[ 2 ] - Ascia");
                Console.WriteLine("[ 3 ] - Mazza");
                Console.WriteLine("[ 4 ] - Spada");
                Console.WriteLine("[ 5 ] - Spadone");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        arma.Nome = "Alabarda";
                        arma.PuntiDanno = 15;
                        continuare = false;
                        break;
                    case 2:
                        Console.Clear();
                        arma.Nome = "Ascia";
                        arma.PuntiDanno = 8;
                        continuare = false;
                        break;
                    case 3:
                        Console.Clear();
                        arma.Nome = "Mazza";
                        arma.PuntiDanno = 5;
                        continuare = false;
                        break;
                    case 4:
                        Console.Clear();
                        arma.Nome = "Spada";
                        arma.PuntiDanno = 1;
                        continuare = false;
                        break;
                    case 5:
                        Console.Clear();
                        arma.Nome = "Spadone";
                        arma.PuntiDanno = 15;
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);

            return arma;
        }

        public static Arma SelectMagicianArm()
        {
            bool continuare = true;
            int scelta;

            Arma arma = new Arma();

            do
            {
                Console.WriteLine("Quale Arma vuoi scegliere?");
                Console.WriteLine("[ 1 ] - Arco e Frecce");
                Console.WriteLine("[ 2 ] - Bacchetta");
                Console.WriteLine("[ 3 ] - Bastone Magico");
                Console.WriteLine("[ 4 ] - Onda d'Urto");
                Console.WriteLine("[ 5 ] - Pugnale");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        arma.Nome = "Arco e Frecce";
                        arma.PuntiDanno = 8;
                        continuare = false;
                        break;
                    case 2:
                        Console.Clear();
                        arma.Nome = "Bacchetta";
                        arma.PuntiDanno = 5;
                        continuare = false;
                        break;
                    case 3:
                        Console.Clear();
                        arma.Nome = "Bastone Magico";
                        arma.PuntiDanno = 10;
                        continuare = false;
                        break;
                    case 4:
                        Console.Clear();
                        arma.Nome = "Onda d'Urto";
                        arma.PuntiDanno = 15;
                        continuare = false;
                        break;
                    case 5:
                        Console.Clear();
                        arma.Nome = "Pugnale";
                        arma.PuntiDanno = 5;
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);

            return arma;
        }

        #endregion

        #region Mostro
        public static Mostro InserimentoDatiMostro()
        {
            Console.WriteLine("Inserisci il Nome del Mostro");
            string name = CheckValidString();

            Console.Clear();
            Console.WriteLine($"Nome Mostro: {name}");

            string categoria = SelectTypeOfMonster();

            Console.Clear();

            Console.WriteLine($"Nome Mostro: {name}\t{categoria.ToUpper()}");
            Console.WriteLine();

            Arma arma = null;

            if (categoria == "Cultista")
            {
                arma = SelectCultistArm();
            }
            else if(categoria == "Orco")
            {
                arma = SelectOrcArm();
            }
            else
            {
                arma = SelectEvilLordArm();
            }

            Console.Clear();

            Console.WriteLine($"Nome Mostro: {name}\t{categoria.ToUpper()}");
            Console.WriteLine();
            Console.WriteLine("Inserisci il Livello del Mostro");
            int level = CheckLevel();

            Mostro monster = new Mostro(name, categoria, arma, level);

            Console.WriteLine();
            Console.WriteLine("Mostro creato");

            return monster;
        }

        public static bool ExistMonster(Mostro monster)
        {
            if (monster != null)
            {
                Console.WriteLine("Nome Mostro già esistente");
                return false;
            }
            return true;
        }

        public static string SelectTypeOfMonster()
        {
            bool continuare = true;
            int scelta;
            string categoria = "";

            do
            {
                Console.WriteLine("Quale tipo di Mostro vuoi creare?");
                Console.WriteLine("[ 1 ] - Cultista");
                Console.WriteLine("[ 2 ] - Orco");
                Console.WriteLine("[ 3 ] - Signore del Male");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        categoria = "Cultista";
                        continuare = false;
                        break;
                    case 2:
                        Console.Clear();
                        categoria = "Orco";
                        continuare = false;
                        break;
                    case 3:
                        Console.Clear();
                        categoria = "Signore del Male";
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);

            return categoria;
        }

        public static Arma SelectCultistArm()
        {
            bool continuare = true;
            int scelta;

            Arma arma = new Arma();

            do
            {
                Console.WriteLine("Quale Arma vuoi scegliere?");
                Console.WriteLine("[ 1 ] - Discorso Noioso");
                Console.WriteLine("[ 2 ] - Farneticazione");
                Console.WriteLine("[ 3 ] - Imprecazione");
                Console.WriteLine("[ 4 ] - Magia Nera");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        arma.Nome = "Discorso Noioso";
                        arma.PuntiDanno = 4;
                        continuare = false;
                        break;
                    case 2:
                        Console.Clear();
                        arma.Nome = "Farneticazione";
                        arma.PuntiDanno = 7;
                        continuare = false;
                        break;
                    case 3:
                        Console.Clear();
                        arma.Nome = "Imprecazione";
                        arma.PuntiDanno = 5;
                        continuare = false;
                        break;
                    case 4:
                        Console.Clear();
                        arma.Nome = "Magia Nera";
                        arma.PuntiDanno = 3;
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);

            return arma;
        }

        public static Arma SelectOrcArm()
        {
            bool continuare = true;
            int scelta;

            Arma arma = new Arma();

            do
            {
                Console.WriteLine("Quale Arma vuoi scegliere?");
                Console.WriteLine("[ 1 ] - Arco");
                Console.WriteLine("[ 2 ] - Clava");
                Console.WriteLine("[ 3 ] - Spada Rotta");
                Console.WriteLine("[ 4 ] - Mazza Chiodata");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        arma.Nome = "Arco";
                        arma.PuntiDanno = 7;
                        continuare = false;
                        break;
                    case 2:
                        Console.Clear();
                        arma.Nome = "Clava";
                        arma.PuntiDanno = 5;
                        continuare = false;
                        break;
                    case 3:
                        Console.Clear();
                        arma.Nome = "Spada Rotta";
                        arma.PuntiDanno = 3;
                        continuare = false;
                        break;
                    case 4:
                        Console.Clear();
                        arma.Nome = "Mazza Chiodata";
                        arma.PuntiDanno = 10;
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);

            return arma;
        }

        public static Arma SelectEvilLordArm()
        {
            bool continuare = true;
            int scelta;

            Arma arma = new Arma();

            do
            {
                Console.WriteLine("Quale Arma vuoi scegliere?");
                Console.WriteLine("[ 1 ] - Alabarda del Drago");
                Console.WriteLine("[ 2 ] - Divinazione");
                Console.WriteLine("[ 3 ] - Fulmine");
                Console.WriteLine("[ 4 ] - Fulmine Celeste");
                Console.WriteLine("[ 5 ] - Tempesta");
                Console.WriteLine("[ 6 ] - Tempesta Oscura");

                scelta = CheckInt();

                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        arma.Nome = "Alabarda del Drago";
                        arma.PuntiDanno = 30;
                        continuare = false;
                        break;
                    case 2:
                        Console.Clear();
                        arma.Nome = "Divinazione";
                        arma.PuntiDanno = 15;
                        continuare = false;
                        break;
                    case 3:
                        Console.Clear();
                        arma.Nome = "Fulmine";
                        arma.PuntiDanno = 10;
                        continuare = false;
                        break;
                    case 4:
                        Console.Clear();
                        arma.Nome = "Fulmine Celeste";
                        arma.PuntiDanno = 15;
                        continuare = false;
                        break;
                    case 5:
                        Console.Clear();
                        arma.Nome = "Tempesta";
                        arma.PuntiDanno = 8;
                        continuare = false;
                        break;
                    case 6:
                        Console.Clear();
                        arma.Nome = "Tempesta Oscura";
                        arma.PuntiDanno = 15;
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Errore! Operazione non consentita.");
                        ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continuare);

            return arma;
        }

        #endregion
    }
}
