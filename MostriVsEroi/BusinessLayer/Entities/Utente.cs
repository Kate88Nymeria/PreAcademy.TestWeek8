using System;
using System.Collections.Generic;

namespace BusinessLayer.Entities
{
    public class Utente
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public bool Authenticated { get; set; }

        public List<Eroe> Eroi { get; set; }

        public Utente()
        {
            
        }

        public Utente(int id, string username, string password, bool isAdmin, bool isAuthenticated)
        {
            Id = id;
            Nickname = username;
            Password = password;
            Admin = isAdmin;
            Authenticated = isAuthenticated;
        }

        public Utente(string username, string password, bool isAdmin)
        {
            Nickname = username;
            Password = password;
            Admin = isAdmin;
        }

        public Utente(string username, string password)
        {
            Nickname = username;
            Password = password;
            Admin = false;
            Authenticated = false;
        }

        public override string ToString() //mi serve per verificare che Admin sia corretto, al momento non lo è, non riconosce il bool-bit
        {
            string stampa = $"Id: {Id}\tNickname: {Nickname}\tPassword: {Password}\tAdmin: {Admin}\tAuthenticated: {Authenticated}";
            return stampa;
        }

    }
}
