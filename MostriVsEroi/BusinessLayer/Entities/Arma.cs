using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class Arma
    {
        public string Nome { get; set; }
        public int PuntiDanno { get; set; }
        public int Id { get; set; }
        public int IdCategoria { get; set; }

        public Arma()
        {

        }

        public Arma(string nome, int puntiDanno, int id)
        {
            Nome = nome;
            PuntiDanno = puntiDanno;
            Id = id;
        }
        public Arma(string nome, int puntiDanno)
        {
            Nome = nome;
            PuntiDanno = puntiDanno;
        }

        public override string ToString()
        {
            string stringa = $"Id Arma: {Id}\t\t\tNome: {Nome}\t\t\tPunti Danno: {PuntiDanno}";
            return stringa;
        }
    }
}
