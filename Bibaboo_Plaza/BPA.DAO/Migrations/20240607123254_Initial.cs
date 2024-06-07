using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPA.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_Feedbacks_account",
                schema: "bpa",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "FK_product_Feedbacks_product",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_brand_brand",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_type_type",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropTable(
                name: "voucher",
                schema: "bpa");

            migrationBuilder.DropIndex(
                name: "IX_product_product",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_account_account",
                schema: "bpa",
                table: "account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                schema: "bpa",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "product",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropColumn(
                name: "account",
                schema: "bpa",
                table: "account");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "bpa",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "bpa",
                newName: "Order",
                newSchema: "bpa");

            migrationBuilder.RenameColumn(
                name: "type",
                schema: "bpa",
                table: "product",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "brand",
                schema: "bpa",
                table: "product",
                newName: "brand_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_type",
                schema: "bpa",
                table: "product",
                newName: "IX_product_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_brand",
                schema: "bpa",
                table: "product",
                newName: "IX_product_brand_id");

            migrationBuilder.RenameColumn(
                name: "Total",
                schema: "bpa",
                table: "OrderDetails",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "bpa",
                table: "OrderDetails",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "bpa",
                table: "OrderDetails",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "bpa",
                table: "OrderDetails",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                schema: "bpa",
                table: "OrderDetails",
                newName: "order");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "bpa",
                table: "Order",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "VoucherId",
                schema: "bpa",
                table: "Order",
                newName: "total");

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                schema: "bpa",
                table: "type",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "account_id",
                schema: "bpa",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                schema: "bpa",
                table: "Feedbacks",
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

            migrationBuilder.AddColumn<Guid>(
                name: "account_id",
                schema: "bpa",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                schema: "bpa",
                table: "Order",
                column: "id");

            migrationBuilder.CreateTable(
                name: "post",
                schema: "bpa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.id);
                    table.ForeignKey(
                        name: "FK_post_account_account_id",
                        column: x => x.account_id,
                        principalSchema: "bpa",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                schema: "bpa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reports_account_account_id",
                        column: x => x.account_id,
                        principalSchema: "bpa",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_order",
                schema: "bpa",
                table: "OrderDetails",
                column: "order");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_product_id",
                schema: "bpa",
                table: "OrderDetails",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_account_id",
                schema: "bpa",
                table: "Feedbacks",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_product_id",
                schema: "bpa",
                table: "Feedbacks",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_account_id",
                schema: "bpa",
                table: "Order",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_account_id",
                schema: "bpa",
                table: "post",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_account_id",
                schema: "bpa",
                table: "Reports",
                column: "account_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_account_account_id",
                schema: "bpa",
                table: "Feedbacks",
                column: "account_id",
                principalSchema: "bpa",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_product_product_id",
                schema: "bpa",
                table: "Feedbacks",
                column: "product_id",
                principalSchema: "bpa",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_account_account_id",
                schema: "bpa",
                table: "Order",
                column: "account_id",
                principalSchema: "bpa",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_order",
                schema: "bpa",
                table: "OrderDetails",
                column: "order",
                principalSchema: "bpa",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_product_product_id",
                schema: "bpa",
                table: "OrderDetails",
                column: "product_id",
                principalSchema: "bpa",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_account_account_id",
                schema: "bpa",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_product_product_id",
                schema: "bpa",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_account_account_id",
                schema: "bpa",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_order",
                schema: "bpa",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_product_product_id",
                schema: "bpa",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_product_brand_brand_id",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_type_type_id",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropTable(
                name: "post",
                schema: "bpa");

            migrationBuilder.DropTable(
                name: "Reports",
                schema: "bpa");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_order",
                schema: "bpa",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_product_id",
                schema: "bpa",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_account_id",
                schema: "bpa",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_product_id",
                schema: "bpa",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                schema: "bpa",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_account_id",
                schema: "bpa",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "product_id",
                schema: "bpa",
                table: "type");

            migrationBuilder.DropColumn(
                name: "account_id",
                schema: "bpa",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "product_id",
                schema: "bpa",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "product_id",
                schema: "bpa",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "account_id",
                schema: "bpa",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "bpa",
                newName: "Orders",
                newSchema: "bpa");

            migrationBuilder.RenameColumn(
                name: "type_id",
                schema: "bpa",
                table: "product",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                schema: "bpa",
                table: "product",
                newName: "brand");

            migrationBuilder.RenameIndex(
                name: "IX_product_type_id",
                schema: "bpa",
                table: "product",
                newName: "IX_product_type");

            migrationBuilder.RenameIndex(
                name: "IX_product_brand_id",
                schema: "bpa",
                table: "product",
                newName: "IX_product_brand");

            migrationBuilder.RenameColumn(
                name: "total",
                schema: "bpa",
                table: "OrderDetails",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "quantity",
                schema: "bpa",
                table: "OrderDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "bpa",
                table: "OrderDetails",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "product_id",
                schema: "bpa",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "order",
                schema: "bpa",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "bpa",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "total",
                schema: "bpa",
                table: "Orders",
                newName: "VoucherId");

            migrationBuilder.AddColumn<Guid>(
                name: "product",
                schema: "bpa",
                table: "product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "account",
                schema: "bpa",
                table: "account",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                schema: "bpa",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                schema: "bpa",
                table: "Orders",
                column: "id");

            migrationBuilder.CreateTable(
                name: "voucher",
                schema: "bpa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    exp_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valid_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    voucher_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    voucher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    voucher_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucher", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_product",
                schema: "bpa",
                table: "product",
                column: "product");

            migrationBuilder.CreateIndex(
                name: "IX_account_account",
                schema: "bpa",
                table: "account",
                column: "account");

            migrationBuilder.AddForeignKey(
                name: "FK_account_Feedbacks_account",
                schema: "bpa",
                table: "account",
                column: "account",
                principalSchema: "bpa",
                principalTable: "Feedbacks",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_Feedbacks_product",
                schema: "bpa",
                table: "product",
                column: "product",
                principalSchema: "bpa",
                principalTable: "Feedbacks",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_brand_brand",
                schema: "bpa",
                table: "product",
                column: "brand",
                principalSchema: "bpa",
                principalTable: "brand",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_type_type",
                schema: "bpa",
                table: "product",
                column: "type",
                principalSchema: "bpa",
                principalTable: "type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
