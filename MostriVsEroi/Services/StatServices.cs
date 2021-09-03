using DbLayer;
using System;
using System.Collections.Generic;
using System.Text;
using static BusinessLayer.Utilities.Helpers;

namespace Services
{
    public class StatServices
    {
        public static readonly StatAdoRepository StatAR = new StatAdoRepository();

        public static void StampaClassifica()
        {
            if (StatAR.Init())
            {
                StatAR.StampaRecordsPerClassifica();
                ContinuaEsecuzione();
            }
        }
    }
}
