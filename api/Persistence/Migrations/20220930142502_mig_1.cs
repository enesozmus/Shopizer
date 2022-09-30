using System;
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
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
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
                        onDelete: ReferentialAction.Cascade);
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Orders_Baskets_Id",
                        column: x => x.Id,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
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
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "6ffb1668-dddf-4059-9ed4-30ad209ff0d2", "Admin", "ADMIN" },
                    { 2, "f40c9353-e6aa-4c4e-9d35-54561aa6892c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenEndDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "f6b8cb7d-a7ab-4cd4-a69d-feaf90c14084", "enes@seeddata.com", true, "Enes", "Ozmus", false, null, " ENES@SEEDDATA.COM", "ENESOZMUS", "AQAAAAEAACcQAAAAEOMfDhoL92w0eg94WSNK0qdqsiZ4gmvcUk2NdXpQNFvjDG32EcHlrPmJLZY3SDV5hg==", "0541 555 ####", false, null, null, "b7822267-5fe3-43b9-9152-910d63ebd39c", false, "enesozmus" },
                    { 2, 0, "f3ee0a02-0065-480a-a367-139cfa83c225", "umay@seeddata.com", true, "Umay", "Zengin", false, null, "UMAY@SEEDDATA.COM", "UMAYZENGIN", "AQAAAAEAACcQAAAAEGTseNDKKx0uePTANKtLSjCedARn9gfWRADg/B8MuVBQQEai8c5OyYxoV1zdXPP+nw==", "0542 555 ####", false, null, null, "e633be65-3b0a-4bb9-89dc-93b00f23d019", false, "umayzengin" },
                    { 3, 0, "678a702f-ff70-4ff6-a10f-37cb99b7252e", "selim@seeddata.com", true, "Selim", "Karaca", false, null, "SELIM@SEEDDATA.COM", "SELIMKARACA", "AQAAAAEAACcQAAAAEC0m/hhWAIStCoDSZbgKs+VHcNsRWB47LEZHPLGnR0s0dTpucw2QsFHkLBo7sPiJPA==", "0543 555 ####", false, null, null, "0392de8b-e9d0-491e-b5cd-506e709f10a9", false, "selimkaraca" },
                    { 4, 0, "618351ec-9b2e-41d9-82c7-f2905612edf9", "emine@seeddata.com", true, "Emine", "Yıldırım", false, null, "EMINE@SEEDDATA.COM", "EMINEYILDIRIM", "AQAAAAEAACcQAAAAEDDssodahdIr2YtB7NMdbVocLDXMNZKYGuvTzlycWgzYcifMS/GnJNTXoM8NO0HOSw==", "0544 555 ####", false, null, null, "55323e1e-d5a5-4b17-8c9f-834d00a761ca", false, "emineyıldırım" },
                    { 5, 0, "2bba985c-8076-4f9e-b675-16fb4c8795f7", "ihsan@seeddata.com", true, "İhsan", "Yenilmez", false, null, "IHSAN@SEEDDATA.COM", "IHSANYENILMEZ", "AQAAAAEAACcQAAAAEGMDeCu6w4jK1lcISjBYbGHdSADAhSipUO6TVJXRDLOQug/WOZdw0AsywKv3HKbC3g==", "0545 555 ####", false, null, null, "f3f994d0-f48c-4023-89e6-fa29d9c6c286", false, "ihsanyenilmez" },
                    { 6, 0, "141bdc61-b80b-4f61-a022-eb79d7c2c166", "berrin@seeddata.com", true, "Berrin", "Miral", false, null, "BERRIN@SEEDDATA.COM", "BERRINMIRAL", "AQAAAAEAACcQAAAAEFoajWIjrX1O7zMYqGLsCKx/iYfG+K6MPIbIRXNa6zQmVykosbn51+XQg2h9if2uaA==", "0546 555 ####", false, null, null, "3517814f-d424-4c4a-8d98-73436777f5fa", false, "berrinmiral" },
                    { 7, 0, "4c7088e8-6f2d-4aea-af96-c48b9d6491ec", "salih@seeddata.com", true, "Salih", "Yurdakul", false, null, "SALIH@SEEDDATA.COM", "SALIHYURDAKUL", "AQAAAAEAACcQAAAAEFmq7WwP1+I7MEyhMOxbfZ53XyTQMUHrFzqxYl4Vk1vQa/iMXr/DX98g6EyCYHlF5g==", "0547 555 ####", false, null, null, "6133c290-212f-44dd-bb59-daa2cc381a8e", false, "salihyurdakul" },
                    { 8, 0, "6487b072-c376-40f0-ac45-d037138ebcb2", "zafer@seeddata.com", true, "Zafer", "Kırat", false, null, "ZAFER@SEEDDATA.COM", "ZAFERKIRAT", "AQAAAAEAACcQAAAAEJ/2tNCZohCCyOBuwCZmrdOCRfiF5BVnDPgBs1JVQC54aBvThaPKypUjgTA0+uzujg==", "0548 555 ####", false, null, null, "217eeafb-11f5-4b50-8084-54f3b3c5713c", false, "zaferkırat" },
                    { 9, 0, "85e3914a-e370-4660-9854-b4dec9418044", "emre@seeddata.com", true, "Emre", "Demir", false, null, "EMRE@SEEDDATA.COM", "EMREDEMIR", "AQAAAAEAACcQAAAAEDe7lTVVAAIxGCBQB1nG/IVPzIK5UjKnwK113G9UDT7foRyF8M/qvIxoeH8PbNj3rg==", "0549 555 ####", false, null, null, "25dd280b-d561-4c6e-b76a-ebd51485174e", false, "emredemir" }
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
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_AppUserId",
                table: "Baskets",
                column: "AppUserId");

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
                name: "BasketItems");

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
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
