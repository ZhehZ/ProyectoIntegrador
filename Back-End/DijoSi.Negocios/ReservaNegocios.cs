using DijoSi.Datos;
using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Negocios
{
    public class ReservaNegocios
    {
        ReservaDatos reservaDatos = new ReservaDatos();

        public string RegistrarReserva(Reserva reserva)
        {
            string mensaje = "";
            try
            {
                reserva.estado = false;
                reserva.idReserva = GenerarCodigo();
                if(reserva.idReserva == "")
                {
                    reserva.idReserva = "RE001";
                }
                reservaDatos.RegistrarReserva(reserva);
                mensaje = "Reserva Registrada";
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string GenerarCodigo()
        {
            string codigo = "";
            codigo = reservaDatos.generarCodigo();
            return codigo;
        }

        public string CancelarReserva(Reserva reserva)
        {
            string mensaje = "";
            try
            {
                reservaDatos.CancelarReserva(reserva);
                mensaje = "Se Cancelo la Reserva";
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }
    }
}
