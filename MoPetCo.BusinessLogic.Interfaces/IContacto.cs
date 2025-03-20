using MoPetCo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.BusinessLogic.Interfaces
{
    public interface IContacto
    {
        Task<Response<Models.Contacto>> EnviarEmailAsync(Models.Contacto contacto);
    }
}
