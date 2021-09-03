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

        public Utente()
        {
            
        }

        public Utente(int id, string username, string password, bool isAdmin)
        {
            Id = id;
            Nickname = username;
            Password = password;
            Admin = isAdmin;
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
        }

        public override string ToString()
        {
            string stampa = $"Id: {Id}\tNickname: {Nickname}\tPassword: {Password}\tAdmin: {Admin}";
            return stampa;
        }

    }
}
