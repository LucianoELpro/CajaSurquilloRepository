using Application.Interfaces;
using Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Application.Interfaces.Services;

namespace Persistence.Repositories
{
    //public class CardRequestRepository : DataConnection ,ICardRequestRepository
    public class CardRequestRepository : ICardRequestRepository
    {
      
        private readonly IDataConnection _dataConnection;
        public CardRequestRepository(IDataConnection dataConnection)
        {
            this._dataConnection = dataConnection;
        }

        public async Task<List<CardRequest>> GetAllCardRequest()
        {
            using (var connection = _dataConnection.GetConnection())
            {
                connection.Open();
                var Lista = await connection.QueryAsync<CardRequest>("OnProcessCardRequestList"
                    , commandType: CommandType.StoredProcedure);
                connection.Close();

                return Lista.ToList();
            }

        }


    }
}
