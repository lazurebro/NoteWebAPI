using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.BusinessLogic
{
    public class AuthSettings
    {
        public TimeSpan Expires { get; set; }
        public string SecretKey { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;

        public string GetSecretKey()
        {
            return Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? this.SecretKey;
        }
    }
}
