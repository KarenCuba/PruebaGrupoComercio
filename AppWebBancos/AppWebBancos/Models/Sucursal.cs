using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace AppWebBancos.Models
{
    public class Sucursal
    {
        public Sucursal()
        {
            this.ListaBanco = new SelectList(new List<Banco>());
            this.ListaSucursal = new SelectList(new List<Sucursal>());
            this.lstSucursal = new List<Sucursal>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdBanco { get; set; }

        public SelectList ListaBanco {get; set;}
        public SelectList ListaSucursal { get; set; }

        public List<Sucursal> lstSucursal { get; set; }

        string strConnection = ConfigurationManager.ConnectionStrings["MVC"].ConnectionString.ToString();


        public Boolean InsertarSucursal(Sucursal Sucursal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_INSERTAR_SUCURSAL", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Nombre", Sucursal.Nombre);
                    command.Parameters.AddWithValue("@Direccion", Sucursal.Direccion);
                    command.Parameters.AddWithValue("@FechaRegistro", Sucursal.FechaRegistro);
                    command.Parameters.AddWithValue("@IdBanco", Sucursal.IdBanco);
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

        public List<Sucursal> ListarSucursal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_LISTAR_SUCURSAL", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    List<Sucursal> lstSucursal = new List<Sucursal>();
                    IDataReader lector = command.ExecuteReader();
                    while (lector.Read())
                    {
                        Sucursal beSucursal = new Sucursal()
                        {
                            Id = lector.GetInt32(0),
                            Nombre = lector.GetString(1),
                            Direccion = lector.GetString(2),
                            FechaRegistro = lector.GetDateTime(3),
                            IdBanco = lector.GetInt32(4),
                        };
                        lstSucursal.Add(beSucursal);
                    }

                    conn.Close();
                    return lstSucursal;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean ActualizarSucursal(Sucursal Sucursal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_ACTUALIZAR_SUCURSAL", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", Sucursal.Id);
                    command.Parameters.AddWithValue("@Nombre", Sucursal.Nombre);
                    command.Parameters.AddWithValue("@Direccion", Sucursal.Direccion);
                    command.Parameters.AddWithValue("@FechaRegistro", Sucursal.FechaRegistro);
                    command.Parameters.AddWithValue("@IdBanco", Sucursal.IdBanco);

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

        public Boolean EliminarSucursal(Sucursal Sucursal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_ELIMINAR_SUCURSAL", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", Sucursal.Id);
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

        public Sucursal ObtenerPorId(int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_OBTENER_SUCURSAL_ID", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@Id", Id);
                    //List<Banco> lstBanco = new List<Banco>();
                    IDataReader lector = command.ExecuteReader();
                    Sucursal beSucursal = null;
                    while (lector.Read())
                    {
                        beSucursal = new Sucursal()
                        {
                            Id = lector.GetInt32(0),
                            Nombre = lector.GetString(1),
                            Direccion = lector.GetString(2),
                            FechaRegistro = lector.GetDateTime(3),
                            IdBanco = lector.GetInt32(4),
                        };
                        // lstBanco.Add(beBanco);
                    }

                    conn.Close();
                    return beSucursal;//lstBanco;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}