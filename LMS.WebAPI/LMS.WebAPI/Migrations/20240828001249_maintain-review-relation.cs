using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class maintainreviewrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3167fd11-1b83-4043-8f00-d12984f6f9a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba7b1c19-82d3-4c81-ace7-56b17c591292");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "664ac092-f0f8-4e8f-96a2-14a3eaf7e99b", null, "Librarian", "LIBRARIAN" },
                    { "a2656152-deb0-4622-9bfe-38c29b86ddb4", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "Author", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Bethel Hoppe", "https://picsum.photos/640/480/?image=720", "Aliquid nemo ad beatae labore at dignissimos eius consequatur. Quis minima voluptatum voluptates. Impedit ducimus dolorum beatae mollitia in. Eaque ullam nihil mollitia in. Itaque vel et similique et facere aliquid. Culpa odit qui.", "2145553863868", 396, new DateTime(2024, 8, 27, 17, 39, 18, 369, DateTimeKind.Local).AddTicks(1520), "Barrows and Sons", "Handmade Rubber Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                columns: new[] { "Author", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Theron Vandervort", "https://picsum.photos/640/480/?image=777", "Commodi eveniet dolorem qui non consequuntur ad expedita repellat porro. Repellat maiores minus sit. Labore aperiam error corporis qui quia. Unde cumque velit non.", "4574309328913", 978, new DateTime(2016, 2, 12, 6, 5, 40, 390, DateTimeKind.Local).AddTicks(5883), "Kulas Inc", "Rustic Frozen Chair" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Jaquan Hackett", 3, "https://picsum.photos/640/480/?image=363", "Quae at esse et veniam vel amet laboriosam voluptas maiores. Eveniet quod vero aut perferendis quasi minima deleniti. Qui quo dolorem qui quo voluptate dolore alias.", "5789810487335", 840, new DateTime(2016, 4, 12, 8, 26, 18, 398, DateTimeKind.Local).AddTicks(2121), "Langosh - Reynolds", "Handcrafted Concrete Cheese" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Carol Gutkowski", 4, "https://picsum.photos/640/480/?image=498", "Dolorem voluptatum voluptate. Voluptates explicabo optio mollitia occaecati. Vel facere cupiditate perspiciatis quis voluptas ad aut.", "5730864913059", 496, new DateTime(2020, 3, 6, 8, 38, 7, 947, DateTimeKind.Local).AddTicks(2531), "Kertzmann Group", "Gorgeous Steel Cheese" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Blaze Bartell", 3, "https://picsum.photos/640/480/?image=983", "Alias et saepe vero quaerat rerum quidem recusandae. At dolorem veritatis. Et quia autem dolores. Aspernatur vel repellendus est minima voluptate. Veniam fugit rerum architecto perferendis perspiciatis itaque velit rerum recusandae.", "2970585096089", 533, new DateTime(2021, 6, 21, 6, 5, 22, 884, DateTimeKind.Local).AddTicks(2885), "Parisian - Grant", "Refined Concrete Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Arnold King", 1, "https://picsum.photos/640/480/?image=906", "Dignissimos distinctio minima nisi. Quaerat voluptatem aut consectetur voluptate saepe numquam nisi sed non. Omnis ad dolores at.", "4050797655651", 187, new DateTime(2015, 5, 25, 22, 34, 31, 53, DateTimeKind.Local).AddTicks(4620), "Rodriguez, Lakin and Lubowitz", "Ergonomic Rubber Tuna" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Myrtis Kulas", 3, "https://picsum.photos/640/480/?image=318", "Aut sequi qui quod officiis ab beatae. Incidunt consequuntur rem delectus recusandae itaque ducimus. Omnis impedit nesciunt possimus occaecati. Qui ut voluptatem voluptatem eum aut voluptatum saepe sequi sit. Accusantium sed rerum consectetur aut occaecati voluptas qui ipsa.", "8971316743962", 718, new DateTime(2016, 5, 30, 0, 23, 11, 71, DateTimeKind.Local).AddTicks(4974), "McDermott, Wintheiser and Witting", "Refined Metal Ball" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Luciano Hoeger", 3, "https://picsum.photos/640/480/?image=815", "Magni sunt atque. Fuga voluptas non sint praesentium nesciunt aperiam exercitationem. Quae officia ducimus sint molestiae atque quaerat similique inventore neque. Consectetur quos neque in. Natus voluptatum qui aspernatur accusamus repudiandae sit ex.", "6338989967576", 230, new DateTime(2016, 6, 25, 7, 15, 39, 563, DateTimeKind.Local).AddTicks(642), "Ryan, Jacobs and DuBuque", "Fantastic Cotton Salad" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9,
                columns: new[] { "Author", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Stella Cremin", "https://picsum.photos/640/480/?image=364", "At architecto nemo rerum est fuga eligendi. Natus eum sit. Ex voluptatem sunt illum. Et vel vel dolores. Magni est dicta. Tempore esse blanditiis porro et quos repudiandae quis.", "6666371679128", 176, new DateTime(2021, 3, 20, 18, 42, 16, 25, DateTimeKind.Local).AddTicks(4674), "Rosenbaum Inc", "Handmade Cotton Mouse" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Kay Zemlak", 3, "https://picsum.photos/640/480/?image=494", "Recusandae similique qui quam. Et commodi dolor voluptatem molestias. Enim laboriosam eaque necessitatibus temporibus et voluptas repellendus eligendi. Earum et voluptate quia temporibus eveniet aliquid. Animi laboriosam eum eaque et. Eos et neque id porro aut.", "8093810520914", 799, new DateTime(2024, 5, 23, 14, 26, 26, 787, DateTimeKind.Local).AddTicks(1839), "Batz, Jaskolski and Herman", "Unbranded Frozen Chips" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 11,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Haskell Schoen", 4, "https://picsum.photos/640/480/?image=686", "Cumque itaque in cupiditate. Autem eveniet omnis deleniti quo necessitatibus et illum nobis. Molestiae facere magni ullam dignissimos maiores sed molestias quam quia. Non incidunt molestias ut.", "7968238024690", 884, new DateTime(2015, 4, 28, 2, 57, 57, 704, DateTimeKind.Local).AddTicks(1891), "Shanahan - Mueller", "Incredible Plastic Bike" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 12,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Martina Streich", 5, "https://picsum.photos/640/480/?image=791", "Culpa repellat magni quia sit aut quisquam vero. Consequatur sit fuga aut. Ea et sint atque dolorem. Ex est pariatur est voluptas ea velit. Fugit inventore exercitationem et magnam molestiae optio quia.", "5700877211343", 803, new DateTime(2023, 2, 21, 1, 33, 25, 898, DateTimeKind.Local).AddTicks(6580), "Maggio Inc", "Handcrafted Plastic Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 13,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Magdalena Schimmel", 3, "https://picsum.photos/640/480/?image=422", "Illum aut eos est fugit occaecati vitae fugit et quia. Soluta tempora nihil velit ipsa consectetur nulla laudantium recusandae. Reprehenderit laboriosam est tempora. Tenetur eligendi saepe quasi sint. Voluptatibus saepe officia autem doloribus aliquam earum tenetur rem. Omnis quo nihil harum qui autem ipsum.", "1064706314822", 310, new DateTime(2016, 6, 2, 11, 28, 48, 235, DateTimeKind.Local).AddTicks(807), "Lind, Kautzer and Reilly", "Rustic Steel Shoes" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 14,
                columns: new[] { "Author", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Ryan Kuphal", "https://picsum.photos/640/480/?image=292", "Sunt ad est dolores inventore occaecati veritatis quia. Eveniet odit mollitia blanditiis voluptas qui harum cupiditate. Et voluptates ex delectus qui nihil aperiam sed qui. Tenetur velit voluptas. Est sint et.", "9649416339154", 545, new DateTime(2015, 8, 3, 6, 57, 47, 557, DateTimeKind.Local).AddTicks(9765), "Maggio, Rath and Rogahn", "Handcrafted Frozen Table" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 15,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Lily Legros", 4, "https://picsum.photos/640/480/?image=380", "Exercitationem porro et eius odit. Quia sit autem alias. Quam mollitia minus. Ut repellat vitae odio sed asperiores quibusdam iure dolor fugit. Voluptate est sapiente ut voluptas doloribus provident numquam fugit.", "2186383723052", 418, new DateTime(2023, 6, 15, 15, 1, 3, 209, DateTimeKind.Local).AddTicks(5130), "Bechtelar, Berge and Bode", "Incredible Wooden Pizza" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 16,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Amira Lang", 4, "https://picsum.photos/640/480/?image=468", "Illum est a et itaque sit numquam voluptatibus voluptatum repellendus. Quia delectus quas nihil. Aperiam et a. Tempore delectus non facilis animi. Tenetur quibusdam sed minus atque. Consequatur doloremque facere ad enim hic molestiae praesentium.", "2997044743407", 127, new DateTime(2015, 4, 30, 2, 57, 43, 864, DateTimeKind.Local).AddTicks(3405), "Senger - Jakubowski", "Tasty Cotton Computer" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 17,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Juliet Runolfsson", 5, "https://picsum.photos/640/480/?image=267", "Quod et sapiente voluptates itaque quas eos sapiente omnis non. Eaque aliquid dolorem nesciunt est in officia alias eveniet delectus. Ullam dignissimos quibusdam veritatis aut. Neque nesciunt qui commodi alias maiores. Et deserunt accusantium consequatur.", "9920124488014", 567, new DateTime(2019, 4, 20, 1, 12, 10, 157, DateTimeKind.Local).AddTicks(5289), "Koepp LLC", "Gorgeous Steel Ball" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 18,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Braden Hyatt", 4, "https://picsum.photos/640/480/?image=298", "Iure voluptas aliquam sapiente. Autem hic repellendus aut voluptate cum ipsa nulla dolores soluta. Veniam vel dolores. Provident quis dolorem natus accusamus quis et recusandae eum corrupti. Non dolores qui rerum molestias illo natus dolores qui. Esse temporibus corporis dignissimos possimus at.", "4486832404814", 302, new DateTime(2017, 9, 19, 12, 3, 40, 565, DateTimeKind.Local).AddTicks(4928), "Schneider and Sons", "Fantastic Soft Tuna" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 19,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Kaylin Harber", 4, "https://picsum.photos/640/480/?image=281", "Tenetur aut ipsum. Et dolorem quo at eos ut. Laborum illum ullam sequi. Possimus mollitia voluptatem quod quibusdam sunt. Deserunt quisquam labore nam reprehenderit impedit repellendus et iusto. Nisi et nisi quo vel voluptatem quae.", "5648445294780", 928, new DateTime(2019, 5, 13, 18, 7, 26, 428, DateTimeKind.Local).AddTicks(5717), "Schamberger, Jacobson and Koepp", "Handcrafted Cotton Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 20,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Kayli Keebler", 4, "https://picsum.photos/640/480/?image=441", "Suscipit tempore ut quae commodi non in quisquam voluptatem. Sit autem et aut vero omnis dicta maiores. Facere aliquam nostrum velit officia. Qui dolore numquam aut in architecto. Quia fugiat quia cum.", "8814306288626", 881, new DateTime(2018, 5, 13, 0, 30, 1, 831, DateTimeKind.Local).AddTicks(4907), "Bechtelar Inc", "Small Wooden Bike" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Outdoors");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Beauty");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Clothing");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Name",
                value: "Home");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Name",
                value: "Industrial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "664ac092-f0f8-4e8f-96a2-14a3eaf7e99b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2656152-deb0-4622-9bfe-38c29b86ddb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3167fd11-1b83-4043-8f00-d12984f6f9a7", null, "Librarian", "LIBRARIAN" },
                    { "ba7b1c19-82d3-4c81-ace7-56b17c591292", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "Author", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Queen Rogahn", "https://picsum.photos/640/480/?image=140", "Ut tenetur ipsam architecto commodi et. Delectus atque quia qui. Cumque fugiat nisi quibusdam a placeat omnis maxime aliquid labore. Aut sit natus consequatur animi magnam expedita dolorem nostrum.", "9350118348800", 374, new DateTime(2018, 8, 13, 23, 54, 50, 388, DateTimeKind.Local).AddTicks(3690), "Goldner Group", "Small Cotton Car" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                columns: new[] { "Author", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Briana Boehm", "https://picsum.photos/640/480/?image=577", "Odio atque enim labore sunt nostrum minima. Id omnis voluptas non natus molestias animi deserunt rerum. Qui tenetur laudantium rem fugit recusandae accusantium non sint. Alias recusandae qui illo id.", "2104547867664", 692, new DateTime(2015, 5, 11, 13, 55, 53, 809, DateTimeKind.Local).AddTicks(432), "Bruen - Mills", "Refined Cotton Ball" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Shayna Ondricka", 2, "https://picsum.photos/640/480/?image=223", "Placeat et quia sint repellendus incidunt. Odit rem temporibus eaque. Voluptates velit incidunt commodi ut minima ut.", "5870284705275", 205, new DateTime(2016, 3, 27, 5, 6, 11, 322, DateTimeKind.Local).AddTicks(6683), "Dare, Leffler and Crona", "Handcrafted Soft Soap" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Alivia Berge", 1, "https://picsum.photos/640/480/?image=872", "Vel et officiis ab commodi dolores tenetur quisquam ut. Eligendi consequatur fuga cupiditate quibusdam vero. Fugiat totam omnis quidem voluptatibus et vel. Dolor voluptatum at animi.", "2339462428304", 147, new DateTime(2016, 8, 10, 22, 55, 16, 282, DateTimeKind.Local).AddTicks(6901), "West - Kirlin", "Incredible Fresh Shoes" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Sabina Hackett", 5, "https://picsum.photos/640/480/?image=352", "Qui consequatur in quibusdam ab. Consequatur earum aperiam sint dolore facilis sit adipisci quos. Illum non quia non enim eveniet. Fugit eaque ducimus dolores nobis qui molestiae et quia. Modi fugiat facilis consectetur non mollitia consequatur saepe veritatis rerum.", "6273916832391", 873, new DateTime(2015, 10, 13, 1, 46, 0, 141, DateTimeKind.Local).AddTicks(8910), "Pfeffer and Sons", "Fantastic Plastic Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Destini Pfeffer", 3, "https://picsum.photos/640/480/?image=805", "Ratione odio assumenda cumque provident id sint temporibus. Et ratione ea enim. Nihil et unde eveniet rerum distinctio enim.", "4033777687828", 937, new DateTime(2022, 11, 15, 0, 34, 56, 461, DateTimeKind.Local).AddTicks(6070), "Zemlak - O'Conner", "Sleek Plastic Table" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Alexie Goldner", 1, "https://picsum.photos/640/480/?image=484", "Quae vitae est repellendus cupiditate laboriosam aliquam quod. Sit labore praesentium. Odio dolorem tempora aut fuga repellat. Reprehenderit in omnis dicta placeat suscipit maxime. Autem vel et. Enim dolorem laborum quibusdam necessitatibus possimus.", "7194093216011", 183, new DateTime(2016, 5, 5, 3, 24, 17, 438, DateTimeKind.Local).AddTicks(3938), "Fadel - Kuhic", "Handmade Plastic Hat" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Glen Cassin", 5, "https://picsum.photos/640/480/?image=247", "Sed qui minima rerum molestiae. Dolorem vel voluptatem vitae quia. Ullam doloremque ut magni odit ad laborum rem sunt.", "1216253695514", 887, new DateTime(2017, 9, 13, 14, 4, 30, 101, DateTimeKind.Local).AddTicks(7315), "Larkin - Conroy", "Practical Plastic Fish" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9,
                columns: new[] { "Author", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Megane Hartmann", "https://picsum.photos/640/480/?image=960", "Tenetur consequuntur itaque eaque repellendus rerum eius autem neque ad. Perferendis adipisci sed sit assumenda adipisci. Quidem culpa facere et cupiditate deserunt alias debitis sed. Quae nobis aut iste doloremque. Sapiente voluptatem illum sunt voluptate sed odit sint. Quia quia temporibus eligendi.", "3282773840510", 994, new DateTime(2014, 10, 11, 3, 11, 50, 507, DateTimeKind.Local).AddTicks(3069), "Smitham and Sons", "Gorgeous Soft Computer" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Khalil Nolan", 2, "https://picsum.photos/640/480/?image=722", "Natus ut sint ut delectus debitis. Eos nisi earum eveniet eum. In accusamus aut magnam fuga laudantium nihil. Veritatis quasi similique porro exercitationem illo quaerat officia. Rerum est consectetur quia et dicta rerum quas. Veritatis ut atque aut dolore porro culpa illum.", "2067764841292", 600, new DateTime(2019, 12, 30, 0, 40, 37, 940, DateTimeKind.Local).AddTicks(4281), "White and Sons", "Ergonomic Cotton Gloves" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 11,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Christelle Wolff", 1, "https://picsum.photos/640/480/?image=445", "Et ea et blanditiis sunt praesentium. Dolorem non nesciunt dolores labore ab. Quam vel in sed recusandae. Itaque nostrum rerum sunt culpa consectetur. Et ad modi eius optio.", "0131498142504", 755, new DateTime(2024, 4, 9, 23, 36, 17, 69, DateTimeKind.Local).AddTicks(6235), "Langworth - Marquardt", "Unbranded Plastic Pants" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 12,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Ayla Mayert", 4, "https://picsum.photos/640/480/?image=1053", "Voluptas ipsum et consequatur sit laudantium. Consequuntur atque unde aperiam minima aut veniam corporis earum. Consequatur tenetur perspiciatis vel dolores. Neque ducimus debitis excepturi corrupti dolor quaerat quae dolorem. Iste adipisci beatae quia modi sed eligendi repellendus.", "8415390821401", 510, new DateTime(2015, 8, 15, 18, 37, 21, 2, DateTimeKind.Local).AddTicks(9900), "Corwin, Lynch and Morissette", "Sleek Fresh Hat" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 13,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Tony Hamill", 5, "https://picsum.photos/640/480/?image=733", "Consequuntur nisi recusandae quasi iure. Cupiditate vitae velit sint et ea tenetur qui a hic. Ad maxime praesentium.", "0284972056337", 763, new DateTime(2024, 4, 18, 5, 59, 27, 909, DateTimeKind.Local).AddTicks(6290), "Becker and Sons", "Handmade Fresh Table" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 14,
                columns: new[] { "Author", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Santiago Wilderman", "https://picsum.photos/640/480/?image=373", "Sed voluptas animi magni aut. Dolorum aliquid molestiae. Beatae totam aperiam. Tempore voluptas rerum ut quo quae. Cupiditate alias ullam. Veritatis cupiditate voluptatum aut eos blanditiis velit nulla.", "4207650657608", 323, new DateTime(2023, 1, 26, 16, 3, 59, 268, DateTimeKind.Local).AddTicks(294), "Carter, Kuvalis and Homenick", "Generic Metal Soap" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 15,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Kelsie Morissette", 1, "https://picsum.photos/640/480/?image=548", "In eligendi consequatur minus aspernatur illum praesentium maiores omnis quisquam. Iste esse excepturi sint suscipit. Debitis illo rem possimus voluptas enim et est sit rerum. Quam corporis voluptatem beatae aut quibusdam. In et sed aut.", "0651729368195", 364, new DateTime(2024, 6, 18, 11, 56, 27, 69, DateTimeKind.Local).AddTicks(5586), "Heidenreich, Flatley and Dickinson", "Licensed Soft Sausages" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 16,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Julian Mueller", 5, "https://picsum.photos/640/480/?image=850", "Veniam asperiores ipsum eos provident aliquam quo. Aut eos sequi omnis quia. Natus id voluptatum. Non suscipit porro.", "8383304368307", 330, new DateTime(2019, 11, 21, 22, 23, 54, 924, DateTimeKind.Local).AddTicks(8134), "Douglas - Gerhold", "Small Fresh Shoes" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 17,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Corbin Mohr", 1, "https://picsum.photos/640/480/?image=575", "Alias voluptas voluptatem eveniet quasi temporibus incidunt qui ipsam. Tempore perspiciatis ad quaerat excepturi dolor vero ipsa voluptates. Facere aut fuga inventore sed nesciunt.", "2375632473477", 120, new DateTime(2022, 12, 12, 22, 29, 54, 658, DateTimeKind.Local).AddTicks(9171), "Gerhold - Ruecker", "Tasty Rubber Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 18,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Christelle Dietrich", 2, "https://picsum.photos/640/480/?image=945", "Sit consectetur sequi tempora et et delectus. Et reiciendis architecto. Molestias placeat praesentium et ex qui rerum rerum rem. Ab voluptatem quia est porro dolores. Culpa nam molestiae harum dolores eaque delectus.", "7818129859842", 848, new DateTime(2017, 7, 24, 1, 33, 42, 598, DateTimeKind.Local).AddTicks(144), "Schumm, Stokes and Schmeler", "Licensed Plastic Chicken" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 19,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Sam Weimann", 1, "https://picsum.photos/640/480/?image=55", "Facilis voluptas et. Occaecati quia placeat nesciunt ducimus sed quam quaerat vel. Tenetur expedita neque nihil.", "4476011315420", 264, new DateTime(2022, 5, 14, 12, 20, 19, 320, DateTimeKind.Local).AddTicks(6991), "Christiansen - Dickinson", "Ergonomic Soft Table" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 20,
                columns: new[] { "Author", "CategoryId", "CoverImage", "Description", "ISBN", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[] { "Arielle Bins", 5, "https://picsum.photos/640/480/?image=32", "Corrupti nam sapiente dolores. Laboriosam ullam dolorum qui voluptas sit. Minus et illo quo voluptas ad assumenda quo. Magni cum laudantium et. Occaecati atque sint tenetur suscipit id aut eos. Aut eligendi sit libero in aspernatur est.", "8572156043672", 595, new DateTime(2017, 3, 17, 4, 42, 7, 935, DateTimeKind.Local).AddTicks(1967), "Johnston, Lemke and Weimann", "Practical Steel Mouse" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Tools");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Baby");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Grocery");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Name",
                value: "Grocery");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Name",
                value: "Outdoors");
        }
    }
}
