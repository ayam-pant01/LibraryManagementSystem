using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedcheckoutdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Books_BookId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_BookId",
                table: "Checkouts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "664ac092-f0f8-4e8f-96a2-14a3eaf7e99b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2656152-deb0-4622-9bfe-38c29b86ddb4");

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
                name: "BookId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Checkouts");

            migrationBuilder.CreateTable(
                name: "CheckoutDetails",
                columns: table => new
                {
                    CheckoutDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckoutId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutDetails", x => x.CheckoutDetailId);
                    table.ForeignKey(
                        name: "FK_CheckoutDetails_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutDetails_Checkouts_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkouts",
                        principalColumn: "CheckoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutDetails_BookId",
                table: "CheckoutDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutDetails_CheckoutId",
                table: "CheckoutDetails",
                column: "CheckoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutDetails");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Checkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Checkouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "664ac092-f0f8-4e8f-96a2-14a3eaf7e99b", null, "Librarian", "LIBRARIAN" },
                    { "a2656152-deb0-4622-9bfe-38c29b86ddb4", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Outdoors" },
                    { 2, "Beauty" },
                    { 3, "Clothing" },
                    { 4, "Home" },
                    { 5, "Industrial" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CategoryId", "CoverImage", "Description", "ISBN", "IsAvailable", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Bethel Hoppe", 2, "https://picsum.photos/640/480/?image=720", "Aliquid nemo ad beatae labore at dignissimos eius consequatur. Quis minima voluptatum voluptates. Impedit ducimus dolorum beatae mollitia in. Eaque ullam nihil mollitia in. Itaque vel et similique et facere aliquid. Culpa odit qui.", "2145553863868", true, 396, new DateTime(2024, 8, 27, 17, 39, 18, 369, DateTimeKind.Local).AddTicks(1520), "Barrows and Sons", "Handmade Rubber Gloves" },
                    { 2, "Theron Vandervort", 1, "https://picsum.photos/640/480/?image=777", "Commodi eveniet dolorem qui non consequuntur ad expedita repellat porro. Repellat maiores minus sit. Labore aperiam error corporis qui quia. Unde cumque velit non.", "4574309328913", true, 978, new DateTime(2016, 2, 12, 6, 5, 40, 390, DateTimeKind.Local).AddTicks(5883), "Kulas Inc", "Rustic Frozen Chair" },
                    { 3, "Jaquan Hackett", 3, "https://picsum.photos/640/480/?image=363", "Quae at esse et veniam vel amet laboriosam voluptas maiores. Eveniet quod vero aut perferendis quasi minima deleniti. Qui quo dolorem qui quo voluptate dolore alias.", "5789810487335", true, 840, new DateTime(2016, 4, 12, 8, 26, 18, 398, DateTimeKind.Local).AddTicks(2121), "Langosh - Reynolds", "Handcrafted Concrete Cheese" },
                    { 4, "Carol Gutkowski", 4, "https://picsum.photos/640/480/?image=498", "Dolorem voluptatum voluptate. Voluptates explicabo optio mollitia occaecati. Vel facere cupiditate perspiciatis quis voluptas ad aut.", "5730864913059", true, 496, new DateTime(2020, 3, 6, 8, 38, 7, 947, DateTimeKind.Local).AddTicks(2531), "Kertzmann Group", "Gorgeous Steel Cheese" },
                    { 5, "Blaze Bartell", 3, "https://picsum.photos/640/480/?image=983", "Alias et saepe vero quaerat rerum quidem recusandae. At dolorem veritatis. Et quia autem dolores. Aspernatur vel repellendus est minima voluptate. Veniam fugit rerum architecto perferendis perspiciatis itaque velit rerum recusandae.", "2970585096089", true, 533, new DateTime(2021, 6, 21, 6, 5, 22, 884, DateTimeKind.Local).AddTicks(2885), "Parisian - Grant", "Refined Concrete Chicken" },
                    { 6, "Arnold King", 1, "https://picsum.photos/640/480/?image=906", "Dignissimos distinctio minima nisi. Quaerat voluptatem aut consectetur voluptate saepe numquam nisi sed non. Omnis ad dolores at.", "4050797655651", true, 187, new DateTime(2015, 5, 25, 22, 34, 31, 53, DateTimeKind.Local).AddTicks(4620), "Rodriguez, Lakin and Lubowitz", "Ergonomic Rubber Tuna" },
                    { 7, "Myrtis Kulas", 3, "https://picsum.photos/640/480/?image=318", "Aut sequi qui quod officiis ab beatae. Incidunt consequuntur rem delectus recusandae itaque ducimus. Omnis impedit nesciunt possimus occaecati. Qui ut voluptatem voluptatem eum aut voluptatum saepe sequi sit. Accusantium sed rerum consectetur aut occaecati voluptas qui ipsa.", "8971316743962", true, 718, new DateTime(2016, 5, 30, 0, 23, 11, 71, DateTimeKind.Local).AddTicks(4974), "McDermott, Wintheiser and Witting", "Refined Metal Ball" },
                    { 8, "Luciano Hoeger", 3, "https://picsum.photos/640/480/?image=815", "Magni sunt atque. Fuga voluptas non sint praesentium nesciunt aperiam exercitationem. Quae officia ducimus sint molestiae atque quaerat similique inventore neque. Consectetur quos neque in. Natus voluptatum qui aspernatur accusamus repudiandae sit ex.", "6338989967576", true, 230, new DateTime(2016, 6, 25, 7, 15, 39, 563, DateTimeKind.Local).AddTicks(642), "Ryan, Jacobs and DuBuque", "Fantastic Cotton Salad" },
                    { 9, "Stella Cremin", 5, "https://picsum.photos/640/480/?image=364", "At architecto nemo rerum est fuga eligendi. Natus eum sit. Ex voluptatem sunt illum. Et vel vel dolores. Magni est dicta. Tempore esse blanditiis porro et quos repudiandae quis.", "6666371679128", true, 176, new DateTime(2021, 3, 20, 18, 42, 16, 25, DateTimeKind.Local).AddTicks(4674), "Rosenbaum Inc", "Handmade Cotton Mouse" },
                    { 10, "Kay Zemlak", 3, "https://picsum.photos/640/480/?image=494", "Recusandae similique qui quam. Et commodi dolor voluptatem molestias. Enim laboriosam eaque necessitatibus temporibus et voluptas repellendus eligendi. Earum et voluptate quia temporibus eveniet aliquid. Animi laboriosam eum eaque et. Eos et neque id porro aut.", "8093810520914", true, 799, new DateTime(2024, 5, 23, 14, 26, 26, 787, DateTimeKind.Local).AddTicks(1839), "Batz, Jaskolski and Herman", "Unbranded Frozen Chips" },
                    { 11, "Haskell Schoen", 4, "https://picsum.photos/640/480/?image=686", "Cumque itaque in cupiditate. Autem eveniet omnis deleniti quo necessitatibus et illum nobis. Molestiae facere magni ullam dignissimos maiores sed molestias quam quia. Non incidunt molestias ut.", "7968238024690", true, 884, new DateTime(2015, 4, 28, 2, 57, 57, 704, DateTimeKind.Local).AddTicks(1891), "Shanahan - Mueller", "Incredible Plastic Bike" },
                    { 12, "Martina Streich", 5, "https://picsum.photos/640/480/?image=791", "Culpa repellat magni quia sit aut quisquam vero. Consequatur sit fuga aut. Ea et sint atque dolorem. Ex est pariatur est voluptas ea velit. Fugit inventore exercitationem et magnam molestiae optio quia.", "5700877211343", true, 803, new DateTime(2023, 2, 21, 1, 33, 25, 898, DateTimeKind.Local).AddTicks(6580), "Maggio Inc", "Handcrafted Plastic Chicken" },
                    { 13, "Magdalena Schimmel", 3, "https://picsum.photos/640/480/?image=422", "Illum aut eos est fugit occaecati vitae fugit et quia. Soluta tempora nihil velit ipsa consectetur nulla laudantium recusandae. Reprehenderit laboriosam est tempora. Tenetur eligendi saepe quasi sint. Voluptatibus saepe officia autem doloribus aliquam earum tenetur rem. Omnis quo nihil harum qui autem ipsum.", "1064706314822", true, 310, new DateTime(2016, 6, 2, 11, 28, 48, 235, DateTimeKind.Local).AddTicks(807), "Lind, Kautzer and Reilly", "Rustic Steel Shoes" },
                    { 14, "Ryan Kuphal", 4, "https://picsum.photos/640/480/?image=292", "Sunt ad est dolores inventore occaecati veritatis quia. Eveniet odit mollitia blanditiis voluptas qui harum cupiditate. Et voluptates ex delectus qui nihil aperiam sed qui. Tenetur velit voluptas. Est sint et.", "9649416339154", true, 545, new DateTime(2015, 8, 3, 6, 57, 47, 557, DateTimeKind.Local).AddTicks(9765), "Maggio, Rath and Rogahn", "Handcrafted Frozen Table" },
                    { 15, "Lily Legros", 4, "https://picsum.photos/640/480/?image=380", "Exercitationem porro et eius odit. Quia sit autem alias. Quam mollitia minus. Ut repellat vitae odio sed asperiores quibusdam iure dolor fugit. Voluptate est sapiente ut voluptas doloribus provident numquam fugit.", "2186383723052", true, 418, new DateTime(2023, 6, 15, 15, 1, 3, 209, DateTimeKind.Local).AddTicks(5130), "Bechtelar, Berge and Bode", "Incredible Wooden Pizza" },
                    { 16, "Amira Lang", 4, "https://picsum.photos/640/480/?image=468", "Illum est a et itaque sit numquam voluptatibus voluptatum repellendus. Quia delectus quas nihil. Aperiam et a. Tempore delectus non facilis animi. Tenetur quibusdam sed minus atque. Consequatur doloremque facere ad enim hic molestiae praesentium.", "2997044743407", true, 127, new DateTime(2015, 4, 30, 2, 57, 43, 864, DateTimeKind.Local).AddTicks(3405), "Senger - Jakubowski", "Tasty Cotton Computer" },
                    { 17, "Juliet Runolfsson", 5, "https://picsum.photos/640/480/?image=267", "Quod et sapiente voluptates itaque quas eos sapiente omnis non. Eaque aliquid dolorem nesciunt est in officia alias eveniet delectus. Ullam dignissimos quibusdam veritatis aut. Neque nesciunt qui commodi alias maiores. Et deserunt accusantium consequatur.", "9920124488014", true, 567, new DateTime(2019, 4, 20, 1, 12, 10, 157, DateTimeKind.Local).AddTicks(5289), "Koepp LLC", "Gorgeous Steel Ball" },
                    { 18, "Braden Hyatt", 4, "https://picsum.photos/640/480/?image=298", "Iure voluptas aliquam sapiente. Autem hic repellendus aut voluptate cum ipsa nulla dolores soluta. Veniam vel dolores. Provident quis dolorem natus accusamus quis et recusandae eum corrupti. Non dolores qui rerum molestias illo natus dolores qui. Esse temporibus corporis dignissimos possimus at.", "4486832404814", true, 302, new DateTime(2017, 9, 19, 12, 3, 40, 565, DateTimeKind.Local).AddTicks(4928), "Schneider and Sons", "Fantastic Soft Tuna" },
                    { 19, "Kaylin Harber", 4, "https://picsum.photos/640/480/?image=281", "Tenetur aut ipsum. Et dolorem quo at eos ut. Laborum illum ullam sequi. Possimus mollitia voluptatem quod quibusdam sunt. Deserunt quisquam labore nam reprehenderit impedit repellendus et iusto. Nisi et nisi quo vel voluptatem quae.", "5648445294780", true, 928, new DateTime(2019, 5, 13, 18, 7, 26, 428, DateTimeKind.Local).AddTicks(5717), "Schamberger, Jacobson and Koepp", "Handcrafted Cotton Chicken" },
                    { 20, "Kayli Keebler", 4, "https://picsum.photos/640/480/?image=441", "Suscipit tempore ut quae commodi non in quisquam voluptatem. Sit autem et aut vero omnis dicta maiores. Facere aliquam nostrum velit officia. Qui dolore numquam aut in architecto. Quia fugiat quia cum.", "8814306288626", true, 881, new DateTime(2018, 5, 13, 0, 30, 1, 831, DateTimeKind.Local).AddTicks(4907), "Bechtelar Inc", "Small Wooden Bike" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_BookId",
                table: "Checkouts",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Books_BookId",
                table: "Checkouts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
