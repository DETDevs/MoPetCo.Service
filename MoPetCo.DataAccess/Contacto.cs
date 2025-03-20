using Dapper;
using MoPetCo.DataAccess.Interfaces;
using MoPetCo.Models;
using System.Data;

namespace MoPetCo.DataAccess
{
    public class Contacto : IContacto
    {
        private IConnectionManager connectionManager;

        public Contacto(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<Response<Models.Contacto>> GuardarContactoAsync(Models.Contacto contacto)
        {
            try
            {
                using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

                var resultado = await connection.QueryAsync<Models.Contacto>(

                    "sp_Contacto_Guardar",
                    param: new
                    {
                        contacto.Nombre,
                        contacto.Correo,
                        contacto.Direccion,
                        contacto.Mensaje,
                        contacto.FechaEnvio,
                        contacto.Estado

                    },
                    commandType: CommandType.StoredProcedure
                );

                return new Response<Models.Contacto> { Content = resultado.FirstOrDefault(), IsSuccess = true, Message = "Registro de contacto guardadado correctamente" };

            }
            catch (Exception ex)
            {
                return new Response<Models.Contacto> { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
