using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbolosApi.DTOs.Cliente
{
    public class CreateClienteDTO
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? SenhaHash { get; set; }
    }
}