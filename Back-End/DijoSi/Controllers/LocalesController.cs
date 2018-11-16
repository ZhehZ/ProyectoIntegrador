﻿using DijoSi.Modelos;
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
        LocalNegocios negocio = new LocalNegocios();

        [HttpGet]
        public List<Local> ListarLocales()
        {
            return negocio.ListadoLocales();
        }

        [HttpPost]
        public string RegistrarLocales(Local local)
        {
            string mensaje = "";
            mensaje = negocio.RegistrarLocales(local);
            return mensaje;
        }


        [HttpPost]
        public string ActualizarLocal(Local local)
        {
            string mensaje = "";
            mensaje = negocio.ActualizarLocal(local);
            return mensaje;
        }

        [HttpPost]
        public string EliminarLocal(Local local)
        {
            string mensaje = "";
            mensaje = negocio.EliminarLocal(local.idLocal);
            return mensaje;
        }

        [HttpGet]
        public List<Distrito> ListadoDistritos()
        {
            return negocio.ListadoDistritos();
        }

    }
}
