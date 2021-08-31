using System;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer.Entities;

namespace DbLayer
{
    public class UtenteAdoRepository
    {
        private static string ConnectionString;

        public UtenteAdoRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private static SqlConnection conn;
        public static DataSet userDs = new DataSet();
        private SqlDataAdapter userAdapter;

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
                    userAdapter = new SqlDataAdapter();
                    userAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    SqlCommand selectUser = new SqlCommand("SELECT * FROM Utenti", conn);

                    userAdapter.SelectCommand = selectUser;
                    userAdapter.InsertCommand = CommandInsertUser(conn);

                    userAdapter.SelectCommand = selectUser;
                    userAdapter.Fill(userDs, "Utenti");
                }
            }
            return true;
        }

        public static Utente SearchUser(string username)
        {
            Utente user = null;

            foreach(DataRow row in userDs.Tables["Utenti"].Rows)
            {
                if(row.Field<string>("Nickname") == username)
                {
                    user = new Utente()
                    {
                        Nickname = username,
                        Password = row.Field<string>("Password"),
                        Admin = row.Field<bool>("Admin")
                    };
                }
            }

            return user;
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
                    userAdapter.SelectCommand.Connection = conn;
                    userAdapter.InsertCommand.Connection = conn;

                    userAdapter.Update(userDs, "Utenti");
                    userAdapter.Fill(userDs, "Utenti");
                }
            }
            return;
        }

        #region operazioni di CRUD

        public void AggiungiNuovoUtente(Utente user)
        {
            DataRow nuovaRiga = userDs.Tables["Utenti"].NewRow();

            nuovaRiga["Id"] = user.Id;
            nuovaRiga["Nickname"] = user.Nickname;
            nuovaRiga["Password"] = user.Password;
            nuovaRiga["Admin"] = user.Admin;

            userDs.Tables["Utenti"].Rows.Add(nuovaRiga);
            AggiornaDatabase();
        }

        #endregion

        #region metodi di servizio per comandi

        SqlCommand CommandInsertUser(SqlConnection connessione)
        {
            string comando = "INSERT INTO Utenti " +
                "VALUES (@Nickname, @Password, @Admin)";

            SqlCommand insertCommand = new SqlCommand(comando, connessione);
            insertCommand.CommandType = CommandType.Text;

            insertCommand.Parameters.Add(new SqlParameter("@Nickname", SqlDbType.NVarChar, 20, "Nickname"));
            insertCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 20, "Password"));
            insertCommand.Parameters.Add(new SqlParameter("@Admin", SqlDbType.Bit, 1, "Admin"));

            return insertCommand;
        }

        #endregion

    }
}
