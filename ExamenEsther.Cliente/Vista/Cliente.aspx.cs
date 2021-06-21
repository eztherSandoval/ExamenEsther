using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ExamenEsther.Cliente.Vista
{
    public partial class Cliente : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultarTodos();
        }


        public void ConsultarTodos()
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["ConexionClientes"].ToString());

                var request = cliente.GetAsync("api/Clientes/").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var lista = JsonConvert.DeserializeObject<List<Negocio.Cliente>>(resultString);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
    }
}