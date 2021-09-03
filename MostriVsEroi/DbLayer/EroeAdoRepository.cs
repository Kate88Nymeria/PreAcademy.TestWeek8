using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer.Entities;
using static BusinessLayer.Utilities.Helpers;

namespace DbLayer
{
    public class EroeAdoRepository
    {
        const string ConnectionString = "Server = (localdb)\\mssqllocaldb; " +
            "Database = MostriVsEroi; Trusted_Connection = True;";

        private static SqlConnection conn;
        public static DataSet heroDs = new DataSet();
        private SqlDataAdapter heroAdapter;

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
                    heroAdapter = new SqlDataAdapter();
                    heroAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    SqlCommand selectHero = new SqlCommand("SELECT * FROM Eroi", conn);

                    heroAdapter.SelectCommand = selectHero;
                    heroAdapter.InsertCommand = CommandInsertHero(conn);
                    heroAdapter.DeleteCommand = CommandDeleteHero(conn);
                    heroAdapter.UpdateCommand = CommandUpdateHero(conn);

                    heroAdapter.SelectCommand = selectHero;
                    heroAdapter.Fill(heroDs, "Eroi");
                }
            }
            return true;
        }

        public static Eroe SearchHero(string name)
        {
            Eroe hero = null;

            foreach (DataRow row in heroDs.Tables["Eroi"].Rows)
            {
                if (row.Field<string>("Nome") == name)
                {
                    hero = new Eroe()
                    {
                        Nome = name,
                        IdCategoria = row.Field<int>("IdCategorie"),
                        IdArma = row.Field<int>("IdArma"),
                        Id = row.Field<int>("Id"),
                        //PuntiVita = row.Field<int>("Punti"),
                        Livello = row.Field<int>("Livello"),
                        PuntiAccumulati = row.Field<int>("Punti")
                    };
                }
            }
            return hero;
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
                    heroAdapter.SelectCommand.Connection = conn;
                    heroAdapter.InsertCommand.Connection = conn;
                    heroAdapter.DeleteCommand.Connection = conn;
                    heroAdapter.UpdateCommand.Connection = conn;

                    heroAdapter.Update(heroDs, "Eroi");
                    heroAdapter.Fill(heroDs, "Eroi");
                }
            }
            return;
        }

        #region operazioni di CRUD

        public void AggiungiNuovoEroe(Eroe hero)
        {
            DataRow nuovaRiga = heroDs.Tables["Eroi"].NewRow();

            nuovaRiga["Nome"] = hero.Nome;
            nuovaRiga["Livello"] = hero.Livello;
            nuovaRiga["Punti"] = hero.PuntiAccumulati;
            nuovaRiga["IdCategorie"] = hero.IdCategoria;
            nuovaRiga["IdArmi"] = hero.IdArma;
            nuovaRiga["IdUtenti"] = hero.IdGiocatore;

            heroDs.Tables["Eroi"].Rows.Add(nuovaRiga);
            AggiornaDatabase();
        }

        public void ModificaEroe(Eroe hero)
        {
            DataRow rigaDaModificare = heroDs.Tables["Eroi"].Rows.Find(hero.Id);

            if(rigaDaModificare != null)
            {
                rigaDaModificare["Livello"] = hero.Livello;
                rigaDaModificare["Punti"] = hero.PuntiAccumulati;
            }

            AggiornaDatabase();
        }

        public void EliminaEroe(int id)
        {
            DataRow rigaDaEliminare = heroDs.Tables["Eroi"].Rows.Find(id);
            rigaDaEliminare?.Delete();

            AggiornaDatabase();
        }

        public List<DataRow> ListaEroi()
        {
            List<DataRow> righe = new List<DataRow>();
            foreach (DataRow riga in heroDs.Tables["Eroi"].Rows)
            {
                righe.Add(riga);
            }
            return righe;
        }

        public List<DataRow> ListaEroiUtente(int userId)
        {
            List<DataRow> righe = new List<DataRow>();
            foreach (DataRow riga in heroDs.Tables["Eroi"].Rows)
            {
                if (riga.Field<int>("IdUtenti") == userId)
                {
                    righe.Add(riga);
                }
            }
            return righe;
        }
        public void StampaListaEroi(Utente user)
        {
            Console.WriteLine("{0,-10}{1,-30}{2,-9}{3,12}{4,10}{5,20}",
                "Id", "Nome", "Livello", "Categoria", "Arma", "Punti Accumulati");
            Console.WriteLine(new string('-', 120));

            foreach (DataRow riga in heroDs.Tables["Eroi"].Rows)
            {
                if (riga.Field<int>("IdUtenti") == user.Id)
                {
                    Console.WriteLine("{0,-10}{1,-30}{2,-9}{3,12}{4,10}{5,20}",
                    riga["Id"],
                    riga["Nome"],
                    riga["Livello"],
                    riga["IdCategorie"],
                    riga["IdArmi"],
                    riga["Punti"]
                    );
                }
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 120));
            Console.WriteLine();
        }

        #endregion

        #region metodi di servizio per comandi

        SqlCommand CommandInsertHero(SqlConnection connessione)
        {
            string comando = "INSERT INTO Eroi " +
                "VALUES (@Nome, @Livello, @Punti, @IdCategorie, @IdArmi, @IdUtenti)";

            SqlCommand insertCommand = new SqlCommand(comando, connessione);
            insertCommand.CommandType = CommandType.Text;

            insertCommand.Parameters.Add(new SqlParameter("@Nome", SqlDbType.NVarChar, 20, "Nome"));
            insertCommand.Parameters.Add(new SqlParameter("@Livello", SqlDbType.Int, 1, "Livello"));
            insertCommand.Parameters.Add(new SqlParameter("@Punti", SqlDbType.Int, 5, "Punti"));
            insertCommand.Parameters.Add(new SqlParameter("@IdCategorie", SqlDbType.Int, 1, "IdCategorie"));
            insertCommand.Parameters.Add(new SqlParameter("@IdArmi", SqlDbType.Int, 2, "IdArmi"));
            insertCommand.Parameters.Add(new SqlParameter("@IdUtenti", SqlDbType.Int, 10, "IdUtenti"));

            return insertCommand;
        }

        SqlCommand CommandDeleteHero(SqlConnection connessione)
        {
            string comando = "DELETE FROM Eroi WHERE Id = @Id";

            SqlCommand deleteCommand = new SqlCommand(comando, connessione);
            deleteCommand.CommandType = CommandType.Text;

            deleteCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 5, "Id"));

            return deleteCommand;
        }

        SqlCommand CommandUpdateHero(SqlConnection connessione)
        {
            string comando = "UPDATE Eroi " +
                "SET Livello = @Livello, " +
                    "Punti = @Punti " +
                    "WHERE Id = @Id";

            SqlCommand updateCommand = new SqlCommand(comando, connessione);
            updateCommand.CommandType = CommandType.Text;

            updateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 100, "Id"));
            updateCommand.Parameters.Add(new SqlParameter("@Livello", SqlDbType.Int, 1, "Livello"));
            updateCommand.Parameters.Add(new SqlParameter("@Punti", SqlDbType.Int, 5, "Punti"));

            return updateCommand;
        }

        #endregion
    }
}
