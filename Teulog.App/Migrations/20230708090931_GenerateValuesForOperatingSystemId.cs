namespace Teulog.App.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class GenerateValuesForOperatingSystemId : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey("PK_OperatingSystems", "OperatingSystems");

        migrationBuilder.DropColumn("Id", "OperatingSystems");

        migrationBuilder.AddColumn<byte>("Id", "OperatingSystems", "tinyint", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1");

        migrationBuilder.AddPrimaryKey("PK_OperatingSystems", "OperatingSystems", "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey("PK_OperatingSystems", "OperatingSystems");

        migrationBuilder.DropColumn("Id", "OperatingSystems");

        migrationBuilder.AddColumn<byte>("Id", "OperatingSystems", "tinyint", nullable: false, defaultValue: byte.MinValue);

        migrationBuilder.AddPrimaryKey("PK_OperatingSystems", "OperatingSystems", "Id");
    }
}
