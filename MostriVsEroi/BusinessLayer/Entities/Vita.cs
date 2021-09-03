using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class Vita
    {
        public int PuntiVita { get { return CalcoloPuntiVita(Livello); } }
        public int Livello { get; set; }

        public static int CalcoloPuntiVita(int level)
        {
            int pv = 0;

            switch (level)
            {
                case 1:
                    pv = 20;
                    break;
                case 2:
                    pv = 40;
                    break;
                case 3:
                    pv = 60;
                    break;
                case 4:
                    pv = 80;
                    break;
                case 5:
                    pv = 100;
                    break;
                default:
                    pv = 0;
                    break;
            }
            return pv;
        }
    }
}
