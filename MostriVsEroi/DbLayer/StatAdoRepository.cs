using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DbLayer
{
    public class StatAdoRepository
    {
        const string ConnectionString = "Server = (localdb)\\mssqllocaldb; " +
            "Database = MostriVsEroi; Trusted_Connection = True;";

        private static SqlConnection conn;
        public static DataSet statDs = new DataSet();
        private SqlDataAdapter statAdapter;

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
                    statAdapter = new SqlDataAdapter();
                    statAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    SqlCommand selectHero = new SqlCommand("SELECT * FROM EroiUtenti", conn);

                    statAdapter.SelectCommand = selectHero;

                    statAdapter.SelectCommand = selectHero;
                    statAdapter.Fill(statDs, "EroiUtenti");
                }
            }
            return true;
        }

        public bool InitId()
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
                    statAdapter = new SqlDataAdapter();
                    statAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    SqlCommand selectHero = new SqlCommand("SELECT * FROM EroiUtentiId", conn);

                    statAdapter.SelectCommand = selectHero;

                    statAdapter.SelectCommand = selectHero;
                    statAdapter.Fill(statDs, "EroiUtentiId");
                }
            }
            return true;
        }


        public void StampaRecordsPerClassifica()
        {
            Console.WriteLine("{0,-10}{1,-25}{2,-10}{3,-13}{4,-17}{5,10}{6,12}{7,17}",
                "Id Eroe", "Nome", "Livello", "Categoria", "Arma", 
                "Punti", "Punti Vita", "Giocatore");
            Console.WriteLine(new string('-', 120));

            foreach (DataRow riga in statDs.Tables["EroiUtenti"].Rows)
            {
                Console.WriteLine("{0,-10}{1,-25}{2,-10}{3,-13}{4,-17}{5,10}{6,12}{7,17}",
                riga["Id"],
                riga["Nome"],
                riga["Livello"],
                riga["Expr3"],
                riga["Expr2"],
                riga["Punti"],
                riga["PuntiVita"],
                riga["Nickname"]
                );
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 120));
            Console.WriteLine();
        }

        public void StampaRecordsPerClassificaId()
        {
            Console.WriteLine("{0,-12}{1,-25}{2,-10}{3,-10}{4,-10}{5,10}{6,12}{7,25}{8,7}",
                "Id Eroe", "Nome", "Livello", "Categoria", "Arma",
                "Punti", "Punti Vita", "Giocatore", "Admin");
            Console.WriteLine(new string('-', 130));

            foreach (DataRow riga in statDs.Tables["EroiUtentiId"].Rows)
            {
                Console.WriteLine("{0,-12}{1,-25}{2,-10}{3,-10}{4,-10}{5,10}{6,12}{7,25}{8,7}",
                riga["Id"],
                riga["Nome"],
                riga["Livello"],
                riga["IdCategorie"],
                riga["IdArmi"],
                riga["Punti"],
                riga["PuntiVita"],
                riga["Nickname"],
                riga["Admin"]
                );
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 130));
            Console.WriteLine();
        }
    }
}
