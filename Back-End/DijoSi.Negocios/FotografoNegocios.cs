using DijoSi.Datos;
using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Negocios
{
    public class FotografoNegocios
    {
        FotografoDatos fotografoDatos = new FotografoDatos();

        public List<Fotografo> ListarFotografos()
        {
            return fotografoDatos.ListarFotografos();
        }

        public string RegistrarFotografos(Fotografo fotografo)
        {
            string mensaje = "";
            try
            {
                fotografoDatos.RegistrarFotografos(fotografo);
                mensaje = "Fotografo registrado";
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string ActualizarFotografos(Fotografo fotografo)
        {
            string mensaje = "";
            try
            {
                fotografoDatos.ActualizarFotografos(fotografo);
                mensaje = "Fotografo actualizado";
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string EliminarFotografos(string id)
        {
            string mensaje = "";
            try
            {
                fotografoDatos.EliminarFotografos(id);
                mensaje = "Fotografo Eliminado";
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }
    }
}