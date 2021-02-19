using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.DataAccess.Entities
{
    public partial class TbUsuariosRole
    {
        public int UsurolId { get; set; }
        public int UsuId { get; set; }
        public int RolId { get; set; }
        public int UsurolUsuarioCrea { get; set; }
        public bool? UsurolEsActivo { get; set; }
        public DateTime UsurolFechaCrea { get; set; }
        public int? UsurolUsuarioModifica { get; set; }
        public DateTime? UsurolFechaModifica { get; set; }

        public virtual TbRole Rol { get; set; }
        public virtual TbUsuario Usu { get; set; }
        public virtual TbUsuario UsurolUsuarioCreaNavigation { get; set; }
        public virtual TbUsuario UsurolUsuarioModificaNavigation { get; set; }
    }
}
