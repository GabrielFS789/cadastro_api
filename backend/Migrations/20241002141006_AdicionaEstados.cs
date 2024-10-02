using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaEstados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into \"Estado\" values\r\n('11','RO','Rondônia'),\r\n('12','AC','Acre'),\r\n('13','AM','Amazonas'),\r\n('14','RR','Roraima'),\r\n('15','PA','Pará'),\r\n('16','AP','Amapá'),\r\n('17','TO','Tocantins'),\r\n('21','MA','Maranhão'),\r\n('22','PI','Piauí'),\r\n('23','CE','Ceará'),\r\n('24','RN','Rio Grande do Norte'),\r\n('25','PB','Paraíba'),\r\n('26','PE','Pernambuco'),\r\n('27','AL','Alagoas'),\r\n('28','SE','Sergipe'),\r\n('29','BA','Bahia'),\r\n('31','MG','Minas Gerais'),\r\n('32','ES','Espírito Santo'),\r\n('33','RJ','Rio de Janeiro'),\r\n('35','SP','São Paulo'),\r\n('41','PR','Paraná'),\r\n('42','SC','Santa Catarina'),\r\n('43','RS','Rio Grande do Sul'),\r\n('50','MS','Mato Grosso do Sul'),\r\n('51','MT','Mato Grosso'),\r\n('52','GO','Goiás'),\r\n('53','DF','Distrito Federal')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from \"Estado\"");
        }
    }
}
