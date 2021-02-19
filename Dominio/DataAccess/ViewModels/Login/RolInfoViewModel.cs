using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataAccess.ViewModels.Login
{
    public class RolInfoViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<PantallaInfoViewModel> Pantallas { get; set; }
    }
}
