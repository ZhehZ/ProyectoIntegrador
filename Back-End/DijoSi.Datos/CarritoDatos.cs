using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Datos
{
    public class CarritoDatos : Conexion
    {
        SqlConnection conexion;

        public CarritoDatos()
        {
            conexion = new SqlConnection(conexionString);
        }

        public void ElegirRegalo(Carrito carrito)
        {
            string query = "usp_ElegirRegalo";
            conexion.Open();
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomprovBuffet", carrito.idUsuario);
            cmd.Parameters.AddWithValue("@nomprovBuffet", carrito.idRegalo);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
