using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class Categoria
    {
        public string Nome { get; set; }
        public int Id { get; set; }

        public Categoria(string nome, int id)
        {
            Nome = nome;
            Id = id;
        }
    }
}
