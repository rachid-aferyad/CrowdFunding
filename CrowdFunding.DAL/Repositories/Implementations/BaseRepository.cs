using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.ADO;

namespace CrowdFunding.DAL.Repositories.Implementations
{
    public abstract class BaseRepository
    {
        protected Connection _connection;
        private ConnectionStringSettings ConnectionString { get { return ConfigurationManager.ConnectionStrings["CrowdFundingDB.SqlClient"]; } }

        public BaseRepository()
        {
            _connection = new Connection(ConnectionString.ConnectionString, ConnectionString.ProviderName);
        }
    }
}

