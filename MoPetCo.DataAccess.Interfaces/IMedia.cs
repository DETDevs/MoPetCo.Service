using MoPetCo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.DataAccess.Interfaces
{
    public interface IMedia
    {
        Task<Response<Imagen>> GuardarImagenAsync(Imagen img);
        Task<Response<IEnumerable<Imagen>>> ObtenerImagenesAsync();
    }
}
