using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.DataAccess.Entities
{
    public partial class TbPantallasRole
    {
        public int PlarolId { get; set; }
        public int RolId { get; set; }
        public int PlaId { get; set; }
        public bool? PlarolEsActivo { get; set; }
        public int PlarolUsuarioCrea { get; set; }
        public DateTime PlarolFechaCrea { get; set; }
        public int? PlarolUsuarioModifica { get; set; }
        public DateTime? PlarolFechaModifica { get; set; }

        public virtual TbPantalla Pla { get; set; }
        public virtual TbUsuario PlarolUsuarioCreaNavigation { get; set; }
        public virtual TbUsuario PlarolUsuarioModificaNavigation { get; set; }
        public virtual TbRole Rol { get; set; }
    }
}
