using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionaleMunicipale.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafiche",
                columns: table => new
                {
                    IdAnagrafica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CAP = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CF = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafiche", x => x.IdAnagrafica);
                });

            migrationBuilder.CreateTable(
                name: "TipiViolazioni",
                columns: table => new
                {
                    IdViolazione = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipiViolazioni", x => x.IdViolazione);
                });

            migrationBuilder.CreateTable(
                name: "Verbali",
                columns: table => new
                {
                    IdVerbale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAnagrafica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataViolazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NominativoAgente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataTrascrizioneVerbale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbali", x => x.IdVerbale);
                    table.ForeignKey(
                        name: "FK_Verbali_Anagrafiche_IdAnagrafica",
                        column: x => x.IdAnagrafica,
                        principalTable: "Anagrafiche",
                        principalColumn: "IdAnagrafica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerbaliViolazioni",
                columns: table => new
                {
                    IdVerbale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdViolazione = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbaliViolazioni", x => new { x.IdVerbale, x.IdViolazione });
                    table.ForeignKey(
                        name: "FK_VerbaliViolazioni_TipiViolazioni_IdViolazione",
                        column: x => x.IdViolazione,
                        principalTable: "TipiViolazioni",
                        principalColumn: "IdViolazione",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerbaliViolazioni_Verbali_IdVerbale",
                        column: x => x.IdVerbale,
                        principalTable: "Verbali",
                        principalColumn: "IdVerbale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_IdAnagrafica",
                table: "Verbali",
                column: "IdAnagrafica");

            migrationBuilder.CreateIndex(
                name: "IX_VerbaliViolazioni_IdViolazione",
                table: "VerbaliViolazioni",
                column: "IdViolazione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerbaliViolazioni");

            migrationBuilder.DropTable(
                name: "TipiViolazioni");

            migrationBuilder.DropTable(
                name: "Verbali");

            migrationBuilder.DropTable(
                name: "Anagrafiche");
        }
    }
}
