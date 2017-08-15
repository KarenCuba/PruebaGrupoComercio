using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ServicioBanco
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWebServiceOperacionesBanco" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWebServiceOperacionesBanco
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<Sucursal> ObtenerSucursalPorBanco(int IdBanco);
    }
}
