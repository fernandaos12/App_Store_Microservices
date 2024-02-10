using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class TabelaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "TB_PRODUCT",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TB_PRODUCT",
                columns: new[] { "Id", "CATEGORY", "DESCRIPTION", "IMAGE_URL", "NAME", "PRICE", "SIZE" },
                values: new object[,]
                {
                    { 2L, "R-shirts", "Mario T-Shirt", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fboutiquemario.fr%2Fvetement%2Ftshirt%2Fsuper-mario-ds&psig=AOvVaw171sMWTgVHaUIhEiKndWLR&ust=1705000045534000&source=images&cd=vfe&ved=0CBIQjRxqFwoTCNjysqnC04MDFQAAAAAdAAAAABAE", "Mario T-Shirt", 69.900000000000006, "M" },
                    { 3L, "R-shirts", "Mario T-Shirt", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fboutiquemario.fr%2Fvetement%2Ftshirt%2Fsuper-mario-ds&psig=AOvVaw171sMWTgVHaUIhEiKndWLR&ust=1705000045534000&source=images&cd=vfe&ved=0CBIQjRxqFwoTCNjysqnC04MDFQAAAAAdAAAAABAE", "Turtle T-Shirt", 89.900000000000006, "G" },
                    { 4L, "R-shirts", "Mario T-Shirt", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fboutiquemario.fr%2Fvetement%2Ftshirt%2Fsuper-mario-ds&psig=AOvVaw171sMWTgVHaUIhEiKndWLR&ust=1705000045534000&source=images&cd=vfe&ved=0CBIQjRxqFwoTCNjysqnC04MDFQAAAAAdAAAAABAE", "Princesa T-Shirt", 99.900000000000006, "M" },
                    { 5L, "R-shirts", "Mario T-Shirt", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fboutiquemario.fr%2Fvetement%2Ftshirt%2Fsuper-mario-ds&psig=AOvVaw171sMWTgVHaUIhEiKndWLR&ust=1705000045534000&source=images&cd=vfe&ved=0CBIQjRxqFwoTCNjysqnC04MDFQAAAAAdAAAAABAE", "Luigi T-Shirt", 169.90000000000001, "GG" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_PRODUCT",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "TB_PRODUCT",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "TB_PRODUCT",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "TB_PRODUCT",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DropColumn(
                name: "NAME",
                table: "TB_PRODUCT");
        }
    }
}
