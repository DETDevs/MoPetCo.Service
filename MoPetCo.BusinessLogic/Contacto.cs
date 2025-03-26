using MoPetCo.BusinessLogic.Extensions;
using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace MoPetCo.BusinessLogic
{
    public class Contacto : IContacto
    {
        private readonly DataAccess.Interfaces.IContacto? contacto;
        private readonly EmailService? emailService;
        public Contacto(DataAccess.Interfaces.IContacto? contacto, EmailService? emailService)
        {
            this.contacto = contacto;
            this.emailService = emailService;
        }

        public async Task<Response<Models.Contacto>> EnviarEmailAsync(Models.Contacto contacto)
        {
            #region mensaje
            var mensaje = $@"
               <html>
                <head>
                    <style>
                        body {{font - family: Arial, sans-serif;
                            background-color: #f4f4f4;
                            margin: 0;
                            padding: 0;
                        }}
                        .container {{width: 100%;
                            max-width: 600px;
                            margin: 20px auto;
                            background-color: #ffffff;
                            padding: 20px;
                            border-radius: 10px;
                            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
                            border-left: 5px solid #007bff;
                        }}
                        .header {{text - align: center;
                            padding-bottom: 10px;
                            border-bottom: 2px solid #ddd;
                        }}
                        .header h2 {{color: #007bff;
                            margin: 0;
                        }}
                        .content p {{font - size: 14px;
                            color: #555;
                            margin: 10px 0;
                            line-height: 1.5;
                        }}
                        .highlight {{font - weight: bold;
                            color: #333;
                        }}
                        .footer {{text - align: center;
                            font-size: 12px;
                            color: #999;
                            margin-top: 20px;
                            padding-top: 10px;
                            border-top: 2px solid #ddd;
                        }}
                        .footer a {{color: #007bff;
                            text-decoration: none;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h2>📩 Nuevo mensaje de contacto</h2>
                        </div>
                        <div class='content'>
                            <p><span class='highlight'>📛 Nombre:</span> {contacto.Nombre}</p>
                            <p><span class='highlight'>✉️ Correo:</span> {contacto.Correo}</p>
                            <p><span class='highlight'>📍 Dirección:</span> {contacto.Direccion}</p>
                            <p><span class='highlight'>🏙️ Ciudad:</span> {contacto.Ciudad}</p>
                            <p><span class='highlight'>📮 Código Postal:</span> {contacto.CodigoPostal}</p>
                            <p><span class='highlight'>📞 Teléfono:</span> {contacto.Number}</p>
                            <p><span class='highlight'>❓ Pregunta:</span> {contacto.Mensaje}</p>
                        </div>
                        <div class='footer'>
                            <p>Este correo fue generado automáticamente. No respondas a este mensaje.</p>
                            <p><a href='https://mopetco.com'>Visita nuestro sitio web</a></p>
                        </div>
                    </div>
                </body>
                </html>
                ";
            #endregion

            var emailService = new EmailService();
            await emailService.EnviarCorreoAsync(
                "at2899743@gmail.com",
                "MoPetCo",
                mensaje
            );

            return await this.contacto.GuardarContactoAsync(contacto);
        }
    }
}
