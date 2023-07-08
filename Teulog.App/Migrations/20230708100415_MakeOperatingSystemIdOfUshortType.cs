namespace Teulog.App.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class MakeOperatingSystemIdOfUshortType : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey("PK_OperatingSystems", "OperatingSystems");

        migrationBuilder
            .AlterColumn<int>("Id", "OperatingSystems", "int", nullable: false, oldClrType: typeof(byte), oldType: "tinyint")
            .Annotation("SqlServer:Identity", "1, 1")
            .OldAnnotation("SqlServer:Identity", "1, 1");

        migrationBuilder.AddPrimaryKey("PK_OperatingSystems", "OperatingSystems", "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey("PK_OperatingSystems", "OperatingSystems");

        migrationBuilder
            .AlterColumn<byte>("Id", "OperatingSystems", "tinyint", nullable: false, oldClrType: typeof(int), oldType: "int")
            .Annotation("SqlServer:Identity", "1, 1")
            .OldAnnotation("SqlServer:Identity", "1, 1");

        migrationBuilder.AddPrimaryKey("PK_OperatingSystems", "OperatingSystems", "Id");
    }
}
