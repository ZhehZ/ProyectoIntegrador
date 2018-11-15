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
    }
}
