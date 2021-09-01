using System;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer.Entities;

namespace DbLayer
{
    public class MostroAdoRepository
    {
        public static readonly string ConnectionString = "Server = (localdb)\\mssqllocaldb; " +
            "Database = MostriVsEroi; Trusted_Connection = True;";

        private static SqlConnection conn;
        public static DataSet monsterDs = new DataSet();
        private SqlDataAdapter monsterAdapter;

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
                    monsterAdapter = new SqlDataAdapter();
                    monsterAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    SqlCommand selectMonster = new SqlCommand("SELECT * FROM Mostri", conn);

                    monsterAdapter.SelectCommand = selectMonster ;
                    monsterAdapter.InsertCommand = CommandInsertMonster(conn);

                    monsterAdapter.SelectCommand = selectMonster;
                    monsterAdapter.Fill(monsterDs, "Mostri");
                }
            }
            return true;
        }

        public static Mostro SearchMonster(string name)
        {
            Mostro monster = new Mostro();

            foreach (DataRow row in monsterDs.Tables["Mostri"].Rows)
            {
                if (row.Field<string>("Nome") == name)
                {
                    monster.Nome = name;
                }
                else
                {
                    monster = null;
                }
            }
            return monster;
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
                    monsterAdapter.SelectCommand.Connection = conn;
                    monsterAdapter.InsertCommand.Connection = conn;

                    monsterAdapter.Update(monsterDs, "Mostri");
                    monsterAdapter.Fill(monsterDs, "Mostri");
                }
            }
            return;
        }

        #region operazioni di CRUD

        public void AggiungiNuovoMostro(Mostro monster)
        {
            DataRow nuovaRiga = monsterDs.Tables["Mostri"].NewRow();

            nuovaRiga["Nome"] = monster.Nome;
            nuovaRiga["Livello"] = monster.Livello;
            nuovaRiga["Arma"] = monster.TipoArma; //verifica correttezza

            monsterDs.Tables["Mostri"].Rows.Add(nuovaRiga);
            AggiornaDatabase();
        }

        //public void StampaListaEroi(Utente user) //da controllare quando risolta la questione dell'id
        //{
        //    Console.WriteLine("====== ELENCO EROI ======");
        //    Console.WriteLine();

        //    Console.WriteLine("{0,-10}{1,-30}{2,-9}{3,-7}{4,12}{5,5}",
        //        "Id", "Nome", "Livello", "Punti", "Categoria", "Arma");
        //    Console.WriteLine(new string('-', 120));

        //    foreach (DataRow riga in heroDs.Tables["Eroi"].Rows)
        //    {
        //        if (riga.Field<int>("IdUtenti") == user.Id)//non mi visualizza l'id del db
        //        {
        //            Console.WriteLine("{0,-10}{1,-30}{2,-9}{3,-7}{4,12}{5,5}",
        //               riga["Id"],
        //               riga["Nome"],
        //               riga["Livello"],
        //               riga["Punti"],
        //               riga["IdCategorie"],
        //               riga["IdArmi"]
        //            );
        //        }
        //    }
        //}

        #endregion

        #region metodi di servizio per comandi

        SqlCommand CommandInsertMonster(SqlConnection connessione)
        {
            string comando = "INSERT INTO Mostri " +
                "VALUES (@Nome, @Livello, @IdArmi)";

            SqlCommand insertCommand = new SqlCommand(comando, connessione);
            insertCommand.CommandType = CommandType.Text;

            insertCommand.Parameters.Add(new SqlParameter("@Nome", SqlDbType.NVarChar, 20, "Nickname"));
            insertCommand.Parameters.Add(new SqlParameter("@Livello", SqlDbType.Int, 1, "Password"));
            insertCommand.Parameters.Add(new SqlParameter("@IdArmi", SqlDbType.Int, 2, "Admin"));

            return insertCommand;
        }

        #endregion

    }
}
