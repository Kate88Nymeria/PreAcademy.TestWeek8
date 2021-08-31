using System;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer.Entities;

namespace DbLayer
{
    public class EroeAdoRepository
    {
        private static string ConnectionString;

        public EroeAdoRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

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
                    if(row.Field<int>("IdCategorie") == 1)
                    {
                        hero = new Guerriero()
                        {
                            Nome = name
                        };
                    }
                    else if(row.Field<int>("IdCategorie") == 2)
                    {
                        hero = new Mago()
                        {
                            Nome = name
                        };
                    }
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

                    heroAdapter.Update(heroDs, "Eroi");
                    heroAdapter.Fill(heroDs, "Eroi");
                }
            }
            return;
        }

        #region operazioni di CRUD

        public void AggiungiNuovoEroe(Eroe hero) //da controllare quando riesco a trovare l'id utente
        {
            DataRow nuovaRiga = heroDs.Tables["Eroi"].NewRow();

            nuovaRiga["Id"] = hero.Id;
            nuovaRiga["Nome"] = hero.Nome;
            nuovaRiga["Livello"] = hero.Livello;
            nuovaRiga["Punti"] = hero.Punti;
            nuovaRiga["Arma"] = hero.TipoDiArma; //verifica correttezza

            heroDs.Tables["Eroi"].Rows.Add(nuovaRiga);
            AggiornaDatabase();
        }

        public void EliminaEroe(int id) //da controllare quando riesco ad inserire eroi
        {
            DataRow rigaDaEliminare = heroDs.Tables["Eroi"].Rows.Find(id);
            rigaDaEliminare?.Delete();

            AggiornaDatabase();
        }

        public void StampaListaEroi(Utente user) //da controllare quando risolta la questione dell'id
        {
            Console.WriteLine("====== ELENCO EROI ======");
            Console.WriteLine();

            Console.WriteLine("{0,-10}{1,-30}{2,-9}{3,-7}{4,12}{5,5}",
                "Id", "Nome", "Livello", "Punti", "Categoria", "Arma");
            Console.WriteLine(new string('-', 120));

            foreach (DataRow riga in heroDs.Tables["Eroi"].Rows)
            {
                if(riga.Field<int>("IdUtenti") == user.Id)//non mi visualizza l'id del db
                {
                    Console.WriteLine("{0,-10}{1,-30}{2,-9}{3,-7}{4,12}{5,5}",
                       riga["Id"],
                       riga["Nome"],
                       riga["Livello"],
                       riga["Punti"],
                       riga["IdCategorie"],
                       riga["IdArmi"]
                    );
                }
            }
        }

        #endregion

        #region metodi di servizio per comandi

        SqlCommand CommandInsertHero(SqlConnection connessione)
        {
            string comando = "INSERT INTO Eroi " +
                "VALUES (@Nome, @Livello, @Punti, @IdCategorie, @IdArmi, @IdUtenti)";

            SqlCommand insertCommand = new SqlCommand(comando, connessione);
            insertCommand.CommandType = CommandType.Text;

            insertCommand.Parameters.Add(new SqlParameter("@Nome", SqlDbType.NVarChar, 20, "Nickname"));
            insertCommand.Parameters.Add(new SqlParameter("@Livello", SqlDbType.Int, 1, "Password"));
            insertCommand.Parameters.Add(new SqlParameter("@Punti", SqlDbType.Int, 5, "Admin"));
            insertCommand.Parameters.Add(new SqlParameter("@IdCategorie", SqlDbType.Int, 1, "Admin"));
            insertCommand.Parameters.Add(new SqlParameter("@IdArmi", SqlDbType.Int, 2, "Admin"));
            insertCommand.Parameters.Add(new SqlParameter("@IdUtenti", SqlDbType.Int, 10, "Admin"));


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

        #endregion

    }
}
