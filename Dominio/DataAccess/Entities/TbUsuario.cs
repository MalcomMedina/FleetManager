using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.DataAccess.Entities
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbHistoricoDeSesiones = new HashSet<TbHistoricoDeSesione>();
            TbPantallaPlaUsuarioCreaNavigations = new HashSet<TbPantalla>();
            TbPantallaPlaUsuarioModificaNavigations = new HashSet<TbPantalla>();
            TbPantallasRolePlarolUsuarioCreaNavigations = new HashSet<TbPantallasRole>();
            TbPantallasRolePlarolUsuarioModificaNavigations = new HashSet<TbPantallasRole>();
            TbRoleRolUsuarioCreaNavigations = new HashSet<TbRole>();
            TbRoleRolUsuarioModificaNavigations = new HashSet<TbRole>();
            TbTokensUsuarios = new HashSet<TbTokensUsuario>();
            TbUsuariosRoleUsurolUsuarioCreaNavigations = new HashSet<TbUsuariosRole>();
            TbUsuariosRoleUsurolUsuarioModificaNavigations = new HashSet<TbUsuariosRole>();
            TbUsuariosRoleUsus = new HashSet<TbUsuariosRole>();
        }

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

        public virtual ICollection<TbHistoricoDeSesione> TbHistoricoDeSesiones { get; set; }
        public virtual ICollection<TbPantalla> TbPantallaPlaUsuarioCreaNavigations { get; set; }
        public virtual ICollection<TbPantalla> TbPantallaPlaUsuarioModificaNavigations { get; set; }
        public virtual ICollection<TbPantallasRole> TbPantallasRolePlarolUsuarioCreaNavigations { get; set; }
        public virtual ICollection<TbPantallasRole> TbPantallasRolePlarolUsuarioModificaNavigations { get; set; }
        public virtual ICollection<TbRole> TbRoleRolUsuarioCreaNavigations { get; set; }
        public virtual ICollection<TbRole> TbRoleRolUsuarioModificaNavigations { get; set; }
        public virtual ICollection<TbTokensUsuario> TbTokensUsuarios { get; set; }
        public virtual ICollection<TbUsuariosRole> TbUsuariosRoleUsurolUsuarioCreaNavigations { get; set; }
        public virtual ICollection<TbUsuariosRole> TbUsuariosRoleUsurolUsuarioModificaNavigations { get; set; }
        public virtual ICollection<TbUsuariosRole> TbUsuariosRoleUsus { get; set; }
    }
}
