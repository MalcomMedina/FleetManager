using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.DataAccess.Entities
{
    public partial class TbTokensUsuario
    {
        public int TknsId { get; set; }
        public string TknsDescripcion { get; set; }
        public int TknsPertenceUsuario { get; set; }
        public DateTime TknsFechaExpiracion { get; set; }

        public virtual TbUsuario TknsPertenceUsuarioNavigation { get; set; }
    }
}
