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
    public class Media : IMedia
    {
        private IConnectionManager connectionManager;

        public Media(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<Models.Response<Models.Imagen>> GuardarImagenAsync(Models.Imagen img)
        {
            try
            {
                using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

                var resultado = await connection.QueryAsync<Models.Imagen>(

                    "sp_Imagen_Guardar",
                    param: new
                    {
                        img.Descripcion,
                        img.UrlImagen
                    },
                    commandType: CommandType.StoredProcedure
                );

                return new Response<Models.Imagen> { Content = resultado.FirstOrDefault(), IsSuccess = true, Message = "Imagen Guardadado correctamente" };

            }
            catch (Exception ex)
            {
                return new Response<Models.Imagen> { Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<Models.Response<IEnumerable<Models.Imagen>>> ObtenerImagenesAsync()
        {
            try
            {
                using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

                var resultado = await connection.QueryAsync<Models.Imagen>(

                    "sp_Imagen_Listar",
                    commandType: CommandType.StoredProcedure
                );

                return new Response<IEnumerable<Models.Imagen>> { Content = resultado, IsSuccess = true };

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Models.Imagen>> { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
