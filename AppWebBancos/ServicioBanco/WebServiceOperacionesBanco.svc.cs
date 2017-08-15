using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ServicioBanco
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WebServiceOperacionesBanco" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WebServiceOperacionesBanco.svc o WebServiceOperacionesBanco.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WebServiceOperacionesBanco : IWebServiceOperacionesBanco
    {
        public void DoWork()
        {
        }

        public List<Sucursal> ObtenerSucursalPorBanco(int IdBanco)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["MVC"].ConnectionString.ToString();
            try
            {
                DataTable oDt = new DataTable();
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("USP_OBTENER_SUCURSALXBANCO", conn);
                   
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@IdBanco", IdBanco);
                    //List<Banco> lstBanco = new List<Banco>();
                    //SqlDataAdapter dr = new SqlDataAdapter(command);
                    //dr.Fill(oDt);
                    //conn.Close();

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
               // return oDt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
