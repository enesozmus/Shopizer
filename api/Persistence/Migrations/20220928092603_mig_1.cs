using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
     public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: true),
                    Showcase = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsOfferable = table.Column<bool>(type: "bit", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferPrice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductImageFile",
                columns: table => new
                {
                    ProductImageFilesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductImageFile", x => new { x.ProductImageFilesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_BaseFiles_ProductImageFilesId",
                        column: x => x.ProductImageFilesId,
                        principalTable: "BaseFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products_Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Orders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Products_Orders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "23d7ad86-8c63-4e65-96ec-2ed327f37ebc", "Admin", "ADMIN" },
                    { 2, "687fe331-9824-43d7-a1d1-e260d1536757", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenEndDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "a29b3093-03e1-45de-9aa2-2b5de1123410", "enes@seeddata.com", true, "Enes", "Ozmus", false, null, " ENES@SEEDDATA.COM", "ENESOZMUS", "AQAAAAEAACcQAAAAENf+JK2X3+GB4zvHAcQ9BaDCtDS35JpJQqs5IOdxeTsHCR7hZP/e2HnfmI3BCfUsWg==", "0541 555 ####", false, null, null, "8b4a10af-e497-462c-b6a1-00d51b076d9f", false, "enesozmus" },
                    { 2, 0, "c653fe87-145f-4d6c-bb48-8b8820e2c6bf", "umay@seeddata.com", true, "Umay", "Zengin", false, null, "UMAY@SEEDDATA.COM", "UMAYZENGIN", "AQAAAAEAACcQAAAAEDlWiSDVcZsZ4xs4Peoa5lO3GP8p8qwHpVQerjF59HPLsgZzJDsemysr+ghFH1Az9A==", "0542 555 ####", false, null, null, "897a0163-28c8-49de-8b08-3b07e48b1433", false, "umayzengin" },
                    { 3, 0, "6a25282a-3c32-40ef-993c-dd1b3a49a84a", "selim@seeddata.com", true, "Selim", "Karaca", false, null, "SELIM@SEEDDATA.COM", "SELIMKARACA", "AQAAAAEAACcQAAAAEPCCEt4Bfaq+cZOt1EOzIK3gc2V13hFydI1ieB1Kno6Y7GgxMosTF8DOu6ls36TfqA==", "0543 555 ####", false, null, null, "b9a8c451-a1c8-4bcf-ae10-a4052467d83c", false, "selimkaraca" },
                    { 4, 0, "b5fe1d20-3e47-409e-afce-2fd49e991b65", "emine@seeddata.com", true, "Emine", "Yıldırım", false, null, "EMINE@SEEDDATA.COM", "EMINEYILDIRIM", "AQAAAAEAACcQAAAAECDJer4QvGn3Lb22ogpWHV2L9LVEqGDEp3YbrHnp45AsOScPvl2j0QYuJjkANCBY+w==", "0544 555 ####", false, null, null, "34a05b52-b85b-4b80-9f07-5b74d8f37eac", false, "emineyıldırım" },
                    { 5, 0, "5143a181-2bf4-4d88-9882-ea05b034e6b0", "ihsan@seeddata.com", true, "İhsan", "Yenilmez", false, null, "IHSAN@SEEDDATA.COM", "IHSANYENILMEZ", "AQAAAAEAACcQAAAAEAAal14Y8XVo2XRtnANJFHwC63Jk42blWiu03YwWzUy9TzsxaR7m82rNEpoF1HvC7A==", "0545 555 ####", false, null, null, "bc4d6b80-75b0-4821-8f5c-607817461bb9", false, "ihsanyenilmez" },
                    { 6, 0, "62865a99-c7b6-4d2b-811f-be1bb9dc5762", "berrin@seeddata.com", true, "Berrin", "Miral", false, null, "BERRIN@SEEDDATA.COM", "BERRINMIRAL", "AQAAAAEAACcQAAAAEDPZCRih0+x/DTLelV8RYB3FF/Ri4dT5xN80/ZRONwuO4iL7tEDCFhyz24OLjz3SLA==", "0546 555 ####", false, null, null, "3f024cb1-030f-420d-84a9-55e10df1eee5", false, "berrinmiral" },
                    { 7, 0, "72c21fbf-2bbf-41dd-a59d-3ca4253c6074", "salih@seeddata.com", true, "Salih", "Yurdakul", false, null, "SALIH@SEEDDATA.COM", "SALIHYURDAKUL", "AQAAAAEAACcQAAAAEGbDPcLnG406XUIcl70BWDLXNfOsr6aF+BD5f0EkQT9SuVw+SVcbWRBbrX9x64uBsA==", "0547 555 ####", false, null, null, "c4586e1a-904f-4bd5-b904-14d6baaedd1b", false, "salihyurdakul" },
                    { 8, 0, "1faff125-8cfa-435b-bade-a10440da76a5", "zafer@seeddata.com", true, "Zafer", "Kırat", false, null, "ZAFER@SEEDDATA.COM", "ZAFERKIRAT", "AQAAAAEAACcQAAAAED5c6xPHyTN03WcmGB9fMVXRdKiDwCgYd9AZRZkAehWbK0HK4JweogMOZKqkvHC69w==", "0548 555 ####", false, null, null, "bd8d1f8a-b337-478c-8dd5-34d1ba69d4cc", false, "zaferkırat" },
                    { 9, 0, "519eac7f-79cb-4d63-a222-4b8b93e785d6", "emre@seeddata.com", true, "Emre", "Demir", false, null, "EMRE@SEEDDATA.COM", "EMREDEMIR", "AQAAAAEAACcQAAAAED1R4cfMSwfCGOr/SASHvy2JVvmhhCoF13adBD2ppXPE7rtbCohSU+HvTs7MeZTEzg==", "0549 555 ####", false, null, null, "e23c778a-f521-4b7f-9eda-7084c568d8d6", false, "emredemir" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LCWAIKIKI" },
                    { 2, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LCWAIKIKI Limited" },
                    { 3, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LCWAIKIKI Modest" },
                    { 4, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LCWAIKIKI Casual" },
                    { 5, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LCWAIKIKI Vision" },
                    { 6, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MIZALLE" },
                    { 7, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BENETTON" },
                    { 8, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BIANCA" },
                    { 9, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "QOOQ STORE" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mont" },
                    { 2, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hırka ve Süveter" },
                    { 3, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kazak" },
                    { 4, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bluz" },
                    { 5, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gömlek" },
                    { 6, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tişört" },
                    { 7, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sweatshirt" },
                    { 8, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jean" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ekru" },
                    { 2, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırmızı" },
                    { 3, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lacivert" },
                    { 4, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Açık Kahverengi" },
                    { 5, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mavi" },
                    { 6, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Antrasit" },
                    { 7, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Koyu Gri" },
                    { 8, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Canlı Turuncu" },
                    { 9, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bej Çizgili" },
                    { 10, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beyaz" },
                    { 11, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gri" },
                    { 12, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İndigo Melanj" },
                    { 13, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Koyu Rodeo" },
                    { 14, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Optik Beyaz" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "XS" },
                    { 2, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "S" },
                    { 3, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "M" },
                    { 4, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "L" },
                    { 5, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "XL" },
                    { 6, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "2XL" },
                    { 7, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "3XL" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AppUserId", "BrandId", "CategoryId", "ColorId", "CreatedDate", "IsOfferable", "IsSold", "LastModifiedDate", "Name", "Price", "SizeId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Dik Yaka Erkek Deri Mont", 2699.99f, 1, 400 },
                    { 2, 1, 1, 1, 2, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Biker Yaka Erkek Deri Mont", 2699.99f, 1, 400 },
                    { 3, 1, 1, 1, 3, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Gömlek Yaka Erkek Şişme Mont", 2699.99f, 1, 400 },
                    { 4, 1, 4, 2, 4, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Kuşak Detaylı Uzun Kollu Kadın Triko Hırka", 499.99f, 2, 400 },
                    { 5, 2, 5, 2, 5, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Kapüşonlu Kendinden Desenli Kadın Süveter", 189.99f, 3, 400 },
                    { 6, 2, 6, 3, 6, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Balıkçı Yaka Uzun Kollu Erkek Triko Kazak", 79.99f, 3, 400 },
                    { 7, 2, 7, 3, 7, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Bisiklet Yaka Uzun Kollu Çizgili Erkek Triko Kazak", 149.99f, 4, 400 },
                    { 8, 2, 8, 4, 8, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, "Kalp Yaka Kolsız Kadın Blız", 449.99f, 4, 400 },
                    { 9, 3, 9, 4, 9, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, "Renk Bloklu Uzun Kollu Kadın Bluz", 599.99f, 5, 400 },
                    { 10, 3, 1, 5, 10, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Uzun Kollu Poplin Erkek Gömlek", 349.99f, 5, 400 },
                    { 11, 3, 2, 5, 11, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Uzun Kollu Keten Erkek Gömlek", 349.99f, 6, 400 },
                    { 12, 3, 3, 6, 12, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, "Tül Detaylı Kadın Lima Tişört", 199.99f, 6, 400 },
                    { 13, 4, 4, 6, 13, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Bisiklet Yaka Baskılı Kadın Tişört", 199.99f, 7, 400 },
                    { 14, 5, 5, 7, 14, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Baskılı Erkek Sweatshirt", 299.99f, 7, 400 },
                    { 15, 6, 6, 7, 11, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, "Outdoor Kapüşonlu Erkek Sweatshirt", 269.99f, 1, 400 },
                    { 16, 7, 7, 8, 12, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Tül Kemer Detaylı Kadın Jean", 349.99f, 1, 400 },
                    { 17, 8, 8, 8, 10, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, "Cepli Kadın Flare Jean", 269.99f, 2, 400 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AppUserId",
                table: "Offers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProductId",
                table: "Offers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductImageFile_ProductsId",
                table: "ProductProductImageFile",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AppUserId",
                table: "Products",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizeId",
                table: "Products",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Orders_OrderId",
                table: "Products_Orders",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "ProductProductImageFile");

            migrationBuilder.DropTable(
                name: "Products_Orders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BaseFiles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
