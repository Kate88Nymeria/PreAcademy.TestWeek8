using System;
namespace BusinessLayer.Entities
{
    public class Utente
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

        public Utente()
        {
            
        }

        public Utente(string username, string password)
        {
            Nickname = username;
            Password = password;
            Admin = false;
        }

        public override string ToString() //mi serve per verificare che Admin sia corretto, al momento non lo è, non riconosce il bool-bit
        {
            string stampa = $"Id: {Id}\tNickname: {Nickname}\tPassword: {Password}\tAdmin: {Admin}";
            return stampa;
        }

    }
}
