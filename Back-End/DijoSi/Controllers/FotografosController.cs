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
    public class FotografosController : ApiController
    {
        FotografoNegocios fotografoNegocios = new FotografoNegocios();

        [HttpGet]
        public List<Fotografo> ListarFotografos()
        {
            return fotografoNegocios.ListarFotografos();
        }

        [HttpPost]
        public string RegistrarFotografos(Fotografo fotografo)
        {
            string mensaje = "";
            mensaje = fotografoNegocios.RegistrarFotografos(fotografo);
            return mensaje;
        }

        [HttpPost]
        public string ActualizarFotografos(Fotografo fotografo)
        {
            string mensaje = "";
            mensaje = fotografoNegocios.ActualizarFotografos(fotografo);
            return mensaje;
        }

        [HttpDelete]
        public string EliminarFotografos(Fotografo fotografo)
        {
            string mensaje = "";
            mensaje = fotografoNegocios.EliminarFotografos(fotografo.idFotografo);
            return mensaje;
        }

    }
}
