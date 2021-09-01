using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public abstract class Personaggio
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int IdCategoria { get; set; } //da trasformare in categoria

        public Arma TipoArma { get; set; }

        public int IdArma { get; set; } //da trasformare in arma

        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        public int Id { get; set; }

        public Personaggio(string nome, Arma arma, int livello, int puntiVita, string categoria)
        {
            Nome = nome;
            TipoArma = arma;
            Livello = livello;
            PuntiVita = puntiVita;
            Categoria = categoria;
        }

        public Personaggio(string nome, string categoria, Arma arma)
        {
            Nome = nome;
            TipoArma = arma;
            Livello = 1;
            PuntiVita = 20;
            Categoria = categoria;
        }

        public Personaggio()
        {

        }
    }
}
