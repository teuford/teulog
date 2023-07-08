namespace Teulog.App.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddIdPropertyToOperatingSystem : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey("PK_OperatingSystems", "OperatingSystems");

        migrationBuilder.AddColumn<byte>("Id", "OperatingSystems", "tinyint", nullable: false, defaultValue: byte.MinValue);

        migrationBuilder.AddPrimaryKey("PK_OperatingSystems", "OperatingSystems", "Id");

        migrationBuilder.CreateIndex("IX_OperatingSystems_Title", "OperatingSystems", "Title", unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey("PK_OperatingSystems", "OperatingSystems");

        migrationBuilder.DropIndex("IX_OperatingSystems_Title", "OperatingSystems");

        migrationBuilder.DropColumn("Id", "OperatingSystems");

        migrationBuilder.AddPrimaryKey("PK_OperatingSystems", "OperatingSystems", "Title");
    }
}
