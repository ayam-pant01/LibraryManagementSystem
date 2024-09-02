using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class bookcategorydataseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3167fd11-1b83-4043-8f00-d12984f6f9a7", null, "Librarian", "LIBRARIAN" },
                    { "ba7b1c19-82d3-4c81-ace7-56b17c591292", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Tools" },
                    { 2, "Baby" },
                    { 3, "Grocery" },
                    { 4, "Grocery" },
                    { 5, "Outdoors" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CategoryId", "CoverImage", "Description", "ISBN", "IsAvailable", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Queen Rogahn", 2, "https://picsum.photos/640/480/?image=140", "Ut tenetur ipsam architecto commodi et. Delectus atque quia qui. Cumque fugiat nisi quibusdam a placeat omnis maxime aliquid labore. Aut sit natus consequatur animi magnam expedita dolorem nostrum.", "9350118348800", true, 374, new DateTime(2018, 8, 13, 23, 54, 50, 388, DateTimeKind.Local).AddTicks(3690), "Goldner Group", "Small Cotton Car" },
                    { 2, "Briana Boehm", 1, "https://picsum.photos/640/480/?image=577", "Odio atque enim labore sunt nostrum minima. Id omnis voluptas non natus molestias animi deserunt rerum. Qui tenetur laudantium rem fugit recusandae accusantium non sint. Alias recusandae qui illo id.", "2104547867664", true, 692, new DateTime(2015, 5, 11, 13, 55, 53, 809, DateTimeKind.Local).AddTicks(432), "Bruen - Mills", "Refined Cotton Ball" },
                    { 3, "Shayna Ondricka", 2, "https://picsum.photos/640/480/?image=223", "Placeat et quia sint repellendus incidunt. Odit rem temporibus eaque. Voluptates velit incidunt commodi ut minima ut.", "5870284705275", true, 205, new DateTime(2016, 3, 27, 5, 6, 11, 322, DateTimeKind.Local).AddTicks(6683), "Dare, Leffler and Crona", "Handcrafted Soft Soap" },
                    { 4, "Alivia Berge", 1, "https://picsum.photos/640/480/?image=872", "Vel et officiis ab commodi dolores tenetur quisquam ut. Eligendi consequatur fuga cupiditate quibusdam vero. Fugiat totam omnis quidem voluptatibus et vel. Dolor voluptatum at animi.", "2339462428304", true, 147, new DateTime(2016, 8, 10, 22, 55, 16, 282, DateTimeKind.Local).AddTicks(6901), "West - Kirlin", "Incredible Fresh Shoes" },
                    { 5, "Sabina Hackett", 5, "https://picsum.photos/640/480/?image=352", "Qui consequatur in quibusdam ab. Consequatur earum aperiam sint dolore facilis sit adipisci quos. Illum non quia non enim eveniet. Fugit eaque ducimus dolores nobis qui molestiae et quia. Modi fugiat facilis consectetur non mollitia consequatur saepe veritatis rerum.", "6273916832391", true, 873, new DateTime(2015, 10, 13, 1, 46, 0, 141, DateTimeKind.Local).AddTicks(8910), "Pfeffer and Sons", "Fantastic Plastic Gloves" },
                    { 6, "Destini Pfeffer", 3, "https://picsum.photos/640/480/?image=805", "Ratione odio assumenda cumque provident id sint temporibus. Et ratione ea enim. Nihil et unde eveniet rerum distinctio enim.", "4033777687828", true, 937, new DateTime(2022, 11, 15, 0, 34, 56, 461, DateTimeKind.Local).AddTicks(6070), "Zemlak - O'Conner", "Sleek Plastic Table" },
                    { 7, "Alexie Goldner", 1, "https://picsum.photos/640/480/?image=484", "Quae vitae est repellendus cupiditate laboriosam aliquam quod. Sit labore praesentium. Odio dolorem tempora aut fuga repellat. Reprehenderit in omnis dicta placeat suscipit maxime. Autem vel et. Enim dolorem laborum quibusdam necessitatibus possimus.", "7194093216011", true, 183, new DateTime(2016, 5, 5, 3, 24, 17, 438, DateTimeKind.Local).AddTicks(3938), "Fadel - Kuhic", "Handmade Plastic Hat" },
                    { 8, "Glen Cassin", 5, "https://picsum.photos/640/480/?image=247", "Sed qui minima rerum molestiae. Dolorem vel voluptatem vitae quia. Ullam doloremque ut magni odit ad laborum rem sunt.", "1216253695514", true, 887, new DateTime(2017, 9, 13, 14, 4, 30, 101, DateTimeKind.Local).AddTicks(7315), "Larkin - Conroy", "Practical Plastic Fish" },
                    { 9, "Megane Hartmann", 5, "https://picsum.photos/640/480/?image=960", "Tenetur consequuntur itaque eaque repellendus rerum eius autem neque ad. Perferendis adipisci sed sit assumenda adipisci. Quidem culpa facere et cupiditate deserunt alias debitis sed. Quae nobis aut iste doloremque. Sapiente voluptatem illum sunt voluptate sed odit sint. Quia quia temporibus eligendi.", "3282773840510", true, 994, new DateTime(2014, 10, 11, 3, 11, 50, 507, DateTimeKind.Local).AddTicks(3069), "Smitham and Sons", "Gorgeous Soft Computer" },
                    { 10, "Khalil Nolan", 2, "https://picsum.photos/640/480/?image=722", "Natus ut sint ut delectus debitis. Eos nisi earum eveniet eum. In accusamus aut magnam fuga laudantium nihil. Veritatis quasi similique porro exercitationem illo quaerat officia. Rerum est consectetur quia et dicta rerum quas. Veritatis ut atque aut dolore porro culpa illum.", "2067764841292", true, 600, new DateTime(2019, 12, 30, 0, 40, 37, 940, DateTimeKind.Local).AddTicks(4281), "White and Sons", "Ergonomic Cotton Gloves" },
                    { 11, "Christelle Wolff", 1, "https://picsum.photos/640/480/?image=445", "Et ea et blanditiis sunt praesentium. Dolorem non nesciunt dolores labore ab. Quam vel in sed recusandae. Itaque nostrum rerum sunt culpa consectetur. Et ad modi eius optio.", "0131498142504", true, 755, new DateTime(2024, 4, 9, 23, 36, 17, 69, DateTimeKind.Local).AddTicks(6235), "Langworth - Marquardt", "Unbranded Plastic Pants" },
                    { 12, "Ayla Mayert", 4, "https://picsum.photos/640/480/?image=1053", "Voluptas ipsum et consequatur sit laudantium. Consequuntur atque unde aperiam minima aut veniam corporis earum. Consequatur tenetur perspiciatis vel dolores. Neque ducimus debitis excepturi corrupti dolor quaerat quae dolorem. Iste adipisci beatae quia modi sed eligendi repellendus.", "8415390821401", true, 510, new DateTime(2015, 8, 15, 18, 37, 21, 2, DateTimeKind.Local).AddTicks(9900), "Corwin, Lynch and Morissette", "Sleek Fresh Hat" },
                    { 13, "Tony Hamill", 5, "https://picsum.photos/640/480/?image=733", "Consequuntur nisi recusandae quasi iure. Cupiditate vitae velit sint et ea tenetur qui a hic. Ad maxime praesentium.", "0284972056337", true, 763, new DateTime(2024, 4, 18, 5, 59, 27, 909, DateTimeKind.Local).AddTicks(6290), "Becker and Sons", "Handmade Fresh Table" },
                    { 14, "Santiago Wilderman", 4, "https://picsum.photos/640/480/?image=373", "Sed voluptas animi magni aut. Dolorum aliquid molestiae. Beatae totam aperiam. Tempore voluptas rerum ut quo quae. Cupiditate alias ullam. Veritatis cupiditate voluptatum aut eos blanditiis velit nulla.", "4207650657608", true, 323, new DateTime(2023, 1, 26, 16, 3, 59, 268, DateTimeKind.Local).AddTicks(294), "Carter, Kuvalis and Homenick", "Generic Metal Soap" },
                    { 15, "Kelsie Morissette", 1, "https://picsum.photos/640/480/?image=548", "In eligendi consequatur minus aspernatur illum praesentium maiores omnis quisquam. Iste esse excepturi sint suscipit. Debitis illo rem possimus voluptas enim et est sit rerum. Quam corporis voluptatem beatae aut quibusdam. In et sed aut.", "0651729368195", true, 364, new DateTime(2024, 6, 18, 11, 56, 27, 69, DateTimeKind.Local).AddTicks(5586), "Heidenreich, Flatley and Dickinson", "Licensed Soft Sausages" },
                    { 16, "Julian Mueller", 5, "https://picsum.photos/640/480/?image=850", "Veniam asperiores ipsum eos provident aliquam quo. Aut eos sequi omnis quia. Natus id voluptatum. Non suscipit porro.", "8383304368307", true, 330, new DateTime(2019, 11, 21, 22, 23, 54, 924, DateTimeKind.Local).AddTicks(8134), "Douglas - Gerhold", "Small Fresh Shoes" },
                    { 17, "Corbin Mohr", 1, "https://picsum.photos/640/480/?image=575", "Alias voluptas voluptatem eveniet quasi temporibus incidunt qui ipsam. Tempore perspiciatis ad quaerat excepturi dolor vero ipsa voluptates. Facere aut fuga inventore sed nesciunt.", "2375632473477", true, 120, new DateTime(2022, 12, 12, 22, 29, 54, 658, DateTimeKind.Local).AddTicks(9171), "Gerhold - Ruecker", "Tasty Rubber Chicken" },
                    { 18, "Christelle Dietrich", 2, "https://picsum.photos/640/480/?image=945", "Sit consectetur sequi tempora et et delectus. Et reiciendis architecto. Molestias placeat praesentium et ex qui rerum rerum rem. Ab voluptatem quia est porro dolores. Culpa nam molestiae harum dolores eaque delectus.", "7818129859842", true, 848, new DateTime(2017, 7, 24, 1, 33, 42, 598, DateTimeKind.Local).AddTicks(144), "Schumm, Stokes and Schmeler", "Licensed Plastic Chicken" },
                    { 19, "Sam Weimann", 1, "https://picsum.photos/640/480/?image=55", "Facilis voluptas et. Occaecati quia placeat nesciunt ducimus sed quam quaerat vel. Tenetur expedita neque nihil.", "4476011315420", true, 264, new DateTime(2022, 5, 14, 12, 20, 19, 320, DateTimeKind.Local).AddTicks(6991), "Christiansen - Dickinson", "Ergonomic Soft Table" },
                    { 20, "Arielle Bins", 5, "https://picsum.photos/640/480/?image=32", "Corrupti nam sapiente dolores. Laboriosam ullam dolorum qui voluptas sit. Minus et illo quo voluptas ad assumenda quo. Magni cum laudantium et. Occaecati atque sint tenetur suscipit id aut eos. Aut eligendi sit libero in aspernatur est.", "8572156043672", true, 595, new DateTime(2017, 3, 17, 4, 42, 7, 935, DateTimeKind.Local).AddTicks(1967), "Johnston, Lemke and Weimann", "Practical Steel Mouse" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_ISBN",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3167fd11-1b83-4043-8f00-d12984f6f9a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba7b1c19-82d3-4c81-ace7-56b17c591292");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Books");
        }
    }
}
