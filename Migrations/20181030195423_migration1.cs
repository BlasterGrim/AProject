using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.AspNetCore.NewDb.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

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
                name: "Fattura",
                columns: table => new
                {
                    FatturaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quantitaProdotto = table.Column<int>(nullable: false),
                    iva = table.Column<int>(nullable: false),
                    sconto = table.Column<int>(nullable: false),
                    totFattura = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fattura", x => x.FatturaId);
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
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<string>(nullable: false),
                    nome = table.Column<string>(nullable: true),
                    cognome = table.Column<string>(nullable: true),
                    dNascita = table.Column<string>(nullable: true),
                    sesso = table.Column<char>(nullable: false),
                    ContattoId = table.Column<int>(nullable: false),
                    SpedizioneId = table.Column<int>(nullable: false)
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
                        name: "FK_Cliente_Spedizione_SpedizioneId",
                        column: x => x.SpedizioneId,
                        principalTable: "Spedizione",
                        principalColumn: "SpedizioneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ContattoId",
                table: "Cliente",
                column: "ContattoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_SpedizioneId",
                table: "Cliente",
                column: "SpedizioneId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Fattura");

            migrationBuilder.DropTable(
                name: "Indirizzo");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Contatto");

            migrationBuilder.DropTable(
                name: "Spedizione");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
