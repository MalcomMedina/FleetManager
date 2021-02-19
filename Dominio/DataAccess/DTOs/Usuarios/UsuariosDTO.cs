using Dominio.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataAccess.DTOs
{
    public class UsuariosDTO
    {
        public int UsuId { get; set; }
        public string UsuCorreo { get; set; }
        public string UsuNombreDeUsuario { get; set; }
        public string UsuContrasenia { get; set; }
        public string UsuFotografia { get; set; }
        public string UsuNoCelular { get; set; }
        public bool? UsuEsActivo { get; set; }
        public int UsuUsuarioCrea { get; set; }
        public DateTime UsuFechaCrea { get; set; }
        public int? UsuUsuarioModifica { get; set; }
        public DateTime? UsuFechaModifica { get; set; }

        //public List<TbHistoricoDeSesione> TbHistoricoDeSesiones { get; set; }
        //public List<TbPantalla> TbPantallaPlaUsuarioCreaNavigations { get; set; }
        //public List<TbPantalla> TbPantallaPlaUsuarioModificaNavigations { get; set; }
        //public List<TbPantallasRole> TbPantallasRolePlarolUsuarioCreaNavigations { get; set; }
        //public List<TbPantallasRole> TbPantallasRolePlarolUsuarioModificaNavigations { get; set; }
        //public List<TbRole> TbRoleRolUsuarioCreaNavigations { get; set; }
        //public List<TbRole> TbRoleRolUsuarioModificaNavigations { get; set; }
        //public List<TbTokensUsuario> TbTokensUsuarios { get; set; }
        //public List<TbUsuariosRole> TbUsuariosRoleUsurolUsuarioCreaNavigations { get; set; }
        //public List<TbUsuariosRole> TbUsuariosRoleUsurolUsuarioModificaNavigations { get; set; }
        //public List<TbUsuariosRole> TbUsuariosRoleUsus { get; set; }

    }
}
