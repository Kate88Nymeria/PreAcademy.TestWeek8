using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DbLayer
{
    public class ArmaAdoRepository
    {
        public static readonly string ConnectionString = "Server = (localdb)\\mssqllocaldb; " +
           "Database = MostriVsEroi; Trusted_Connection = True;";

        private static SqlConnection conn;
        public static DataSet armDs = new DataSet();
        private SqlDataAdapter armAdapter;

        public bool Init()
        {
            Console.WriteLine("Attendere prego...");

            using (conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (SqlException)
                {
                    Console.WriteLine("Errore: connessione al database fallita.");
                    Console.ReadKey(true);
                    conn.Close();
                    return false;
                }

                if (conn.State == ConnectionState.Open)
                {
                    Console.Clear();
                    armAdapter = new SqlDataAdapter();
                    armAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    SqlCommand selectMonster = new SqlCommand("SELECT * FROM Armi", conn);

                    armAdapter.SelectCommand = selectMonster;

                    armAdapter.SelectCommand = selectMonster;
                    armAdapter.Fill(armDs, "Armi");
                }
            }
            return true;
        }

        public static Arma SearchArm(int id)
        {
            Arma a = new Arma();

            foreach (DataRow row in armDs.Tables["Armi"].Rows)
            {
                if (row.Field<int>("Id") == id)
                {
                    a.Id = id;
                }
                else
                {
                    a = null;
                }
            }
            return a;
        }

        public void AggiornaDatabase()
        {
            Console.WriteLine("Attendere prego...");
            using (conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (SqlException)
                {
                    Console.WriteLine("Errore: connessione al database fallita.");
                    Console.ReadKey(true);
                    conn.Close();
                    return;
                }

                if (conn.State == ConnectionState.Open)
                {
                    armAdapter.SelectCommand.Connection = conn;
                    armAdapter.InsertCommand.Connection = conn;

                    armAdapter.Update(armDs, "Mostri");
                    armAdapter.Fill(armDs, "Mostri");
                }
            }
            return;
        }

        #region operazioni di CRUD

        public void StampaListaRigheArmi(List<DataRow> righe)
        {
            Console.WriteLine("{0,-10}{1,-30}{2,-9}",
                "Id", "Nome", "PuntiDanno");
            Console.WriteLine(new string('-', 120));

            foreach (DataRow riga in righe)
            {
                Console.WriteLine("{0,-10}{1,-30}{2,-9}",
                riga["Id"],
                riga["Nome"],
                riga["PuntiDanno"]
                );
            }
        }

        public List<DataRow> ListaRigheArmi()
        {
            List<DataRow> righe = new List<DataRow>();
            foreach (DataRow riga in armDs.Tables["Armi"].Rows)
            {
                righe.Add(riga);
            }
            return righe;
        }

        #endregion
    }
}
