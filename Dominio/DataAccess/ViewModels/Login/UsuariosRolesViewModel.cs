using Dominio.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataAccess.ViewModels.Login
{
    public class UsuariosRolesViewModel
    {
        public int UsuId { get; set; }
        public List<RolesDTO> Roles { get; set; }
    }
}
