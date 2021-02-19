using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.DataAccess.Entities
{
    public partial class TbRole
    {
        public TbRole()
        {
            TbPantallasRoles = new HashSet<TbPantallasRole>();
            TbUsuariosRoles = new HashSet<TbUsuariosRole>();
        }

        public int RolId { get; set; }
        public string RolDescripcion { get; set; }
        public bool RolEsActivo { get; set; }
        public int RolUsuarioCrea { get; set; }
        public DateTime RolFechaCrea { get; set; }
        public int? RolUsuarioModifica { get; set; }
        public DateTime? RolFechaModifica { get; set; }

        public virtual TbUsuario RolUsuarioCreaNavigation { get; set; }
        public virtual TbUsuario RolUsuarioModificaNavigation { get; set; }
        public virtual ICollection<TbPantallasRole> TbPantallasRoles { get; set; }
        public virtual ICollection<TbUsuariosRole> TbUsuariosRoles { get; set; }
    }
}
