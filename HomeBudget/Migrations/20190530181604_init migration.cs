using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeBudget.Migrations
{
    public partial class initmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hb");

            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                schema: "hb",
                columns: table => new
                {
                    RelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "NVARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "auth",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "auth",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "auth",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "auth",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "auth",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                schema: "hb",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    RelationId = table.Column<int>(nullable: false),
                    RelationEntityRelationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Relations_RelationEntityRelationId",
                        column: x => x.RelationEntityRelationId,
                        principalSchema: "hb",
                        principalTable: "Relations",
                        principalColumn: "RelationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_Relations_RelationId",
                        column: x => x.RelationId,
                        principalSchema: "hb",
                        principalTable: "Relations",
                        principalColumn: "RelationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                schema: "hb",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    BillDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_People_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "hb",
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_People_PersonId1",
                        column: x => x.PersonId1,
                        principalSchema: "hb",
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "hb",
                table: "Relations",
                columns: new[] { "RelationId", "Description" },
                values: new object[,]
                {
                    { 1, "Father" },
                    { 2, "Mother" },
                    { 3, "Son" },
                    { 4, "Daughter" }
                });

            migrationBuilder.InsertData(
                schema: "hb",
                table: "People",
                columns: new[] { "PersonId", "Description", "Name", "RelationEntityRelationId", "RelationId" },
                values: new object[] { 2, "head of family", "Bob", null, 1 });

            migrationBuilder.InsertData(
                schema: "hb",
                table: "People",
                columns: new[] { "PersonId", "Description", "Name", "RelationEntityRelationId", "RelationId" },
                values: new object[] { 1, "Girl", "Emily", null, 4 });

            migrationBuilder.InsertData(
                schema: "hb",
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillDate", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "PersonId", "PersonId1" },
                values: new object[,]
                {
                    { 4, 30f, new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", new DateTime(2019, 5, 30, 20, 16, 4, 508, DateTimeKind.Local).AddTicks(3119), "Groseriec", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 5, 100f, new DateTime(2019, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", new DateTime(2019, 5, 30, 20, 16, 4, 508, DateTimeKind.Local).AddTicks(3127), "Food", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 6, 15f, new DateTime(2019, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", new DateTime(2019, 5, 30, 20, 16, 4, 508, DateTimeKind.Local).AddTicks(3131), "Beer", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 1, 3999.99f, new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", new DateTime(2019, 5, 30, 20, 16, 4, 506, DateTimeKind.Local).AddTicks(2290), "TV", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 2, 1000f, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", new DateTime(2019, 5, 30, 20, 16, 4, 508, DateTimeKind.Local).AddTicks(3088), "Washer", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 3, 5999f, new DateTime(2019, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", new DateTime(2019, 5, 30, 20, 16, 4, 508, DateTimeKind.Local).AddTicks(3114), "Audio SYstem", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "auth",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "auth",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "auth",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "auth",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "auth",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "auth",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "auth",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PersonId",
                schema: "hb",
                table: "Bills",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PersonId1",
                schema: "hb",
                table: "Bills",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_People_RelationEntityRelationId",
                schema: "hb",
                table: "People",
                column: "RelationEntityRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_People_RelationId",
                schema: "hb",
                table: "People",
                column: "RelationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Bills",
                schema: "hb");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "People",
                schema: "hb");

            migrationBuilder.DropTable(
                name: "Relations",
                schema: "hb");
        }
    }
}
