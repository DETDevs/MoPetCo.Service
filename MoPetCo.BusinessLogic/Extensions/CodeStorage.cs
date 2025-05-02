using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.BusinessLogic.Extensions
{
    public class CodeStorage
    {
        private readonly Dictionary<string, CodeEntry> _codes = new();
        private readonly TimeSpan _expirationTime = TimeSpan.FromMinutes(5); // tiempo de vida del código

        public void SaveCode(string email, string code)
        {
            CleanupExpired(); // limpia antes de guardar

            var entry = new CodeEntry
            {
                Code = code,
                Expiration = DateTime.UtcNow.Add(_expirationTime)
            };

            _codes[email] = entry; // reemplaza el anterior si existe
        }

        public bool ValidateCode(string email, string code)
        {
            if (_codes.TryGetValue(email, out var entry))
            {
                if (DateTime.UtcNow <= entry.Expiration && entry.Code == code)
                {
                    _codes.Remove(email); // eliminar tras validación exitosa
                    return true;
                }
            }

            return false;
        }

        public void CleanupExpired()
        {
            var now = DateTime.UtcNow;
            var expiredKeys = _codes
                .Where(pair => pair.Value.Expiration < now)
                .Select(pair => pair.Key)
                .ToList();

            foreach (var key in expiredKeys)
                _codes.Remove(key);
        }

    }


    public class CodeEntry
    {
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }

}
