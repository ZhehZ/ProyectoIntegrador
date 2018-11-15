﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Modelos
{
    public class Regalo
    {
        public string idRegalo  { get; set; }
        public string desRegalo { get; set; }

        public void Validaciones()
        {
            if (string.IsNullOrEmpty(desRegalo))
                throw new Exception("Debe ingresar una Descripcion"); 
        }
    }
}