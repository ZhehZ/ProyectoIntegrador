using DijoSi.Modelos;
using DijoSi.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Negocios
{
    public class BuffetsNegocios
    {
        BuffetsDatos buffetsDatos = new BuffetsDatos();

        public List<Buffet> ListarBuffets()
        {
            return buffetsDatos.ListarBuffets();
        }

        public List<Categoria> ListarCategorias()
        {
            return buffetsDatos.ListarCategoria();
        }

        public string RegistrarBuffets(Buffet buffet)
        {
            string mensaje = "";
            try
            { 
                buffetsDatos.RegistrarBuffets(buffet);
                mensaje = "Buffet registrado";
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string EliminarBuffets(string idBuffet)
        {
            string mensaje = "";
            try
            { 
                buffetsDatos.EliminarBuffets(idBuffet);
                mensaje = "Buffet Eliminado";
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string ActualizarBuffets(Buffet buffet)
        {
            string mensaje = "";
            try
            {
                buffetsDatos.ActualizarBuffets(buffet);
                mensaje = "Buffet Actualizado";
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }
    }
}