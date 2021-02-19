using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataAccess.ViewModels.Login
{
    public class UserInfoViewModel
    {
        public int UsuId { get; set; }
        public string UsuCorreo { get; set; }
        public string UsuNombreDeUsuario { get; set; }
        public string UsuContrasenia { get; set; }
        public string UsuFotografia { get; set; }
        public string UsuNoCelular { get; set; }
        public List<RolInfoViewModel> Roles { get; set; }
        public UserTokenViewModel Token { get; set; }
    } 
}
