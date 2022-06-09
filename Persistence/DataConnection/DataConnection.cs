using Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Persistence
{
    public  class DataConnection : IDataConnection
    {
        private readonly IConfiguration _config;

        public DataConnection(IConfiguration config)
        {
            this._config = config;
        }

        public IDbConnection GetConnection()
        {
           
            return new SqlConnection(_config.GetConnectionString("defaultConnection"));
            
        }
    }
}
