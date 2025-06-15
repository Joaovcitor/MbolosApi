using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbolosApi.DTOs.Cliente
{
    public class ListClienteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}