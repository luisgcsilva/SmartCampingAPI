using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCampingAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoReservas",
                columns: table => new
                {
                    EstadoReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoReservas", x => x.EstadoReservaId);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagamentos",
                columns: table => new
                {
                    MetodoPagamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metodo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagamentos", x => x.MetodoPagamentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoAlojamentos",
                columns: table => new
                {
                    TipoAlojamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAlojamentos", x => x.TipoAlojamentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoUtilizadores",
                columns: table => new
                {
                    TipoUtilizadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUtilizadores", x => x.TipoUtilizadorId);
                });

            migrationBuilder.CreateTable(
                name: "Alojamentos",
                columns: table => new
                {
                    AlojamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAlojamentoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamentos", x => x.AlojamentoId);
                    table.ForeignKey(
                        name: "FK_Alojamentos_TipoAlojamentos_TipoAlojamentoId",
                        column: x => x.TipoAlojamentoId,
                        principalTable: "TipoAlojamentos",
                        principalColumn: "TipoAlojamentoId",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoUtilizadorId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PalavraPasse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.UtilizadorId);
                    table.ForeignKey(
                        name: "FK_Utilizadores_TipoUtilizadores_TipoUtilizadorId",
                        column: x => x.TipoUtilizadorId,
                        principalTable: "TipoUtilizadores",
                        principalColumn: "TipoUtilizadorId",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telemovel = table.Column<int>(type: "int", nullable: false),
                    NIF = table.Column<int>(type: "int", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "UtilizadorId",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telemovel = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "UtilizadorId",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    AlojamentoId = table.Column<int>(type: "int", nullable: false),
                    MetodoPagamentoId = table.Column<int>(type: "int", nullable: false),
                    EstadoReservaId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecoNoite = table.Column<double>(type: "float", nullable: false),
                    PrecoTotal = table.Column<double>(type: "float", nullable: false),
                    Pagamento = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reservas_Alojamentos_AlojamentoId",
                        column: x => x.AlojamentoId,
                        principalTable: "Alojamentos",
                        principalColumn: "AlojamentoId",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_EstadoReservas_EstadoReservaId",
                        column: x => x.EstadoReservaId,
                        principalTable: "EstadoReservas",
                        principalColumn: "EstadoReservaId",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_MetodoPagamentos_MetodoPagamentoId",
                        column: x => x.MetodoPagamentoId,
                        principalTable: "MetodoPagamentos",
                        principalColumn: "MetodoPagamentoId",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Alojamentos_TipoAlojamentoId",
                table: "Alojamentos",
                column: "TipoAlojamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UtilizadorId",
                table: "Clientes",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_UtilizadorId",
                table: "Funcionarios",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AlojamentoId",
                table: "Reservas",
                column: "AlojamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_EstadoReservaId",
                table: "Reservas",
                column: "EstadoReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MetodoPagamentoId",
                table: "Reservas",
                column: "MetodoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_TipoUtilizadorId",
                table: "Utilizadores",
                column: "TipoUtilizadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Alojamentos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadoReservas");

            migrationBuilder.DropTable(
                name: "MetodoPagamentos");

            migrationBuilder.DropTable(
                name: "TipoAlojamentos");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "TipoUtilizadores");
        }
    }
}
