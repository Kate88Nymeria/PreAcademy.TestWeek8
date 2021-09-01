using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Utilities.Forms;
using static PresentationLayer.Utilities.Helpers;
using static DbLayer.EroeAdoRepository;
using DbLayer;

namespace Services
{
    public class UserServices
    {
        public static readonly UtenteAdoRepository UserAR = new UtenteAdoRepository();
    }
}
