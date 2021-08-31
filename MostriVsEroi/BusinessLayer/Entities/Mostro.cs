using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public abstract class Mostro
    {
        public string Nome { get; set; }
        public int Livello { get; set; }
        public Arma TipoDiArma { get; set; }
    }
}
