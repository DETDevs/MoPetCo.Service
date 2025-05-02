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

        public async Task<Models.Response<IEnumerable<Models.Imagen>>> ObtenerImagenesAsync()
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Models.Imagen>(

                "sp_Imagen_Listar",
                commandType: CommandType.StoredProcedure
            );

            return new Response<IEnumerable<Models.Imagen>> { Content = resultado, IsSuccess = true };
        }

        public async Task<Response<IEnumerable<Video>>> ObtenerVideosAsync()
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Models.Video>(

                "sp_Video_Listar",
                commandType: CommandType.StoredProcedure
            );

            return new Response<IEnumerable<Models.Video>> { Content = resultado, IsSuccess = true };
        }
    }
}
