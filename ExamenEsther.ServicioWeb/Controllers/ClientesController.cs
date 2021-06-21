using ExamenEsther.ServicioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamenEsther.ServicioWeb.Controllers
{
    public class ClientesController : ApiController
    {
        ExamenEstherEntities BD = new ExamenEstherEntities();

        [HttpGet]
        public List<Clientes> GetAll()
        {
            var listado = BD.Clientes.ToList();
            return listado;
        }

        [HttpPost]
        public string Post(string pRazonSocial, string pPais, string pIdentificacdorFiscal, string CorreoElectronico, int pMercado)
        {
            return Insertar(pRazonSocial, pPais, pIdentificacdorFiscal, CorreoElectronico, pMercado);
        }

        [HttpPut]
        public string Put(int pId, string pRazonSocial, string pPais, string pIdentificacdorFiscal, string CorreoElectronico, int pMercado)
        {
            return Modificar(pId, pRazonSocial, pPais, pIdentificacdorFiscal, CorreoElectronico, pMercado);
        }

        [HttpGet]
        public List<Clientes> Get(string pRazonSocial, string pPais)
        {
            return ConsultarPorRazonSocialPais(pRazonSocial, pPais);
        }

        public string Insertar(string pRazonSocial, string pPais, string pIdentificacdorFiscal, string CorreoElectronico, int pMercado)
        {
            try
            {
                if (!ExisteMercado(pMercado))
                {
                    return "El mercado proporcionado no existe en catalogo actual, favor de darlo de alta o revisar el dato proporcionado.";
                }

                if (ConsultarPorRazonSocialPais(pRazonSocial, string.Empty)[1].Id == 0)
                {
                    return "Ya se encuentra registrado un cliente con un nombre similar, favor de revisar la información proporcionada.";
                }
                int lResultado = BD.spClienteResgistrar(pRazonSocial, pPais, pIdentificacdorFiscal, CorreoElectronico, pMercado);

                if (lResultado > 0)
                    return "Se ha registrado el Cliente " + pRazonSocial;
                else
                    return "No se logró registrar el Cliente";
            }
            catch (Exception e)
            {
                return "Ocurrio un error al realizar el registro del Cliente. " + e.InnerException.Message;
            }
        }

        public bool ExisteMercado(int pMercado)
        {

            try
            {
                var consulta = BD.Mercados.Where(x => x.Id == pMercado && x.Activo == true).SingleOrDefault();

                if (consulta!= null)
                    return true;
                else
                    return false;
            }
            catch (Exception )
            {

                return false ;
            }
        }

        public string Modificar(int pId, string pRazonSocial, string pPais, string pIdentificacdorFiscal, string CorreoElectronico, int pMercado)
        {
            try
            {
                if (!ExisteMercado(pMercado))
                {
                    return "El Mercado proporcionado no existe, favor de darlo de alta o revisar el dato ingresado.";
                }

                int resultado = BD.spClienteModificar(pId, pRazonSocial, pPais, pIdentificacdorFiscal, CorreoElectronico, pMercado);

                if (resultado > 0)
                    return "Se han actualizado los datos del cliente: " + pRazonSocial;

                return "No se logró actualizar del Cliente : " + pRazonSocial;
            }
            catch (Exception e)
            {

                return "No se logró actualizar la información del cliente debido a un problema inesperado. " + e.InnerException.Message;
            }
        }
    
        public List<Clientes> ConsultarPorRazonSocialPais(string pRazonSocial, string pPais)
        {
            var resultado = new List<spClientesConsultar_Result>();
                List<Clientes> clientes = new List<Clientes>();

            try
            {
                resultado = BD.spClientesConsultar(pRazonSocial, pPais).ToList();

                if (resultado.Count >0)
                {
                    Clientes cliente;
                    foreach (var res in resultado)
                    {
                        cliente = new Clientes();
                        cliente.Id = res.Id;
                        cliente.RazonSocial = res.RazonSocial;
                        cliente.Pais = res.Pais;
                        cliente.IdentificadorFiscal = res.IdentificadorFiscal;
                        cliente.CorreoElectronico = res.CorreoElectronico;
                        cliente.Mercados.Nombre = res.Nombre;

                        clientes.Add(cliente);
                    }        
                }
                else
                {
                    Clientes cliente = new Clientes();
                    cliente.Id = 0;
                    cliente.RazonSocial = "Sin resultados";
                    clientes.Add(cliente);
                }
                return clientes;
            }
            catch (Exception e)
            {
                Clientes clienteErr = new Clientes();
                clienteErr.Id = 0;
                clienteErr.RazonSocial = "Error al consultar los clientes. " + e.Message;
                clientes.Add(clienteErr);
                return clientes;
            }
        }

    }
}
