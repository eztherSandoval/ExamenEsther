//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenEsther.ServicioWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ExamenEstherEntities : DbContext
    {
        public ExamenEstherEntities()
            : base("name=ExamenEstherEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Contactos> Contactos { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Mercados> Mercados { get; set; }
        public virtual DbSet<Telefonos> Telefonos { get; set; }
    
        public virtual int spClienteModificar(Nullable<long> pId, string pRazonSocial, string pPais, string pIdentificadorFiscal, string pCorreoElectronico, Nullable<long> pIdMercado)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(long));
    
            var pRazonSocialParameter = pRazonSocial != null ?
                new ObjectParameter("pRazonSocial", pRazonSocial) :
                new ObjectParameter("pRazonSocial", typeof(string));
    
            var pPaisParameter = pPais != null ?
                new ObjectParameter("pPais", pPais) :
                new ObjectParameter("pPais", typeof(string));
    
            var pIdentificadorFiscalParameter = pIdentificadorFiscal != null ?
                new ObjectParameter("pIdentificadorFiscal", pIdentificadorFiscal) :
                new ObjectParameter("pIdentificadorFiscal", typeof(string));
    
            var pCorreoElectronicoParameter = pCorreoElectronico != null ?
                new ObjectParameter("pCorreoElectronico", pCorreoElectronico) :
                new ObjectParameter("pCorreoElectronico", typeof(string));
    
            var pIdMercadoParameter = pIdMercado.HasValue ?
                new ObjectParameter("pIdMercado", pIdMercado) :
                new ObjectParameter("pIdMercado", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spClienteModificar", pIdParameter, pRazonSocialParameter, pPaisParameter, pIdentificadorFiscalParameter, pCorreoElectronicoParameter, pIdMercadoParameter);
        }
    
        public virtual int spClienteResgistrar(string pRazonSocial, string pPais, string pIdentificadorFiscal, string pCorreoElectronico, Nullable<long> pIdMercado)
        {
            var pRazonSocialParameter = pRazonSocial != null ?
                new ObjectParameter("pRazonSocial", pRazonSocial) :
                new ObjectParameter("pRazonSocial", typeof(string));
    
            var pPaisParameter = pPais != null ?
                new ObjectParameter("pPais", pPais) :
                new ObjectParameter("pPais", typeof(string));
    
            var pIdentificadorFiscalParameter = pIdentificadorFiscal != null ?
                new ObjectParameter("pIdentificadorFiscal", pIdentificadorFiscal) :
                new ObjectParameter("pIdentificadorFiscal", typeof(string));
    
            var pCorreoElectronicoParameter = pCorreoElectronico != null ?
                new ObjectParameter("pCorreoElectronico", pCorreoElectronico) :
                new ObjectParameter("pCorreoElectronico", typeof(string));
    
            var pIdMercadoParameter = pIdMercado.HasValue ?
                new ObjectParameter("pIdMercado", pIdMercado) :
                new ObjectParameter("pIdMercado", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spClienteResgistrar", pRazonSocialParameter, pPaisParameter, pIdentificadorFiscalParameter, pCorreoElectronicoParameter, pIdMercadoParameter);
        }
    
        public virtual ObjectResult<spClientesConsultar_Result> spClientesConsultar(string pRazonSocial, string pPais)
        {
            var pRazonSocialParameter = pRazonSocial != null ?
                new ObjectParameter("pRazonSocial", pRazonSocial) :
                new ObjectParameter("pRazonSocial", typeof(string));
    
            var pPaisParameter = pPais != null ?
                new ObjectParameter("pPais", pPais) :
                new ObjectParameter("pPais", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spClientesConsultar_Result>("spClientesConsultar", pRazonSocialParameter, pPaisParameter);
        }
    
        public virtual int spContactoModificar(Nullable<long> pId, string pNombre, string pPuesto, string pCorreo, Nullable<long> pIdCliente)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(long));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pPuestoParameter = pPuesto != null ?
                new ObjectParameter("pPuesto", pPuesto) :
                new ObjectParameter("pPuesto", typeof(string));
    
            var pCorreoParameter = pCorreo != null ?
                new ObjectParameter("pCorreo", pCorreo) :
                new ObjectParameter("pCorreo", typeof(string));
    
            var pIdClienteParameter = pIdCliente.HasValue ?
                new ObjectParameter("pIdCliente", pIdCliente) :
                new ObjectParameter("pIdCliente", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spContactoModificar", pIdParameter, pNombreParameter, pPuestoParameter, pCorreoParameter, pIdClienteParameter);
        }
    
        public virtual int spContactoRegistrar(string pNombre, string pPuesto, string pCorreo, Nullable<long> pIdCliente)
        {
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pPuestoParameter = pPuesto != null ?
                new ObjectParameter("pPuesto", pPuesto) :
                new ObjectParameter("pPuesto", typeof(string));
    
            var pCorreoParameter = pCorreo != null ?
                new ObjectParameter("pCorreo", pCorreo) :
                new ObjectParameter("pCorreo", typeof(string));
    
            var pIdClienteParameter = pIdCliente.HasValue ?
                new ObjectParameter("pIdCliente", pIdCliente) :
                new ObjectParameter("pIdCliente", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spContactoRegistrar", pNombreParameter, pPuestoParameter, pCorreoParameter, pIdClienteParameter);
        }
    }
}
