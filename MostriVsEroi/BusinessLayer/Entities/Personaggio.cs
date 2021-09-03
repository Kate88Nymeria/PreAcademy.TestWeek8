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

        public int PuntiVita { get {return Vita.CalcoloPuntiVita(Livello); } }
        public int Id { get; set; }

        public Personaggio(string nome, Arma arma, int livello, string categoria)
        {
            Nome = nome;
            TipoArma = arma;
            Livello = livello;
            Categoria = categoria;
        }

        public Personaggio(string nome, string categoria, Arma arma)
        {
            Nome = nome;
            TipoArma = arma;
            Livello = 1;
            Categoria = categoria;
        }

        public Personaggio()
        {

        }

        public override string ToString()
        {
            string stringa = $"{this.Id,-10}{this.Nome,-30}{this.Livello,-9}{this.IdCategoria,12}{this.IdArma,10}";

            //string stringa = $"{0,-10}{1,-30}{2,-9}{3,12}{4,10}",
            //    Id, Nome, Livello, IdCategoria, IdArma;
            return stringa;
        }
    }
}
