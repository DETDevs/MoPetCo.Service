using Dapper;
using MoPetCo.DataAccess.Interfaces;
using MoPetCo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.DataAccess
{
    public class Promociones : IPromociones
    {
        private IConnectionManager connectionManager;

        public Promociones(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<Response<IEnumerable<Models.Promociones>>> GetPromotionsForHomePage()
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Models.Promociones>(

                "GetPromotionsForHomePage",
                commandType: CommandType.StoredProcedure
            );

            return new Response<IEnumerable<Models.Promociones>> { Content = resultado, IsSuccess = true };
        }

        public async Task<Response<IEnumerable<Models.Promociones>>> GetPromotionsForPromotionsPage()
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Models.Promociones>(

                "GetPromotionsForPromotionsPage",
                commandType: CommandType.StoredProcedure
            );

            return new Response<IEnumerable<Models.Promociones>> { Content = resultado, IsSuccess = true };
        }
    }
}
