using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Datos
{
    public class RegalosDatos : Conexion
    {
        SqlConnection conexion;

        public RegalosDatos()
        {
            conexion = new SqlConnection(conexionString);
        }

        public void RegistrarRegalos(Regalo regalo)
        {
            conexion.Open();
            string query = "usp_RegistrarRegalos";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desRegalo", regalo.desRegalo);
            cmd.Parameters.AddWithValue("@idtipo", regalo.idTipo);
            cmd.Parameters.AddWithValue("@foto", regalo.foto);
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
                    regalo.desRegalo = rd["nombreRegalo"].ToString();
                    regalo.idTipo = rd["idTipo"].ToString();
                    regalo.desTipo = rd["desTipo"].ToString();
                    regalo.foto = rd["foto"].ToString();
                    regalos.Add(regalo);
                }
            }

            conexion.Close();

            return regalos;
        }

        public List<TipoRegalo> ListarTipoRegalo()
        {
            List<TipoRegalo> tipos = null;
            string query = "usp_ListarTipoRegalos";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                tipos = new List<TipoRegalo>();
                while (rd.Read())
                {
                    TipoRegalo tipoRegalo = new TipoRegalo();
                    tipoRegalo.idTipo = rd["idTipo"].ToString();
                    tipoRegalo.desTipo = rd["desTipo"].ToString();
                    tipos.Add(tipoRegalo);
                }
            }

            conexion.Close();

            return tipos;
        }
    }
}
