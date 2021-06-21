using ExamenEsther.ServicioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamenEsther.ServicioWeb.Controllers
{
    public class ContactosController : ApiController
    {

        ExamenEstherEntities BD = new ExamenEstherEntities();

        [HttpGet]
        public List<Contactos> GetAll()
        {
            var listado = BD.Contactos.ToList();
            return listado;
        }

        [HttpPost]
        public string Post(string pNombre, string pPuesto, string pCorreo, int pIdCliente)
        {
            return Insertar(pNombre, pPuesto, pCorreo, pIdCliente);
        }

        [HttpPut]
        public string Put(int pId, string pNombre, string pPuesto, string pCorreo, int pIdCliente)
        {
            return Modificar(pId, pNombre, pPuesto, pCorreo, pIdCliente);
        }

        public string Insertar(string pNombre, string pPuesto, string pCorreo, int pIdCliente)
        {
            try
            {
                if (!ExisteCliente(pIdCliente))
                {
                    return "El cliente proporcionado no existe en catalogo actual, favor de darlo de alta o revisar el dato proporcionado.";
                }

                int lResultado = BD.spContactoRegistrar(pNombre, pPuesto, pCorreo, pIdCliente);

                if (lResultado > 0)
                    return "Se ha registrado el Contacto " + pNombre;
                else
                    return "No se logró registrar el Contacto";
            }
            catch (Exception e)
            {
                return "Ocurrio un error al realizar el registro del Contacto. " + e.InnerException.Message;
            }
        }

        public string Modificar(int pId, string pNombre, string pPuesto, string pCorreo, int pIdCliente)
        {
            try
            {
                if (!ExisteCliente(pIdCliente))
                {
                    return "El Cliente proporcionado no existe, favor de darlo de alta o revisar el dato ingresado.";
                }

                int resultado = BD.spContactoModificar(pId, pNombre, pPuesto, pCorreo, pIdCliente);

                if (resultado > 0)
                    return "Se han actualizado los datos del Contacto: " + pNombre;

                return "No se logró actualizar del Contacto : " + pNombre;
            }
            catch (Exception e)
            {

                return "No se logró actualizar la información del Contacto debido a un problema inesperado. " + e.InnerException.Message;
            }
        }

        public bool ExisteCliente(int pIdCliente)
        {

            try
            {
                var consulta = BD.Clientes.Where(x => x.Id == pIdCliente).SingleOrDefault();

                if (consulta != null)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
