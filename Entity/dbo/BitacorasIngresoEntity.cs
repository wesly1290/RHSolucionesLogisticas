using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BitacorasIngresoEntity
    {
        public int? BitacoraId { get; set; }
        public int? UsuariosId { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public string IngresoSalida { get; set; }
        public string Usuario { get; set; }
    }

    public class BitacorasMovimientoEntity
    {
        public int? UsuarioMovimientoId { get; set; }
        public int? UsuariosId { get; set; }
        public DateTime FechaMovimiento { get; set; } = DateTime.Now;
        public string DescripcionMovimiento { get; set; }
        public string Usuario { get; set; }
    }
}
