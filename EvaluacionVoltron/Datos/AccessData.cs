using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EvaluacionVoltron.Datos
{
    internal class AccessData
    {
        string conn = ConfigurationSettings.AppSettings["conexion"];
        public string insertapedido(double largo, double alto, string color)
        {
            var resp = "";


            using (SqlConnection connx = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("InsertarEnTabla", connx))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetros del procedimiento almacenado
                        command.Parameters.Add("@p_largo", SqlDbType.VarChar, 255).Value = largo.ToString();
                        command.Parameters.Add("@p_alto", SqlDbType.VarChar, 255).Value = alto.ToString();
                        command.Parameters.Add("@p_color", SqlDbType.VarChar, 255).Value = color;
                        //command.Parameters.Add("@p_confirmacion_pedido", SqlDbType.Bit).Value = confirmacion;
                        command.Parameters.Add("@p_fecha_confirmacion", SqlDbType.DateTime).Value = DateTime.Now;

                        connx.Open();
                        command.ExecuteNonQuery();
                        resp = "1";
                    }
                    catch (Exception ex)
                    {
                        resp = "Ocurrio un error al insertar en la BD: " + ex.Message;
                    }
                }
            }

            return resp;
        }



        public List<string> ConsultarDatos()
        {
            List<string> datos = new List<string>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("ConsultarDatos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemText = $"{reader["largo"]} - {reader["alto"]} - {reader["color"]} - {reader["fecha_confirmacion"]}";
                            datos.Add(itemText);
                        }
                    }
                }
            }

            return datos;
        }
    }

}
