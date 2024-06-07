using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPA.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_post_account_account_id",
                schema: "bpa",
                table: "post");

            migrationBuilder.DropForeignKey(
                name: "FK_product_brand_brand_id",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_type_type_id",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_account_account_id",
                schema: "bpa",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_type",
                schema: "bpa",
                table: "type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                schema: "bpa",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post",
                schema: "bpa",
                table: "post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brand",
                schema: "bpa",
                table: "brand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_account",
                schema: "bpa",
                table: "account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                schema: "bpa",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                schema: "bpa",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                schema: "bpa",
                table: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "type",
                schema: "bpa",
                newName: "Type",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "product",
                schema: "bpa",
                newName: "Product",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "post",
                schema: "bpa",
                newName: "Post",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "brand",
                schema: "bpa",
                newName: "Brand",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "account",
                schema: "bpa",
                newName: "Account",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Reports",
                schema: "bpa",
                newName: "Report",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                schema: "bpa",
                newName: "OrderDetail",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                schema: "bpa",
                newName: "Feedback",
                newSchema: "bpa");

            migrationBuilder.RenameIndex(
                name: "IX_product_type_id",
                schema: "bpa",
                table: "Product",
                newName: "IX_Product_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_brand_id",
                schema: "bpa",
                table: "Product",
                newName: "IX_Product_brand_id");

            migrationBuilder.RenameIndex(
                name: "IX_post_account_id",
                schema: "bpa",
                table: "Post",
                newName: "IX_Post_account_id");

            migrationBuilder.RenameColumn(
                name: "Content",
                schema: "bpa",
                table: "Report",
                newName: "content");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_account_id",
                schema: "bpa",
                table: "Report",
                newName: "IX_Report_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_product_id",
                schema: "bpa",
                table: "OrderDetail",
                newName: "IX_OrderDetail_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_order",
                schema: "bpa",
                table: "OrderDetail",
                newName: "IX_OrderDetail_order");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_product_id",
                schema: "bpa",
                table: "Feedback",
                newName: "IX_Feedback_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_account_id",
                schema: "bpa",
                table: "Feedback",
                newName: "IX_Feedback_account_id");

            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                schema: "bpa",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                schema: "bpa",
                table: "Type",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                schema: "bpa",
                table: "Product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                schema: "bpa",
                table: "Post",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                schema: "bpa",
                table: "Brand",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                schema: "bpa",
                table: "Account",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                schema: "bpa",
                table: "Report",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                schema: "bpa",
                table: "OrderDetail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                schema: "bpa",
                table: "Feedback",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Account_account_id",
                schema: "bpa",
                table: "Feedback",
                column: "account_id",
                principalSchema: "bpa",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Product_product_id",
                schema: "bpa",
                table: "Feedback",
                column: "product_id",
                principalSchema: "bpa",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Account_account_id",
                schema: "bpa",
                table: "Order",
                column: "account_id",
                principalSchema: "bpa",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_order",
                schema: "bpa",
                table: "OrderDetail",
                column: "order",
                principalSchema: "bpa",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_product_id",
                schema: "bpa",
                table: "OrderDetail",
                column: "product_id",
                principalSchema: "bpa",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Account_account_id",
                schema: "bpa",
                table: "Post",
                column: "account_id",
                principalSchema: "bpa",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_brand_id",
                schema: "bpa",
                table: "Product",
                column: "brand_id",
                principalSchema: "bpa",
                principalTable: "Brand",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_type_id",
                schema: "bpa",
                table: "Product",
                column: "type_id",
                principalSchema: "bpa",
                principalTable: "Type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Account_account_id",
                schema: "bpa",
                table: "Report",
                column: "account_id",
                principalSchema: "bpa",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Account_account_id",
                schema: "bpa",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Product_product_id",
                schema: "bpa",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Account_account_id",
                schema: "bpa",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_order",
                schema: "bpa",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_product_id",
                schema: "bpa",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Account_account_id",
                schema: "bpa",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_brand_id",
                schema: "bpa",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_type_id",
                schema: "bpa",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Account_account_id",
                schema: "bpa",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                schema: "bpa",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                schema: "bpa",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                schema: "bpa",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                schema: "bpa",
                table: "Brand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                schema: "bpa",
                table: "Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                schema: "bpa",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                schema: "bpa",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                schema: "bpa",
                table: "Feedback");

            migrationBuilder.RenameTable(
                name: "Type",
                schema: "bpa",
                newName: "type",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "bpa",
                newName: "product",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Post",
                schema: "bpa",
                newName: "post",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Brand",
                schema: "bpa",
                newName: "brand",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "bpa",
                newName: "account",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Report",
                schema: "bpa",
                newName: "Reports",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                schema: "bpa",
                newName: "OrderDetails",
                newSchema: "bpa");

            migrationBuilder.RenameTable(
                name: "Feedback",
                schema: "bpa",
                newName: "Feedbacks",
                newSchema: "bpa");

            migrationBuilder.RenameIndex(
                name: "IX_Product_type_id",
                schema: "bpa",
                table: "product",
                newName: "IX_product_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_brand_id",
                schema: "bpa",
                table: "product",
                newName: "IX_product_brand_id");

            migrationBuilder.RenameIndex(
                name: "IX_Post_account_id",
                schema: "bpa",
                table: "post",
                newName: "IX_post_account_id");

            migrationBuilder.RenameColumn(
                name: "content",
                schema: "bpa",
                table: "Reports",
                newName: "Content");

            migrationBuilder.RenameIndex(
                name: "IX_Report_account_id",
                schema: "bpa",
                table: "Reports",
                newName: "IX_Reports_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_product_id",
                schema: "bpa",
                table: "OrderDetails",
                newName: "IX_OrderDetails_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_order",
                schema: "bpa",
                table: "OrderDetails",
                newName: "IX_OrderDetails_order");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_product_id",
                schema: "bpa",
                table: "Feedbacks",
                newName: "IX_Feedbacks_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_account_id",
                schema: "bpa",
                table: "Feedbacks",
                newName: "IX_Feedbacks_account_id");

            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                schema: "bpa",
                table: "brand",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_type",
                schema: "bpa",
                table: "type",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                schema: "bpa",
                table: "product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post",
                schema: "bpa",
                table: "post",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brand",
                schema: "bpa",
                table: "brand",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_account",
                schema: "bpa",
                table: "account",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                schema: "bpa",
                table: "Reports",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                schema: "bpa",
                table: "OrderDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                schema: "bpa",
                table: "Feedbacks",
                column: "id");

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
                name: "FK_post_account_account_id",
                schema: "bpa",
                table: "post",
                column: "account_id",
                principalSchema: "bpa",
                principalTable: "account",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_account_account_id",
                schema: "bpa",
                table: "Reports",
                column: "account_id",
                principalSchema: "bpa",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
