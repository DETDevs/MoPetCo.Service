using Microsoft.Extensions.Configuration;
using MoPetCo.DataAccess.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;


namespace MoPetCo.DataAccess
{
    public class ConnectionManager : IConnectionManager
    {
        public const string connectionStringKey = "MoPetCoConectionString_BD";
        private readonly IConfiguration configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection GetConnectionString(string key)
        {            
            return new SqlConnection(ConfigurationExtensions.GetConnectionString(configuration, $"{ key }"));
        }
    }
}
