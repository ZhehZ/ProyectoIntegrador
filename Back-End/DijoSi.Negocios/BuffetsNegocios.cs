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
                mensaje = "Buffet registrado";
                buffetsDatos.RegistrarBuffets(buffet);
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
                mensaje = "Buffet Eliminado";
                buffetsDatos.EliminarBuffets(idBuffet);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }
    }
}
