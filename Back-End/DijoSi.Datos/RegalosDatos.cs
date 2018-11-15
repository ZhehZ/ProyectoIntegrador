using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Datos
{
    public class RegalosDatos
    {
        string cadenaConexion = "Server=DESKTOP-RVKA4SI\\ALEX;Database=BD_DijoSI;uid=sa;pwd=sql";
        SqlConnection conexion;

        public RegalosDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public void RegistrarRegalos(Regalo regalo)
        {
            conexion.Open();
            string query = "usp_RegistrarRegalos";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desRegalo", regalo.desRegalo);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public List<Regalo> ListarRegalos()
        {
            List<Regalo> regalos = null;
            string query = "usp_ListarRegalos";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                regalos = new List<Regalo>();
                while (rd.Read())
                {
                    Regalo regalo = new Regalo();
                    regalo.idRegalo = rd["idRegalo"].ToString();
                    regalo.desRegalo = rd["desRegalo"].ToString();
                    regalos.Add(regalo);
                }
            }

            conexion.Close();

            return regalos;
        }
    }
}
