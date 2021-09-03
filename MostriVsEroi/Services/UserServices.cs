using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Utilities.Forms;
using static BusinessLayer.Utilities.Helpers;
using static DbLayer.UtenteAdoRepository;
using DbLayer;
using System.Data;

namespace Services
{
    public class UserServices
    {
        public static readonly UtenteAdoRepository UserAR = new UtenteAdoRepository();

        public static void AggiornaDbUtenti(Utente u)
        {
            if (UserAR.Init())
            {
                UserAR.ModificaUtente(u);
            }
        }

        //public static List<Utente> GetListUserForStats()
        //{
        //    List<Utente> utenti = new List<Utente>();
        //    Utente u = null;

        //    List<DataRow> righe = UserAR.ListaUtenti();

        //    if (righe.Count > 0)
        //    {
        //        foreach (DataRow rigaScelta in righe)
        //        {
        //            u = new Utente()
        //            {
        //                Id = rigaScelta.Field<int>("Id"),
        //                Nickname = rigaScelta.Field<string>("Nickname"),
        //                Password = rigaScelta.Field<string>("Password"),
        //                Admin = rigaScelta.Field<bool>("Admin")
        //            };

        //            utenti.Add(u);
        //        }
        //    }
        //    return utenti;
        //}
    }
}
