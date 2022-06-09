
using System.Data;
using System.Data.SqlClient;

namespace Application.Interfaces.Services
{
    public  interface IDataConnection
    {
        public IDbConnection GetConnection();
    }
}
