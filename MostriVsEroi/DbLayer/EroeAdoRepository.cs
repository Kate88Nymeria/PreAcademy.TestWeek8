using System;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer.Entities;

namespace DbLayer
{
    public class EroeAdoRepository
    {
        public const string ConnectionString = "Server = (localdb)\\mssqllocaldb; " +
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

                    heroAdapter.SelectCommand = selectHero;
                    heroAdapter.Fill(heroDs, "Eroi");
                }
            }
            return true;
        }

        //public static Eroe SearchHero(string name)
        //{
        //    Eroe hero = null;

        //    foreach (DataRow row in heroDs.Tables["Eroi"].Rows)
        //    {
        //        if (row.Field<string>("Nome") == name)
        //        {
        //            hero = new Eroe()
        //            {
        //                Nome = name,
        //                IdCategoria = row.Field<int>("IdCategorie"),
        //                IdArma = row.Field<int>("IdArma"),
        //                Id = row.Field<int>("Id"),
        //                //PuntiVita = row.Field<int>("Punti"),
        //                Livello = row.Field<int>("Livello"),
        //                PuntiAccumulati = row.Field<int>("Punti")
        //            };
        //        }
        //    }
        //    return hero;
        //}

        //public static bool VerificaNomeEroe(string nome)
        //{
        //    string comando = "SELECT * from Eroi where Nome=@Nome";

        //    SqlCommand command = new SqlCommand(comando, conn);
        //    command.CommandType = CommandType.Text;

        //    command.Parameters.AddWithValue("@Nome", nome);

        //    SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        string nomeEroe = (string)reader["Nome"];
        //        if(nomeEroe == nome)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

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

        public void AggiungiNuovoEroe(Eroe hero)
        {
            DataRow nuovaRiga = heroDs.Tables["Eroi"].NewRow();

            nuovaRiga["Id"] = hero.Id;
            nuovaRiga["Nome"] = hero.Nome;
            nuovaRiga["Livello"] = hero.Livello;
            nuovaRiga["Punti"] = hero.PuntiAccumulati;
            nuovaRiga["IdArmi"] = hero.TipoArma.Id;
            nuovaRiga["IdCategorie"] = hero.IdCategoria;
            nuovaRiga["IdUtenti"] = hero.IdGiocatore;

            heroDs.Tables["Eroi"].Rows.Add(nuovaRiga);
            AggiornaDatabase();
        }

        public void EliminaEroe(int id) //da controllare quando riesco ad inserire eroi
        {
            DataRow rigaDaEliminare = heroDs.Tables["Eroi"].Rows.Find(id);
            rigaDaEliminare?.Delete();

            AggiornaDatabase();
        }

        public void StampaListaEroi(Utente user)
        {
            Console.WriteLine("{0,-10}{1,-30}{2,-9}{3,-7}{4,12}{5,5}",
                "Id", "Nome", "Livello", "Punti", "Categoria", "Arma");
            Console.WriteLine(new string('-', 120));

            foreach (DataRow riga in heroDs.Tables["Eroi"].Rows)
            {
                if (riga.Field<int>("IdUtenti") == user.Id)
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

            insertCommand.Parameters.Add(new SqlParameter("@Nome", SqlDbType.NVarChar, 20, "Nome"));
            insertCommand.Parameters.Add(new SqlParameter("@Livello", SqlDbType.Int, 1, "Livello"));
            insertCommand.Parameters.Add(new SqlParameter("@Punti", SqlDbType.Int, 5, "Punti"));
            insertCommand.Parameters.Add(new SqlParameter("@IdCategorie", SqlDbType.Int, 1, "IdCategoria"));
            insertCommand.Parameters.Add(new SqlParameter("@IdArmi", SqlDbType.Int, 2, "IdArma"));
            insertCommand.Parameters.Add(new SqlParameter("@IdUtenti", SqlDbType.Int, 10, "IdGiocatore"));


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
