using BusinessLayer.Entities;
using System;
using System.Collections.Generic;

namespace MockLayer
{
    public class EroeMockData
    {
        public List<Eroe> FetchEroi(Utente utente)
        {
            List<Eroe> eroi = new List<Eroe>();
            eroi.Add(new Eroe("PrimoEroe", "Guerriero", new Arma("Ascia", 8)));
            eroi.Add(new Eroe("SecondoEroe","Mago", new Arma("Bastone Magico", 10)));
            return eroi;

        }
    }
}
