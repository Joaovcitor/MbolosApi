using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbolosApi.DTOs.Token
{
    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}