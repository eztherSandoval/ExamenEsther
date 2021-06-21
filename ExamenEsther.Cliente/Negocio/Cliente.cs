using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenEsther.Negocio
{
    public class Cliente
    {
        public long Id { get; set; }

        public string RazonSocial { get; set; }

        public string Pais { get; set; }

        public string IdentificadorSocial { get; set; }

        public string CorreoElectronico { get; set; }

        public Mercado Mercado { get; set; }
    }
}
