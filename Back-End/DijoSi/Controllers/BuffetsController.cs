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
    public class BuffetsController : ApiController
    {
        BuffetsNegocios buffetsNegocios = new BuffetsNegocios();

        [HttpGet]
        public List<Buffet> ListarBuffets()
        {
            return buffetsNegocios.ListarBuffets();
        }

        [HttpGet]
        public List<Categoria> ListarCategorias()
        {
            return buffetsNegocios.ListarCategorias();
        }

        [HttpPost]
        public string RegistrarBuffets(Buffet buffet)
        {
            string mensaje = "";
            mensaje = buffetsNegocios.RegistrarBuffets(buffet);
            return mensaje;
        }

        [HttpPost]
        public string EliminarBuffets(Buffet buffet)
        {
            string mensaje = "";
            mensaje = buffetsNegocios.EliminarBuffets(buffet.idBuffet);
            return mensaje;
        }
    }
}
