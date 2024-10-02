using System.Text.Json.Serialization;

namespace backend.Model
{
    public class Cidade
    {
        public int Id { get; set; }
        public string? CodigoIBGE { get; set; }
        public string? NomeCidade { get; set; }
        public int EstadoId { get; set; }
        [JsonIgnore]
        public Estado Estado { get; set; }
    }
}
