using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DijoSi.Datos
{
    public class ReservaDatos : Conexion
    {
        SqlConnection conexion;

        public ReservaDatos()
        {
            conexion = new SqlConnection(conexionString);
        }

        public void RegistrarReserva(Reserva reserva)
        {
            conexion.Open();
            int resultado;
            string query = "usp_RegistrarReserva";
            string query1 = "usp_DetalleReserva";
            string query2 = "usp_RegistrarReservaLocal";

            SqlTransaction tran = conexion.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(query, conexion,tran);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id"      , reserva.idReserva);
                cmd.Parameters.AddWithValue("@idLocal" , reserva.idLocal);
                cmd.Parameters.AddWithValue("@idBuffet", reserva.idBuffet);
                cmd.Parameters.AddWithValue("@selecciona", reserva.Selecciona);
                cmd.Parameters.AddWithValue("@estado", reserva.estado);
                cmd.Parameters.AddWithValue("@fecha", reserva.fechaReserva);
                resultado = cmd.ExecuteNonQuery();

                if (resultado >= 1)
                {
                    SqlCommand cmd2 = new SqlCommand(query1, conexion,tran);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@id", reserva.idReserva);
                    cmd2.Parameters.AddWithValue("@idUsu", reserva.idUsuario);
                    resultado = cmd2.ExecuteNonQuery();

                    if(resultado >= 1)
                    {
                        SqlCommand cmd3 = new SqlCommand(query2, conexion,tran);
                        cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd3.Parameters.AddWithValue("@idLocal", reserva.idLocal);
                        cmd3.Parameters.AddWithValue("@fechaReserva", reserva.fechaReserva);
                        cmd3.ExecuteNonQuery();
                    }     
                }
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
            }
            finally
            {
                conexion.Close(); 
            }
        }

        public string generarCodigo()
        {
            conexion.Open();
            string codigo = "";
            string query = "usp_GenerarCodigo";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                codigo = rd["CODIGO"].ToString();
            }
            conexion.Close();

            return codigo;

        }    

        public void CancelarReserva(Reserva reserva)
        {
            conexion.Open();
            int resultado;
            string query = "usp_EliminarDetalle";
            string query1 = "usp_CancelarReserva";
            string query2 = "usp_EliminarHorarios";
            string query3 = "usp_EliminarAgenda";

            SqlTransaction tran = conexion.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(query, conexion, tran);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", reserva.idReserva);
                resultado = cmd.ExecuteNonQuery();

                if( reserva.idFotografo != null)
                {
                    SqlCommand cmd4 = new SqlCommand(query3, conexion, tran);
                    cmd4.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@idFotografo", reserva.idReserva);
                    cmd4.Parameters.AddWithValue("@fecha", reserva.fechaReserva);
                    cmd4.ExecuteNonQuery();
                }

                if (resultado >= 1)
                {
                    SqlCommand cmd2 = new SqlCommand(query1, conexion, tran);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@id", reserva.idReserva);
                    resultado = cmd2.ExecuteNonQuery();

                    if (resultado >= 1)
                    {
                        SqlCommand cmd3 = new SqlCommand(query2, conexion, tran);
                        cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd3.Parameters.AddWithValue("@idLocal", reserva.idLocal);
                        cmd3.Parameters.AddWithValue("@fecha", reserva.fechaReserva);
                        cmd3.ExecuteNonQuery();
                    }
                }
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
