using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPA.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Account_account_id",
                schema: "BPA",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Account_account_id",
                schema: "BPA",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_type_id",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Account_account_id",
                schema: "BPA",
                table: "Report");

            migrationBuilder.DropIndex(
                name: "IX_Product_brand_id",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_type_id",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "BPA",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "BPA",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "BPA",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "BPA",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "BPA",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "BPA",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "type_id",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "BPA",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "BPA",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "BPA",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "BPA",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "BPA",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "BPA",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "BPA",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "BPA",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "BPA",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "BPA",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "BPA",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "BPA",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "BPA",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "image_url",
                schema: "BPA",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "BPA",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "BPA",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "BPA",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "image_url",
                schema: "BPA",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "BPA",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "BPA",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "username",
                schema: "BPA",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "account_id",
                schema: "BPA",
                table: "Report",
                newName: "staff_id");

            migrationBuilder.RenameIndex(
                name: "IX_Report_account_id",
                schema: "BPA",
                table: "Report",
                newName: "IX_Report_staff_id");

            migrationBuilder.RenameColumn(
                name: "account_id",
                schema: "BPA",
                table: "Post",
                newName: "staff_id");

            migrationBuilder.RenameIndex(
                name: "IX_Post_account_id",
                schema: "BPA",
                table: "Post",
                newName: "IX_Post_staff_id");

            migrationBuilder.RenameColumn(
                name: "account_id",
                schema: "BPA",
                table: "Order",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_account_id",
                schema: "BPA",
                table: "Order",
                newName: "IX_Order_customer_id");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductTypeId",
                schema: "BPA",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_brand_id",
                schema: "BPA",
                table: "Product",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                schema: "BPA",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Account_customer_id",
                schema: "BPA",
                table: "Order",
                column: "customer_id",
                principalSchema: "BPA",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Account_staff_id",
                schema: "BPA",
                table: "Post",
                column: "staff_id",
                principalSchema: "BPA",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_ProductTypeId",
                schema: "BPA",
                table: "Product",
                column: "ProductTypeId",
                principalSchema: "BPA",
                principalTable: "Type",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Account_staff_id",
                schema: "BPA",
                table: "Report",
                column: "staff_id",
                principalSchema: "BPA",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Account_customer_id",
                schema: "BPA",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Account_staff_id",
                schema: "BPA",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_ProductTypeId",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Account_staff_id",
                schema: "BPA",
                table: "Report");

            migrationBuilder.DropIndex(
                name: "IX_Product_brand_id",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductTypeId",
                schema: "BPA",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                schema: "BPA",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "staff_id",
                schema: "BPA",
                table: "Report",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Report_staff_id",
                schema: "BPA",
                table: "Report",
                newName: "IX_Report_account_id");

            migrationBuilder.RenameColumn(
                name: "staff_id",
                schema: "BPA",
                table: "Post",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Post_staff_id",
                schema: "BPA",
                table: "Post",
                newName: "IX_Post_account_id");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                schema: "BPA",
                table: "Order",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_customer_id",
                schema: "BPA",
                table: "Order",
                newName: "IX_Order_account_id");

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "BPA",
                table: "Type",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "BPA",
                table: "Type",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "BPA",
                table: "Type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "BPA",
                table: "Report",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "BPA",
                table: "Report",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "BPA",
                table: "Report",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "BPA",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "type_id",
                schema: "BPA",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "BPA",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "BPA",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "BPA",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "BPA",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "BPA",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "BPA",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "BPA",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "BPA",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "BPA",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "BPA",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "BPA",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "BPA",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "BPA",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "BPA",
                table: "Feedback",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "BPA",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                schema: "BPA",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "BPA",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "BPA",
                table: "Brand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "BPA",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                schema: "BPA",
                table: "Account",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "BPA",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "BPA",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "username",
                schema: "BPA",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Product_brand_id",
                schema: "BPA",
                table: "Product",
                column: "brand_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_type_id",
                schema: "BPA",
                table: "Product",
                column: "type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Account_account_id",
                schema: "BPA",
                table: "Order",
                column: "account_id",
                principalSchema: "BPA",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Account_account_id",
                schema: "BPA",
                table: "Post",
                column: "account_id",
                principalSchema: "BPA",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_type_id",
                schema: "BPA",
                table: "Product",
                column: "type_id",
                principalSchema: "BPA",
                principalTable: "Type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Account_account_id",
                schema: "BPA",
                table: "Report",
                column: "account_id",
                principalSchema: "BPA",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
