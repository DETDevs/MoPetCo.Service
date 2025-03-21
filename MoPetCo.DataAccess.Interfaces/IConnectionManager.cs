using System.Data;

namespace MoPetCo.DataAccess.Interfaces
{
    public interface IConnectionManager
    {
        IDbConnection GetConnectionString(string key);
    }
}
