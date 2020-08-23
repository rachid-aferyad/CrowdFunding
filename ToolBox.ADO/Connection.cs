using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.ADO
{
    public class Connection
    {
        private string ConnectionString;

        private DbProviderFactory Factory;

        public delegate T ConvertMethod<T>(IDataRecord reader); // Func<IDataRecord,T>

        public Connection(string connectionString, string invariantName="System.Data.SqlClient")
        {
            ConnectionString = connectionString;
            Factory = DbProviderFactories.GetFactory(invariantName);
        }

        private DbConnection CreateConnection()
        {
            DbConnection connection = Factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();
            if (connection.State != System.Data.ConnectionState.Open) throw new Exception("Impossible d'ouvrir la connection.");
            return connection;
        }

        private DbCommand CreateCommand(DbConnection connection, Command command)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = command.SqlQuery;
            dbCommand.CommandType = (command.IsStoredProcedure) ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;
            foreach (Parameter parameter in command.Parameters.Values)
            {
                DbParameter dbParameter = Factory.CreateParameter();
                dbParameter.ParameterName = parameter.ParameterName;
                dbParameter.Value = parameter.Value;
                dbParameter.Direction = parameter.Direction;
                dbCommand.Parameters.Add(dbParameter);
            }
            return dbCommand;
        }

        public int ExecuteNonQuery(Command command) {
            using(DbConnection connection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(connection, command))
                {                    
                    return dbCommand.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(Command command) {
            using(DbConnection connection = CreateConnection())
            {
                using(DbCommand dbCommand = CreateCommand(connection, command))
                {
                    return dbCommand.ExecuteScalar();
                }
            }
        }
        public DataTable GetDataTable(Command command)
        {
            DataTable table = new DataTable();
            using (DbConnection connection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(connection, command))
                {
                    DbDataAdapter adapter = Factory.CreateDataAdapter();
                    adapter.SelectCommand = dbCommand;
                    adapter.Fill(table);
                }
            }
            return table;
        }

        
        public IEnumerable<T> ExecuteReader<T>(Command command, ConvertMethod<T> convert) //ConvertMethod<T> est le même type que le délégué générique de Func<IDataRecord,T>
        {
            //List<T> list = new List<T>();
            using (DbConnection connection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(connection,command))
                {
                    using (DbDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return convert(reader);
                            //list.Add(item);
                        }
                    }
                }
            }
            //return list;
        }
    }
}
