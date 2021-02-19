using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.DataAccess.Entities
{
    public partial class TbPantalla
    {
        public TbPantalla()
        {
            TbPantallasRoles = new HashSet<TbPantallasRole>();
        }

        public int PlaId { get; set; }
        public string PlaDescripcion { get; set; }
        public string PlaRouteValue { get; set; }
        public bool PlaEsActivo { get; set; }
        public int PlaUsuarioCrea { get; set; }
        public DateTime PlaFechaCrea { get; set; }
        public int? PlaUsuarioModifica { get; set; }
        public DateTime? PlaFechaModifica { get; set; }

        public virtual TbUsuario PlaUsuarioCreaNavigation { get; set; }
        public virtual TbUsuario PlaUsuarioModificaNavigation { get; set; }
        public virtual ICollection<TbPantallasRole> TbPantallasRoles { get; set; }
    }
}
