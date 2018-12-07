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
    public class ReservaController : ApiController
    {
        ReservaNegocios reservaNegocios = new ReservaNegocios();

        [HttpPost]
        public string RegistrarReserva(Reserva reserva)
        {
            string mensaje = "";
            mensaje = reservaNegocios.RegistrarReserva(reserva);
            return mensaje;
        }
    }
}
