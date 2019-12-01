using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSimpleApp.Core.Repositories.Interfaces
{
    public interface IConnectionRepository
    {
        SqlConnection ObtenerConexion();
        List<T> ExecuteQueryProcedure<T>(String procedimiento, Dictionary<string, object> parametros = null);
        List<T> ExecuteQueryProcedureToXmlList<T>(String procedimiento, Dictionary<string, object> parametros = null);
        DataTable ExecuteQueryProcedureToTable(String procedimiento, Dictionary<string, object> parametros = null);
        T ExecuteQueryProcedureToXml<T>(String procedimiento, Dictionary<string, object> parametros = null);
        void ExecuteStoreProcedureVoid(String procedimiento, Dictionary<string, object> parametros = null);
    }
}
