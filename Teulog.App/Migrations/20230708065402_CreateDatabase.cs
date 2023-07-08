namespace Teulog.App.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

file class Columns
{
    public required OperationBuilder<AddColumnOperation> Title { get; init; }
}

/// <inheritdoc />
public partial class CreateDatabase : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        static Columns BuildColumns(ColumnsBuilder columnsBuilder) => new()
        {
            Title = columnsBuilder.Column<string>("nvarchar(450)", nullable: false)
        };

        static void ApplyConstraints(CreateTableBuilder<Columns> tableBuilder) => tableBuilder.PrimaryKey("PK_OperatingSystems", columns => columns.Title);

        migrationBuilder.CreateTable("OperatingSystems", BuildColumns, constraints: ApplyConstraints);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder) => migrationBuilder.DropTable("OperatingSystems");
}
