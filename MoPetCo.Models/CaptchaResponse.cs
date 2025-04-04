using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.Models
{
    // Este modelo mapea la respuesta JSON que devuelve Google
    public class GoogleCaptchaResponse
    {
        public bool Success { get; set; }

        public string ChallengeTimeStamp { get; set; }

        public string Hostname { get; set; }

        public string[] ErrorCodes { get; set; }
    }
}
