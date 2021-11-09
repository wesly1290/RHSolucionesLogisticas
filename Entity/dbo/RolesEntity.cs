using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RolesEntity : DBEntity
    {
        public int? RolesId { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
    }
}
