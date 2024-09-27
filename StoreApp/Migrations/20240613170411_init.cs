using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    productId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productName = table.Column<string>(type: "TEXT", nullable: false),
                    productPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    categoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    summary = table.Column<string>(type: "TEXT", nullable: true),
                    imageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.productId);
                    table.ForeignKey(
                        name: "FK_product_category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "categoryId");
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 1, "Adidas" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 2, "Nike" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productId", "categoryId", "imageUrl", "productName", "productPrice", "summary" },
                values: new object[] { 1, 2, " /images/1.jpg", "Airforce Beyaz", 17000m, "" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productId", "categoryId", "imageUrl", "productName", "productPrice", "summary" },
                values: new object[] { 2, 2, "/images/2.jpg", "Airforce Beyaz Siyah", 10000m, "" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productId", "categoryId", "imageUrl", "productName", "productPrice", "summary" },
                values: new object[] { 3, 2, "/images/3.jpg", "Airforce Pudra", 20000m, "" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productId", "categoryId", "imageUrl", "productName", "productPrice", "summary" },
                values: new object[] { 4, 2, "/images/4.jpg", "Airforce Siyah", 15000m, "" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productId", "categoryId", "imageUrl", "productName", "productPrice", "summary" },
                values: new object[] { 5, 2, "/images/5.jpg", "Airforce Sİyah Beyaz", 16000m, "" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productId", "categoryId", "imageUrl", "productName", "productPrice", "summary" },
                values: new object[] { 6, 1, "/images/6.jpg", "Adidas Run", 18000m, "" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productId", "categoryId", "imageUrl", "productName", "productPrice", "summary" },
                values: new object[] { 7, 1, "/images/7.jpg", "Adidas Samba", 18000m, "" });

            migrationBuilder.CreateIndex(
                name: "IX_product_categoryId",
                table: "product",
                column: "categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
