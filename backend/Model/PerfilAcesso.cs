namespace backend.Model
{
    public class PerfilAcesso
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public Perfil? Perfil { get; set; }
        public string? Recurso{ get; set; }
        public bool Permissao { get; set; }
    }
}
