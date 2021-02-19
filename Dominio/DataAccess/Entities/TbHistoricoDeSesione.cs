using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.DataAccess.Entities
{
    public partial class TbHistoricoDeSesione
    {
        public int InseId { get; set; }
        public bool InseAccion { get; set; }
        public int InseUsuarioCrea { get; set; }
        public DateTime InseFechaCrea { get; set; }

        public virtual TbUsuario InseUsuarioCreaNavigation { get; set; }
    }
}
