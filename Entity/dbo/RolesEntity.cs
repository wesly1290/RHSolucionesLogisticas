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
        public bool Estado { get; set; }
    }

    public class PaginasEntity : DBEntity
    {
        public int? PaginasId { get; set; }
        public string NombrePagina { get; set; }
        public string DescPagina { get; set; }
    }

    public class PaginasAsignarEntity : DBEntity
    {
        public int? RolesId { get; set; }
        public int? PaginasId { get; set; }
        public bool Check { get; set; }
    }

    public class PaginasRolEntity
    {
        public bool Customer { get; set; } = false;
        public bool Users { get; set; } = false;
        public bool Invoice { get; set; } = false;
        public bool RoleMaintenance { get; set; } = false;
        public bool Reports { get; set; } = false;
        public bool UserLog { get; set; } = false;
        public bool MovementLog { get; set; } = false;
    }
}
