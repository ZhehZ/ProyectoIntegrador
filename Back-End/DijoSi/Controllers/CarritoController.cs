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
    public class CarritoController : ApiController
    {
        CarritoNegocios carritoNegocios = new CarritoNegocios();

        [HttpPost]
        public string ElegirRegalo(Carrito carrito)
        {
            string mensaje = "";
            mensaje = carritoNegocios.ElegirRegalo(carrito);
            return mensaje;
        }
    }
}
