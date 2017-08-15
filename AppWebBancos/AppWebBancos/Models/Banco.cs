using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace AppWebBancos.Models
{
    public class Banco
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }

        string strConnection = ConfigurationManager.ConnectionStrings["MVC"].ConnectionString.ToString();

        public Boolean InsertarBanco(Banco banco)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_INSERTAR_BANCO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.CommandText = "USP_INSERTAR_BANCO";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Nombre", banco.Nombre);
                    command.Parameters.AddWithValue("@Direccion", banco.Direccion);
                    command.Parameters.AddWithValue("@FechaRegistro", banco.FechaRegistro);
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

        public List<Banco> ListarBancos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_LISTAR_BANCO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    List<Banco> lstBanco = new List<Banco>();
                    IDataReader lector = command.ExecuteReader();
                    while (lector.Read())
                    {
                        Banco beBanco = new Banco()
                        {
                            Id = lector.GetInt32(0),
                            Nombre = lector.GetString(1),
                            Direccion = lector.GetString(2),
                            FechaRegistro = lector.GetDateTime(3),
                        };
                        lstBanco.Add(beBanco);
                    }
                    
                    conn.Close();
                    return lstBanco;
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean ActualizarBanco(Banco banco)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_ACTUALIZAR_BANCO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.CommandText = "USP_INSERTAR_BANCO";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", banco.Id);
                    command.Parameters.AddWithValue("@Nombre", banco.Nombre);
                    command.Parameters.AddWithValue("@Direccion", banco.Direccion);
                    command.Parameters.AddWithValue("@FechaRegistro", banco.FechaRegistro);
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

        public Boolean EliminarBanco(Banco banco)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_ELIMINAR_BANCO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.CommandText = "USP_INSERTAR_BANCO";
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", banco.Id);
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

        public Banco ObtenerPorId(int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_OBTENER_BANCO_ID", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", Id);
                    //List<Banco> lstBanco = new List<Banco>();
                    IDataReader lector = command.ExecuteReader();
                    Banco beBanco = null;
                    while (lector.Read())
                    {
                         beBanco = new Banco()
                        {
                            Id = lector.GetInt32(0),
                            Nombre = lector.GetString(1),
                            Direccion = lector.GetString(2),
                            FechaRegistro = lector.GetDateTime(3),
                        };
                       // lstBanco.Add(beBanco);
                    }

                    conn.Close();
                    return beBanco;//lstBanco;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}