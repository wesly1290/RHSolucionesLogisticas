using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UsuariosEntity: EN
    {
        public UsuariosEntity()
        {
            Rol = Rol ?? new RolesEntity();
        }
        public int? UsuariosId { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public int? RolesId { get; set; }
        public virtual RolesEntity Rol{ get; set; }
    }
}
