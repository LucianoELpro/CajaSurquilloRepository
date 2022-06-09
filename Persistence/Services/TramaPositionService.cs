using Application.Interfaces.Services;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class TramaPositionService : ITramaPosition
    {
        private readonly IDataConnection _dataConnection;
        public TramaPositionService(IDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }
        public async  Task<List<TramaPosition>> GetTramaPosition()
        {
            using (var connection = _dataConnection.GetConnection())
            {
                connection.Open();
                var Lista = await connection.QueryAsync<TramaPosition>("SpListTramaPosition"
                    , commandType: CommandType.StoredProcedure);
                connection.Close();

                return Lista.ToList();
            }
        }
    }
}
