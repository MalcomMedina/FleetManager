using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataAccess.DTOs
{
    public class RolesDTO
    {
        public int RolId { get; set; }
        public string RolDescripcion { get; set; }
        public bool RolEsActivo { get; set; }
        public int RolUsuarioCrea { get; set; }
        public DateTime RolFechaCrea { get; set; }
        public int? RolUsuarioModifica { get; set; }
        public DateTime? RolFechaModifica { get; set; }
    }
}
