﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Modelo
{
    public class Usuario
    {

       public string idUsuario          { get; set; }
       public string dniUsuario         { get; set; }
       public string nomUsuario         { get; set; }
       public string apePatUsuario      { get; set; }
       public string apeMatUsuario      { get; set; }
       public string telfUsuario        { get; set; }
       public string dirUsuario         { get; set; }
       public string emailUsuario       { get; set; }
       public string loginUsuario       { get; set; }
       public string passUsuario        { get; set; }
       public string ConfirmaContraseña { get; set; }
       public bool   verificaEmail      { get; set; }
       public System.Guid Codigo        { get; set; }
       public string Reiniciarcontra    { get; set; }

        public void ValidacionesRegistrar()
        {
            if (string.IsNullOrEmpty(nomUsuario))
                throw new Exception("Debe ingresar un Nombre");
            else if (string.IsNullOrEmpty(apePatUsuario) && string.IsNullOrEmpty(apeMatUsuario))
                throw new Exception("Debe ingresar su Apellido");
            else if (string.IsNullOrEmpty(dirUsuario))
                throw new Exception("Debe ingresar una Direccion");
            else if (string.IsNullOrEmpty(emailUsuario))
                throw new Exception("Debe ingresar su Correo");
            else if (string.IsNullOrEmpty(loginUsuario))
                throw new Exception("Debe ingresar su Correo");
            else if (!ConfirmaContraseña.Equals(passUsuario))
                throw new Exception("Confirme su contraseña");
        }


    }
    
}    