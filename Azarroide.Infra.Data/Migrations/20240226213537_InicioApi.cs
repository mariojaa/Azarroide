using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azarroide.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicioApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColaboradorEntitie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaColaborador = table.Column<int>(type: "int", nullable: false),
                    NomeCompletoColaborador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailColaborador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeEUltimoNomeColaborador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetorColaborador = table.Column<int>(type: "int", nullable: false),
                    RamalColaborador = table.Column<int>(type: "int", nullable: false),
                    PerfilColaborador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorEntitie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaEntitie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    abertura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    situacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaEntitie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    abertura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    situacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CadastroDeProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProdutoCadastrar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDoCadastroDeProduto = table.Column<int>(type: "int", nullable: false),
                    ColaboradorCadastroProdutoId = table.Column<int>(type: "int", nullable: true),
                    EmpresaModelApiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroDeProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CadastroDeProdutos_ColaboradorEntitie_ColaboradorCadastroProdutoId",
                        column: x => x.ColaboradorCadastroProdutoId,
                        principalTable: "ColaboradorEntitie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CadastroDeProdutos_EmpresaModel_EmpresaModelApiId",
                        column: x => x.EmpresaModelApiId,
                        principalTable: "EmpresaModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CadastroDeProdutos_ColaboradorCadastroProdutoId",
                table: "CadastroDeProdutos",
                column: "ColaboradorCadastroProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_CadastroDeProdutos_EmpresaModelApiId",
                table: "CadastroDeProdutos",
                column: "EmpresaModelApiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadastroDeProdutos");

            migrationBuilder.DropTable(
                name: "EmpresaEntitie");

            migrationBuilder.DropTable(
                name: "ColaboradorEntitie");

            migrationBuilder.DropTable(
                name: "EmpresaModel");
        }
    }
}
