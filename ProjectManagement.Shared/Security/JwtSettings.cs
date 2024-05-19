using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShelter.Shared.Security.Contracts;

namespace PetShelter.Shared.Security
{
    public class JwtSettings : IJwtSettings
    {
        public string Issuer { get; set; }
        public string Key { get; set; }
        public string Audience { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
