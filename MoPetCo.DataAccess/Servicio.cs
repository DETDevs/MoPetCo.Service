using Dapper;
using MoPetCo.DataAccess.Interfaces;
using MoPetCo.Models;
using System.Data;

namespace MoPetCo.DataAccess
{
    public class Servicio : IServicio
    {
        private  IConnectionManager connectionManager;

        public Servicio(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<Response<IEnumerable<Models.Servicio>>> GuardarServioAsync(Models.Servicio servicio)
        {
            try
            {
                using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

                var resultado = await connection.QueryAsync<Models.Servicio>(

                    "sp_Servicio_Guardar",
                    param: new
                    {
                        servicio.Titulo,
                        servicio.SubTitulo,
                        servicio.Incluye,
                        servicio.Descripcion
                    },
                    commandType: CommandType.StoredProcedure
                );

                return new Response<IEnumerable<Models.Servicio>> { Content = resultado, IsSuccess = true, Message = "Servicio Guardar correctamente" };

            } catch(Exception ex)
            {
                return new Response<IEnumerable<Models.Servicio>> { Message = ex.Message, IsSuccess = false };
            }   
        }

        public async Task<Response<IEnumerable<Models.Servicio>>> ObtenerServiciosAsync()
        {
            try
            {
                using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

                var resultado = await connection.QueryAsync<Models.Servicio>(

                    "sp_Servicio_Listar",
                    commandType: CommandType.StoredProcedure
                );

                return new Response<IEnumerable<Models.Servicio>> { Content = resultado, IsSuccess = true};

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Models.Servicio>> { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
