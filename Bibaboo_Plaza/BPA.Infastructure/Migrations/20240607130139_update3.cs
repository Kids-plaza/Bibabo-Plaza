using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPA.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BPA");

            migrationBuilder.RenameTable(
                name: "Type",
                schema: "bpa",
                newName: "Type",
                newSchema: "BPA");

            migrationBuilder.RenameTable(
                name: "Report",
                schema: "bpa",
                newName: "Report",
                newSchema: "BPA");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "bpa",
                newName: "Product",
                newSchema: "BPA");

            migrationBuilder.RenameTable(
                name: "Post",
                schema: "bpa",
                newName: "Post",
                newSchema: "BPA");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                schema: "bpa",
                newName: "OrderDetail",
                newSchema: "BPA");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "bpa",
                newName: "Order",
                newSchema: "BPA");

            migrationBuilder.RenameTable(
                name: "Feedback",
                schema: "bpa",
                newName: "Feedback",
                newSchema: "BPA");

            migrationBuilder.RenameTable(
                name: "Brand",
                schema: "bpa",
                newName: "Brand",
                newSchema: "BPA");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "bpa",
                newName: "Account",
                newSchema: "BPA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bpa");

            migrationBuilder.RenameTable(
                name: "Type",
                schema: "BPA",
                newName: "Type",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Report",
                schema: "BPA",
                newName: "Report",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "BPA",
                newName: "Product",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Post",
                schema: "BPA",
                newName: "Post",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                schema: "BPA",
                newName: "OrderDetail",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "BPA",
                newName: "Order",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Feedback",
                schema: "BPA",
                newName: "Feedback",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Brand",
                schema: "BPA",
                newName: "Brand",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "BPA",
                newName: "Account",
                newSchema: "bpa");
        }
    }
}
