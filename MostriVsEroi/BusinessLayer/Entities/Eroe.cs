using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public abstract class Eroe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Livello { get; set; }
        public int Punti { get; set; }
        public Arma TipoDiArma { get; set; }
        public Utente UtenteAutenticato { get; set; }
    }
}
