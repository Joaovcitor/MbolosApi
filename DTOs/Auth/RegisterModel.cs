using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MbolosApi.DTOs.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Nome de usuário é obrigatório")]
        public string? UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "E-mail é obrigatório")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatória")]
        public string? Password { get; set; }
    }
}