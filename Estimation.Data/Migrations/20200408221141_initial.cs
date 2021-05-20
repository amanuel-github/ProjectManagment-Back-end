using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Estimation.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
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
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Catagory = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessUnits_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Catagory = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UOMMeasure = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostCodes_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Desciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desciplines_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectStatus_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceTypes_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    BusinessUnitId = table.Column<int>(nullable: false),
                    CostCodeId = table.Column<int>(nullable: false),
                    EstimatedPrice = table.Column<int>(nullable: false),
                    ProjectStatusId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EstimatedDuration = table.Column<int>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_CostCodes_CostCodeId",
                        column: x => x.CostCodeId,
                        principalTable: "CostCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "ProjectStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UOM = table.Column<string>(nullable: true),
                    EstimatedQuantity = table.Column<int>(nullable: false),
                    RevisedQuantity = table.Column<int>(nullable: false),
                    EstimatedUnitPrice = table.Column<int>(nullable: false),
                    EstimatedPrice = table.Column<int>(nullable: false),
                    BidUnitPrice = table.Column<int>(nullable: false),
                    ProductivtyFactor = table.Column<string>(nullable: true),
                    MHRFactor = table.Column<string>(nullable: true),
                    TotalMHR = table.Column<string>(nullable: true),
                    ResourceTypeId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estimations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    DesciplineId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    MHRFactor = table.Column<string>(nullable: true),
                    TotalMHR = table.Column<string>(nullable: true),
                    EstimatedHourRate = table.Column<string>(nullable: true),
                    CostCodeId = table.Column<int>(nullable: false),
                    Rounded = table.Column<double>(nullable: false),
                    Contingency = table.Column<double>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimations_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estimations_CostCodes_CostCodeId",
                        column: x => x.CostCodeId,
                        principalTable: "CostCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estimations_Desciplines_DesciplineId",
                        column: x => x.DesciplineId,
                        principalTable: "Desciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estimations_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estimations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnits_ApplicationUserId",
                table: "BusinessUnits",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCodes_ApplicationUserId",
                table: "CostCodes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Desciplines_ApplicationUserId",
                table: "Desciplines",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_ApplicationUserId",
                table: "Estimations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_CostCodeId",
                table: "Estimations",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_DesciplineId",
                table: "Estimations",
                column: "DesciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_ItemId",
                table: "Estimations",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_ProjectId",
                table: "Estimations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ApplicationUserId",
                table: "Items",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ResourceTypeId",
                table: "Items",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ApplicationUserId",
                table: "Projects",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BusinessUnitId",
                table: "Projects",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CostCodeId",
                table: "Projects",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStatus_ApplicationUserId",
                table: "ProjectStatus",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTypes_ApplicationUserId",
                table: "ResourceTypes",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estimations");

            migrationBuilder.DropTable(
                name: "Desciplines");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropTable(
                name: "BusinessUnits");

            migrationBuilder.DropTable(
                name: "CostCodes");

            migrationBuilder.DropTable(
                name: "ProjectStatus");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
