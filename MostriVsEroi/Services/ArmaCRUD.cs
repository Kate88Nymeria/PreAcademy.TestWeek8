using BusinessLayer.Entities;
using DbLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static BusinessLayer.Utilities.Helpers;
using static DbLayer.ArmaAdoRepository;


namespace Services
{
    public class ArmaCRUD
    {
        public static readonly ArmaAdoRepository ArmAR = new ArmaAdoRepository();
        public static void MostraRigheArmi()
        {
            Arma arm = null;

            if (ArmAR.Init())
            {
                Console.WriteLine("====== LISTA ARMI ======");
                Console.WriteLine();

                List<DataRow> records = ArmAR.ListaRigheArmi();

                if (records.Count > 0)
                {
                    ArmAR.StampaListaRigheArmi(records);
                }
                else
                {
                    Console.WriteLine("Non ci sono Mostri inseriti");
                    ContinuaEsecuzione();
                }
            }
        }

        public static Arma TrovaArmaDaPersonaggio(Personaggio p)
        {
            Arma armaUsata = null;

            if (ArmAR.Init())
            {
                List<DataRow> righe = ArmAR.ListaRigheArmi();

                if (righe.Count > 0)
                {
                    DataRow rigaScelta = armDs.Tables["Armi"].Rows.Find(p.IdArma);

                    armaUsata = new Arma()
                    {
                        Id = p.IdArma,
                        Nome = rigaScelta.Field<string>("Nome"),
                        PuntiDanno = rigaScelta.Field<int>("PuntiDanno")
                    };
                }
                else
                {
                    Console.WriteLine("Non ci sono Armi inserite");
                    armaUsata = null;
                    ContinuaEsecuzione();
                }
            }
            return armaUsata;
        }
    }
}
