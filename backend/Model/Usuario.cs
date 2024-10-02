using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public class Usuario
    {
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool Inativo { get; set; }

        [MaxLength(100)]
        public string? Nome { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
