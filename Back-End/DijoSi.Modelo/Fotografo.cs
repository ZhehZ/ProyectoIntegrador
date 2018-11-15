using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Modelos
{
    public class Fotografo
    {
        public string idFotografo     { get; set; }
        public string nomFotografo    { get; set; }
        public string telfFotografo   { get; set; }
        public string dirFotografo    { get; set; }

        public void ValidacionesRegistrar()
        {
            if (string.IsNullOrEmpty(nomFotografo))
                throw new Exception("Debe ingresar un Nombre");
            else if (string.IsNullOrEmpty(telfFotografo))
                throw new Exception("Debe ingresar un numero de Telefono o Celular");
            else if (string.IsNullOrEmpty(dirFotografo))
                throw new Exception("Debe ingresar una Direccion");
        }
        public void ValidacionesActualizar()
        {
            if (string.IsNullOrEmpty(telfFotografo))
                throw new Exception("Debe ingresar un numero de Telefono o Celular");
            else if (string.IsNullOrEmpty(dirFotografo))
                throw new Exception("Debe ingresar una Direccion");
        }
    }
}
