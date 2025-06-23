using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MbolosApi.DTOs.Produtos
{
    public class ProdutoDTOUpdateRequest : IValidatableObject
    {
        [Range(1, 9999, ErrorMessage = "Estoque tem que estar entre 1 e 9999")]
        public int QuantidadeEstoque { get; set; }
        public DateTime DataValidade { get; set; }
        public bool Ativo { get; set; } = true;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataValidade.Date <= DateTime.Now.Date)
            {
                yield return new ValidationResult("A Data de validade deve ser maior que a data atual", new[] { nameof(this.DataValidade) });
            }
        }
    }
}