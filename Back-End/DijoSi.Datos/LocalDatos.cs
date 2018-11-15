using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DijoSi.Modelos;

namespace DijoSi.Datos
{
    public class LocalDatos
    {
        string cadenaConexion = "Server=DESKTOP-RVKA4SI\\ALEX;Database=BD_DijoSI;uid=sa;pwd=sql";
        SqlConnection con;

        public LocalDatos()
        {
            con = new SqlConnection(cadenaConexion);
        }

        public void ActualizarLocal(Local local)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("usp_ActualizarLocales", con);
            cmd.Parameters.AddWithValue("@id", local.idLocal);
            cmd.Parameters.AddWithValue("@nom", local.nomLocal);
            cmd.Parameters.AddWithValue("@dir", local.dirLocal);
            cmd.Parameters.AddWithValue("@fONo", local.telfLocal);
            cmd.Parameters.AddWithValue("@iddis", local.idDistrito);

            cmd.ExecuteNonQuery();

            con.Close();

        }

        public void RegistrarLocales(Local local)
        {
                con.Open();

                SqlCommand cmd = new SqlCommand("usp_RegistrarLocales", con);
                cmd.Parameters.AddWithValue("@nom", local.nomLocal);
                cmd.Parameters.AddWithValue("@dir", local.dirLocal);
                cmd.Parameters.AddWithValue("@fONo", local.telfLocal);
                cmd.Parameters.AddWithValue("@cant", local.cantLocal);
                cmd.Parameters.AddWithValue("@iddis", local.idDistrito);
                
                cmd.ExecuteNonQuery();
           
                con.Close(); 
            
        }

        public void EliminarLocal(string idLocal)
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("usp_EliminarLocales", con);
            cmd.Parameters.AddWithValue("@id", idLocal);
            

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public List<Local> ListarLocales()
        {
            List<Local> locales = new List<Local>();
            string query = "usp_ListarLocales";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Local local = new Local();
                    local.idLocal = dr["idLocal"].ToString();
                    local.nomLocal = dr["nomLocal"].ToString();
                    local.dirLocal = dr["dirLocal"].ToString();
                    local.telfLocal = dr["telfLocal"].ToString();
                    local.cantLocal = (Int32)dr["cantLocal"];
                    local.idDistrito = dr["idDistrito"].ToString();
                    local.nomDistrito = dr["nomDistrito"].ToString();
                    locales.Add(local);
                }
            }
            
            dr.Close();
            con.Close();
            return locales;

        }
        public List<Distrito> ListarDistritos()
        {
            List<Distrito> distritos = new List<Distrito>();
            SqlCommand cmd = new SqlCommand("usp_ListarDistritos", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Distrito distrito = new Distrito();
                distrito.idDistrito = dr["idDistrito"].ToString();
                distrito.nomDistrito = dr["nomDistrito"].ToString();
                distritos.Add(distrito);
            }
            dr.Close();
            con.Close();
            return distritos;

        }

    }
}
