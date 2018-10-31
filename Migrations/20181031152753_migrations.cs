using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.AspNetCore.NewDb.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatto",
                columns: table => new
                {
                    ContattoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nTelefono = table.Column<string>(nullable: true),
                    nFax = table.Column<string>(nullable: true),
                    nCellulare = table.Column<string>(nullable: true),
                    eMail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatto", x => x.ContattoId);
                });

            migrationBuilder.CreateTable(
                name: "Indirizzo",
                columns: table => new
                {
                    IndirizzoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    indirizzoSpedizione = table.Column<string>(nullable: true),
                    indirizzoFatturazione = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indirizzo", x => x.IndirizzoId);
                });

            migrationBuilder.CreateTable(
                name: "Spedizione",
                columns: table => new
                {
                    SpedizioneId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    descrizione = table.Column<string>(nullable: true),
                    costiSpedizione = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spedizione", x => x.SpedizioneId);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    TipoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descrizione = table.Column<string>(nullable: true),
                    pIVA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<string>(nullable: false),
                    nome = table.Column<string>(nullable: false),
                    cognome = table.Column<string>(nullable: false),
                    dNascita = table.Column<string>(nullable: false),
                    sesso = table.Column<char>(nullable: false),
                    ContattoId = table.Column<int>(nullable: false),
                    IndirizzoId = table.Column<int>(nullable: false),
                    TipoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Contatto_ContattoId",
                        column: x => x.ContattoId,
                        principalTable: "Contatto",
                        principalColumn: "ContattoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_Indirizzo_IndirizzoId",
                        column: x => x.IndirizzoId,
                        principalTable: "Indirizzo",
                        principalColumn: "IndirizzoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_Tipo_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipo",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fattura",
                columns: table => new
                {
                    FatturaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quantitaProdotto = table.Column<int>(nullable: false),
                    iva = table.Column<int>(nullable: false),
                    sconto = table.Column<int>(nullable: false),
                    totFattura = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    ClienteId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fattura", x => x.FatturaId);
                    table.ForeignKey(
                        name: "FK_Fattura_Cliente_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acquisti",
                columns: table => new
                {
                    AcquistiID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    ClienteId1 = table.Column<string>(nullable: true),
                    SpedizioneId = table.Column<int>(nullable: false),
                    FatturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquisti", x => x.AcquistiID);
                    table.ForeignKey(
                        name: "FK_Acquisti_Cliente_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acquisti_Fattura_FatturaId",
                        column: x => x.FatturaId,
                        principalTable: "Fattura",
                        principalColumn: "FatturaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acquisti_Spedizione_SpedizioneId",
                        column: x => x.SpedizioneId,
                        principalTable: "Spedizione",
                        principalColumn: "SpedizioneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acquisti_ClienteId1",
                table: "Acquisti",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisti_FatturaId",
                table: "Acquisti",
                column: "FatturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisti_SpedizioneId",
                table: "Acquisti",
                column: "SpedizioneId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ContattoId",
                table: "Cliente",
                column: "ContattoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IndirizzoId",
                table: "Cliente",
                column: "IndirizzoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_TipoId",
                table: "Cliente",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fattura_ClienteId1",
                table: "Fattura",
                column: "ClienteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acquisti");

            migrationBuilder.DropTable(
                name: "Fattura");

            migrationBuilder.DropTable(
                name: "Spedizione");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Contatto");

            migrationBuilder.DropTable(
                name: "Indirizzo");

            migrationBuilder.DropTable(
                name: "Tipo");
        }
    }
}
