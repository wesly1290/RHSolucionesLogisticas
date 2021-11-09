using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class FacturasEntity : EN
    {
        public FacturasEntity()
        {
            Cliente = Cliente ?? new ClientesEntity();
        }
        public int? IdFactura { get; set; }
        public string Pedido { get; set; }
        public string TipoServicio { get; set; }
        public DateTime FechaPedido { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }


        public int? ClientesId { get; set; }
        public virtual ClientesEntity Cliente { get; set; }



    }
}
