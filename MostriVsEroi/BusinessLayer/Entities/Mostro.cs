using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class Mostro : Personaggio
    {
        public Mostro()
        {

        }

        public Mostro(string nome, string categoria, Arma arma, int level) : base(nome, categoria, arma)
        {

        }
    }
}
