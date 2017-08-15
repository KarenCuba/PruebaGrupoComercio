using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AppWebBancos.Models
{
    public class OrdenPago
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string estado { get; set; }
        public DateTime FechaPago { get; set; }

        string strConnection = ConfigurationManager.ConnectionStrings["MVC"].ConnectionString.ToString();

        public Boolean InsertarOrdenPago(OrdenPago OrdenPago)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_INSERTAR_ORDENPAGO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.CommandText = "USP_INSERTAR_BANCO";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Monto", OrdenPago.Monto);
                    command.Parameters.AddWithValue("@Moneda", OrdenPago.Moneda);
                    command.Parameters.AddWithValue("@estado", OrdenPago.estado);
                    command.Parameters.AddWithValue("@FechaPago", OrdenPago.FechaPago);
                    command.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<OrdenPago> ListarOrdenPago()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_LISTAR_ORDENPAGO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    List<OrdenPago> lstOrdenPago = new List<OrdenPago>();
                    IDataReader lector = command.ExecuteReader();
                    while (lector.Read())
                    {
                        OrdenPago beOrdenPago = new OrdenPago()
                        {
                            Id = lector.GetInt32(0),
                            Monto = lector.GetDecimal(1),
                            Moneda = lector.GetString(2),
                            estado = lector.GetString(3),
                            FechaPago = lector.GetDateTime(4),
                        };
                        lstOrdenPago.Add(beOrdenPago);
                    }

                    conn.Close();
                    return lstOrdenPago;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean ActualizarOrdenPago(OrdenPago OrdenPago)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_ACTUALIZAR_ORDENPAGO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.CommandText = "USP_INSERTAR_BANCO";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", OrdenPago.Id);
                    command.Parameters.AddWithValue("@Monto", OrdenPago.Monto);
                    command.Parameters.AddWithValue("@Moneda", OrdenPago.Moneda);
                    command.Parameters.AddWithValue("@estado", OrdenPago.estado);
                    command.Parameters.AddWithValue("@FechaPago", OrdenPago.FechaPago);
                    command.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean EliminarOrdenPago(OrdenPago OrdenPago)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_ELIMINAR_ORDENPAGO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.CommandText = "USP_INSERTAR_BANCO";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", OrdenPago.Id);
                    command.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public OrdenPago ObtenerPorId(int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_OBTENER_ORDENPAGO_ID", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", Id);
    
                    IDataReader lector = command.ExecuteReader();
                    OrdenPago beOrdenPago = null;
                    while (lector.Read())
                    {
                        beOrdenPago = new OrdenPago()
                        {
                            Id = lector.GetInt32(0),
                            Monto = lector.GetDecimal(1),
                            Moneda = lector.GetString(2),
                            estado = lector.GetString(3),
                            FechaPago = lector.GetDateTime(4),
                        };
                       
                    }

                    conn.Close();
                    return beOrdenPago;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}