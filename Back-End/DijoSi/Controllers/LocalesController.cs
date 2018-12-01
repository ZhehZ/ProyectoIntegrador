using DijoSi.Modelos;
using DijoSi.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DijoSi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LocalesController : ApiController
    {
        LocalNegocios localNegocios = new LocalNegocios();

        [HttpGet]
        public List<Local> ListarLocales()
        {
            return localNegocios.ListadoLocales();
        }

        [HttpPost]
        public string RegistrarLocales(Local local)
        {
            string mensaje = "";
            mensaje = localNegocios.RegistrarLocales(local);
            return mensaje;
        }


        [HttpPut]
        public string ActualizarLocal(Local local)
        {
            string mensaje = "";
            mensaje = localNegocios.ActualizarLocal(local);
            return mensaje;
        }

        [HttpDelete]
        public string EliminarLocal(string id)
        {
            string mensaje = "";
            mensaje = localNegocios.EliminarLocal(id);
            return mensaje;
        }

        [HttpGet]
        public List<Distrito> ListadoDistritos()
        {
            return localNegocios.ListadoDistritos();
        }

        [HttpGet]
        public Local ObtenerLocales(string id)
        {
            var lista = localNegocios.ListadoLocales();
            Local local = lista.FirstOrDefault(x => x.idLocal == id);
            return local;
        }

    }
}
