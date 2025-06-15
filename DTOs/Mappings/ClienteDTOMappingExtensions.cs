using MbolosApi.DTOs.Cliente;
using MBolosApi.Models;
using MBolosApi.Models.Entities;


namespace MBolosApi.DTOs.Mappings
{
    public static class ClienteDTOMappingExtensions
    {
        public static CreateClienteDTO? MapToNewClienteFromDTO(this Cliente cliente)
        {
            if (cliente == null) return null;
            return new CreateClienteDTO
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                SenhaHash = cliente.SenhaHash,
            };
        }

        public static void UpdateClienteFromDTO(this Cliente cliente, UpdateClienteDTO updateClienteDTO)
        {
            if (cliente == null || updateClienteDTO == null)
                return;

            cliente.Nome = updateClienteDTO.Nome;
            cliente.Email = updateClienteDTO.Email;
            cliente.SenhaHash = updateClienteDTO.SenhaHash;
        }

    }
}