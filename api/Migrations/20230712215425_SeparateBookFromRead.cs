using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeparateBookFromRead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Book_BookId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Book_BookId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "NumberOfPagesRead",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PercentageRead",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Review",
                newName: "WrittenReview");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Review",
                newName: "ReadId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BookId",
                table: "Review",
                newName: "IX_Review_ReadId");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Log",
                newName: "Thoughts");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Log",
                newName: "ReadId");

            migrationBuilder.RenameIndex(
                name: "IX_Log_BookId",
                table: "Log",
                newName: "IX_Log_ReadId");

            migrationBuilder.CreateTable(
                name: "Read",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfPagesRead = table.Column<int>(type: "INTEGER", nullable: false),
                    PercentageRead = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Read", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Read_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Read_BookId",
                table: "Read",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Read_ReadId",
                table: "Log",
                column: "ReadId",
                principalTable: "Read",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Read_ReadId",
                table: "Review",
                column: "ReadId",
                principalTable: "Read",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Read_ReadId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Read_ReadId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Read");

            migrationBuilder.RenameColumn(
                name: "WrittenReview",
                table: "Review",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "ReadId",
                table: "Review",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ReadId",
                table: "Review",
                newName: "IX_Review_BookId");

            migrationBuilder.RenameColumn(
                name: "Thoughts",
                table: "Log",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "ReadId",
                table: "Log",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Log_ReadId",
                table: "Log",
                newName: "IX_Log_BookId");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPagesRead",
                table: "Book",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentageRead",
                table: "Book",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Book",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Book_BookId",
                table: "Log",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Book_BookId",
                table: "Review",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
