﻿using Dapper;
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

        public async Task<Response<Models.Servicio>> GuardarServioAsync(Models.Servicio servicio)
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
                        servicio.Descripcion,
                        servicio.UrlImagen,
                        servicio.Icon
                    },
                    commandType: CommandType.StoredProcedure
                );

                return new Response<Models.Servicio> { Content = resultado.FirstOrDefault(), IsSuccess = true, Message = "Servicio Guardadado correctamente" };

            } catch(Exception ex)
            {
                return new Response<Models.Servicio> { Message = ex.Message, IsSuccess = false };
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

        public async Task<Response<IEnumerable<Models.Servicio>>> ObtenerServiciosDetallesAsync()
        {
            try
            {
                using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

                var resultado = await connection.QueryAsync<Models.Servicio, Models.Precio, Models.RangoPeso, Models.Servicio>(
                    "sp_ServicioDetalles_Listar",
                    commandType: CommandType.StoredProcedure,
                    splitOn: "IdPrecio,IdRango",
                    map: (servicio, precio, rango) =>
                    {
                        if (servicio.Precio == null)
                        {
                            servicio.Precio = new List<Models.Precio>();
                        }

                        // Asociamos el precio y el rango
                        servicio.Precio.Add(precio);
                        precio.RangoPeso = rango;  // Asignamos el rango al precio

                        return servicio;
                    }
                );

                return new Response<IEnumerable<Models.Servicio>> { Content = resultado, IsSuccess = true };

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Models.Servicio>> { Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<Response<Models.RangoPeso>> GuardarRangoPesoAsync(RangoPeso rangoPeso)
        {
            try
            {
                using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

                var resultado = await connection.QueryAsync<Models.RangoPeso>(

                    "sp_RangoPeso_Guardar",
                    param: new
                    {
                        rangoPeso.Nombre,
                        rangoPeso.PesoMin,
                        rangoPeso.PesoMax
                    },
                    commandType: CommandType.StoredProcedure
                );

                return new Response<Models.RangoPeso> { Content = resultado.FirstOrDefault(), IsSuccess = true, Message = "Rango de peso Guardadado correctamente" };

            }
            catch (Exception ex)
            {
                return new Response<Models.RangoPeso> { Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<Response<Models.Precio>> GuardarPrecioAsync(Precio precio)
        {
            try
            {
                using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

                var resultado = await connection.QueryAsync<Models.Precio>(

                    "sp_Precio_Guardar",
                    param: new
                    {
                        precio.Monto,
                        IdRangoPrecio = precio.RangoPeso.IdRango,
                        IdServicio = precio.Servicio.IdServicio
                    },
                    commandType: CommandType.StoredProcedure
                );

                return new Response<Models.Precio> { Content = resultado.FirstOrDefault(), IsSuccess = true, Message = "Rango de peso Guardadado correctamente" };

            }
            catch (Exception ex)
            {
                return new Response<Models.Precio> { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
