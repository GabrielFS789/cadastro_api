using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaUsuarioAdministrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"Usuario\"\r\n(\"Id\", \"Inativo\", \"Nome\", \"Email\", \"Password\", \"Administrador\", \"PerfilId\")\r\nVALUES(1, false, 'Administrador', 'admin@admin.com', '$2a$10$Rl4P/VMC1BILQEzvyw6gMefqxaqslATc4BGeXvM8YrOLHWrd5UiRi', true, 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.\"Usuario\"\r\nWHERE \"Id\"=1;");
        }
    }
}
