using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenEsther.Negocio
{
    public class Contacto
    {
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Puesto { get; set; }

        public string Correo { get; set; }

        public Cliente IdCliente { get; set; }
    }
}
