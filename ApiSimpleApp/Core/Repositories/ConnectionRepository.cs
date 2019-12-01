using ApiSimpleApp.Commons;
using ApiSimpleApp.Core.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSimpleApp.Core.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly IConfiguration _config;

        public ConnectionRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection()
            {
                ConnectionString = _config.GetConnectionString("DefaultConnection")
            };

            return conn;
        }


        public List<T> ExecuteQueryProcedure<T>(String procedimiento, Dictionary<string, object> parametros = null)
        {
            SqlConnection connection = null;
            try
            {
                connection = ObtenerConexion();
                connection.Open();
                SqlCommand command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (KeyValuePair<string, object> parametro in parametros)
                    {
                        SqlParameter sqlPar = new SqlParameter("@" + parametro.Key, parametro.Value);
                        sqlPar.Direction = ParameterDirection.Input;
                        command.Parameters.Add(sqlPar);
                    }
                }
                return GenericHelper.GetAsList<T>(command.ExecuteReader());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
            }
        }

        public List<T> ExecuteQueryProcedureToXmlList<T>(String procedimiento, Dictionary<string, object> parametros = null)
        {
            SqlConnection connection = null;
            try
            {
                connection = ObtenerConexion();
                connection.Open();
                SqlCommand command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (KeyValuePair<string, object> parametro in parametros)
                    {
                        SqlParameter sqlPar = new SqlParameter("@" + parametro.Key, parametro.Value);
                        sqlPar.Direction = ParameterDirection.Input;
                        command.Parameters.Add(sqlPar);
                    }
                }
                System.Xml.XmlReader sqlDataReader = command.ExecuteXmlReader();
                if (sqlDataReader.Read())
                {
                    return SerializationHelper.DeserializeFromXMLToList<T>(sqlDataReader.ReadOuterXml());
                }
                return new List<T> { };
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
            }
        }

        public DataTable ExecuteQueryProcedureToTable(String procedimiento, Dictionary<string, object> parametros = null)
        {
            SqlConnection connection = null;
            try
            {
                connection = ObtenerConexion();
                connection.Open();
                SqlCommand command = new SqlCommand(procedimiento, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                {
                    foreach (KeyValuePair<string, object> parametro in parametros)
                    {
                        SqlParameter sqlPar = new SqlParameter("@" + parametro.Key, parametro.Value);
                        sqlPar.Direction = ParameterDirection.Input;
                        command.Parameters.Add(sqlPar);
                    }
                }
                DataTable dataTable = new DataTable();
                //SqlDataAdapter sqlDataReader = new SqlDataAdapter(command);
                SqlDataReader sqlDataReader = command.ExecuteReader();

                //sqlDataReader.Fill(dataTable);

                dataTable.Load(sqlDataReader);

                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
            }
        }

        public T ExecuteQueryProcedureToXml<T>(String procedimiento, Dictionary<string, object> parametros = null)
        {
            SqlConnection connection = null;
            try
            {
                connection = ObtenerConexion();
                connection.Open();
                SqlCommand command = new SqlCommand(procedimiento, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                {
                    foreach (KeyValuePair<string, object> parametro in parametros)
                    {
                        SqlParameter sqlPar = new SqlParameter("@" + parametro.Key, parametro.Value)
                        {
                            Direction = ParameterDirection.Input
                        };
                        command.Parameters.Add(sqlPar);
                    }
                }
                System.Xml.XmlReader sqlDataReader = command.ExecuteXmlReader();
                if (sqlDataReader.Read())
                {
                    return SerializationHelper.DeserializeFromXML<T>(sqlDataReader.ReadOuterXml());
                }
                return default(T);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
            }
        }

        public void ExecuteStoreProcedureVoid(String procedimiento, Dictionary<string, object> parametros = null)
        {
            SqlConnection connection = null;
            try
            {
                connection = ObtenerConexion();
                connection.Open();
                SqlCommand command = new SqlCommand(procedimiento, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                {
                    foreach (KeyValuePair<string, object> parametro in parametros)
                    {
                        SqlParameter sqlPar = new SqlParameter("@" + parametro.Key, parametro.Value)
                        {
                            Direction = ParameterDirection.Input
                        };
                        command.Parameters.Add(sqlPar);
                    }
                }
                command.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
            }
        }

    }
}
