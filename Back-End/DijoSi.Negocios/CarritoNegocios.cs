using DijoSi.Datos;
using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Negocios
{
    public class CarritoNegocios
    {
        CarritoDatos carritoDatos = new CarritoDatos();

        public string ElegirRegalo(Carrito carrito)
        {
            string mensaje = "";
            try
            {
                carritoDatos.ElegirRegalo(carrito);
                mensaje = "Regalo agregado";
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }
    }
}
