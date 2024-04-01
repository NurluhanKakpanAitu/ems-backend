using Domain.Entity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTitleColumnDicTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""DicSubjects""
                ALTER COLUMN ""Title"" TYPE jsonb
                USING ""Title""::jsonb;
            ");
            migrationBuilder.Sql(@"
                ALTER TABLE ""DicQuestionGroups""
                ALTER COLUMN ""Title"" TYPE jsonb
                USING ""Title""::jsonb;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""DicQuestionTypes""
                ALTER COLUMN ""Title"" TYPE jsonb
                USING ""Title""::jsonb;");
            migrationBuilder.Sql(@"
                ALTER TABLE ""DicQuizTypes""
                ALTER COLUMN ""Title"" TYPE jsonb
                USING ""Title""::jsonb;");
            migrationBuilder.AlterColumn<TranslationBaseEntity>(
                name: "Title",
                table: "DicSubjects",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<TranslationBaseEntity>(
                name: "Title",
                table: "DicQuizTypes",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<TranslationBaseEntity>(
                name: "Title",
                table: "DicQuestionTypes",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<TranslationBaseEntity>(
                name: "Title",
                table: "DicQuestionGroups",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "DicSubjects",
                type: "text",
                nullable: false,
                oldClrType: typeof(TranslationBaseEntity),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "DicQuizTypes",
                type: "text",
                nullable: false,
                oldClrType: typeof(TranslationBaseEntity),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "DicQuestionTypes",
                type: "text",
                nullable: false,
                oldClrType: typeof(TranslationBaseEntity),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "DicQuestionGroups",
                type: "text",
                nullable: false,
                oldClrType: typeof(TranslationBaseEntity),
                oldType: "jsonb");
        }
    }
}
