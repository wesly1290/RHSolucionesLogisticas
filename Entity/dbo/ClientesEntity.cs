﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity 
{
    public class ClientesEntity: EN
    {
        
        public int? ClientesId { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string Telefono  { get; set; }
        public int? AgenciaId { get; set; }
        

    }
}
