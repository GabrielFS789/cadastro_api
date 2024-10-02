﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Model
{
    public class Entidade
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo nome é obrigatório"), MaxLength(50, ErrorMessage ="O campo \"nome\" deve ter no max 50 caracteres")]
        public string? Nome { get; set; }

        [Required, DefaultValue(false)]
        public bool Inativo { get; set; }

        [MaxLength(255, ErrorMessage ="O campo \"Endereco\" deve conter no máximo 255 caracteres")]
        public string? Endereco { get; set; }

        public string? NumeroEndereco { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public int CidadeId { get; set; }

        [JsonIgnore]
        public Cidade? Cidade{ get; set; }
        public string? Telefone { get; set; }

        [MaxLength(13, ErrorMessage ="O numero deve ter 13 caracteres. Ex: \"5547991127590\"")]
        [MinLength(13, ErrorMessage = "O numero deve ter 13 caracteres. Ex: \"5547991127590\"")]
        public string? Celular { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
