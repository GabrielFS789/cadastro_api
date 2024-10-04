using backend.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace backend.DTOs
{
    public class EntidadeDTO
    {
        [Required]
        public int Codigo { get; set; }
        public string? Nome { get; set; }

        [DefaultValue(false)]
        public bool Inativo { get; set; }

        [MaxLength(255, ErrorMessage = "O campo \"Endereco\" deve conter no máximo 255 caracteres")]
        public string? Endereco { get; set; }

        public DateTime? DataHoraCadastro { get; private set; }

        public DateTime? DataHoraUltimaAlteracao { get; private set; }

        public string? NumeroEndereco { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public int CidadeId { get; set; }

        public string? Telefone { get; set; }

        [MaxLength(13, ErrorMessage = "O numero deve ter 13 caracteres. Ex: \"5547991127590\"")]
        [MinLength(13, ErrorMessage = "O numero deve ter 13 caracteres. Ex: \"5547991127590\"")]
        public string? Celular { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
