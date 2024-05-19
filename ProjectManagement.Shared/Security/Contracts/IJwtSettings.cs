using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Shared.Security.Contracts
{
    public interface IJwtSettings
    {
        public string Issuer { get; set; }
        public string Key { get; set; }
        public string Audience { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
