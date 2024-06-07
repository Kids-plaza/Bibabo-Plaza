using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPA.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_brand_brand_id",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_type_type_id",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_brand_id",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_type_id",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropColumn(
                name: "product_id",
                schema: "bpa",
                table: "type");

            migrationBuilder.DropColumn(
                name: "product_id",
                schema: "bpa",
                table: "brand");

            migrationBuilder.AddColumn<Guid>(
                name: "product",
                schema: "bpa",
                table: "product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_product_product",
                schema: "bpa",
                table: "product",
                column: "product");

            migrationBuilder.AddForeignKey(
                name: "FK_product_brand_product",
                schema: "bpa",
                table: "product",
                column: "product",
                principalSchema: "bpa",
                principalTable: "brand",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_type_product",
                schema: "bpa",
                table: "product",
                column: "product",
                principalSchema: "bpa",
                principalTable: "type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_brand_product",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_type_product",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_product",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropColumn(
                name: "product",
                schema: "bpa",
                table: "product");

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                schema: "bpa",
                table: "type",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                schema: "bpa",
                table: "brand",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_product_brand_id",
                schema: "bpa",
                table: "product",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_type_id",
                schema: "bpa",
                table: "product",
                column: "type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_brand_brand_id",
                schema: "bpa",
                table: "product",
                column: "brand_id",
                principalSchema: "bpa",
                principalTable: "brand",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_type_type_id",
                schema: "bpa",
                table: "product",
                column: "type_id",
                principalSchema: "bpa",
                principalTable: "type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
