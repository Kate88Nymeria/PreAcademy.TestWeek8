using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class Eroe : Personaggio
    {
        public int PuntiAccumulati { get; set; }
        public int IdGiocatore { get; set; }

        public Eroe()
        {

        }

        public Eroe(string nome, string categoria, Arma arma) : base(nome, categoria, arma)
        {

        }

    }
}
