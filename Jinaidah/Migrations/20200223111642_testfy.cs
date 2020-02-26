using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jinaidah.Migrations
{
    public partial class testfy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
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
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisonName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoldingCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxItemSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxItemSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionId = table.Column<int>(nullable: false),
                    DistrictName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipilityId = table.Column<int>(nullable: false),
                    WardNo = table.Column<int>(nullable: false),
                    WardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ward_Municipility_MunicipilityId",
                        column: x => x.MunicipilityId,
                        principalTable: "Municipility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upzilla",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictID = table.Column<int>(nullable: false),
                    UpzillaName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upzilla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upzilla_District_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Road",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardId = table.Column<int>(nullable: false),
                    RoadNo = table.Column<int>(nullable: false),
                    RoadName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Road", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Road_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClientName = table.Column<string>(nullable: false),
                    ClientType = table.Column<string>(nullable: true),
                    Father = table.Column<string>(nullable: true),
                    Husband = table.Column<string>(nullable: true),
                    verifyCode = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    UpzillaId = table.Column<int>(nullable: false),
                    NID = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PWD = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: false),
                    ClientAttachment = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    WardId = table.Column<int>(nullable: true),
                    RoadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientInfo_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientInfo_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientInfo_Road_RoadId",
                        column: x => x.RoadId,
                        principalTable: "Road",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientInfo_Upzilla_UpzillaId",
                        column: x => x.UpzillaId,
                        principalTable: "Upzilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientInfo_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoldingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoldingNo = table.Column<string>(nullable: false),
                    ClientInfoId = table.Column<int>(nullable: false),
                    HoldingTypeId = table.Column<string>(nullable: false),
                    HoldingCategoryId = table.Column<string>(nullable: false),
                    WardId = table.Column<int>(nullable: false),
                    RoadId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    MeterNo = table.Column<int>(nullable: false),
                    Floor = table.Column<string>(nullable: true),
                    Flat = table.Column<string>(nullable: true),
                    AssetValue = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    EffectDate = table.Column<DateTime>(nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    UpzillaId = table.Column<int>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    HoldingTypeId1 = table.Column<int>(nullable: true),
                    HoldingCategoryId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldingInfo_ClientInfo_ClientInfoId",
                        column: x => x.ClientInfoId,
                        principalTable: "ClientInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoldingInfo_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoldingInfo_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoldingInfo_HoldingCategory_HoldingCategoryId1",
                        column: x => x.HoldingCategoryId1,
                        principalTable: "HoldingCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoldingInfo_Road_RoadId",
                        column: x => x.RoadId,
                        principalTable: "Road",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoldingInfo_Upzilla_UpzillaId",
                        column: x => x.UpzillaId,
                        principalTable: "Upzilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoldingInfo_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WaterBill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoldingInfoId = table.Column<int>(nullable: false),
                    MeterNo = table.Column<string>(nullable: true),
                    BillNo = table.Column<string>(nullable: false),
                    BillMonth = table.Column<string>(nullable: false),
                    BillYear = table.Column<string>(nullable: false),
                    Unit = table.Column<double>(nullable: false),
                    SurCharge = table.Column<double>(nullable: false),
                    Others = table.Column<double>(nullable: false),
                    Fine = table.Column<double>(nullable: false),
                    Due = table.Column<double>(nullable: false),
                    PreReading = table.Column<double>(nullable: false),
                    PreReadingDate = table.Column<DateTime>(nullable: false),
                    CurrentReading = table.Column<double>(nullable: false),
                    CurrentReadingDate = table.Column<DateTime>(nullable: false),
                    NetReading = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    BillAmount = table.Column<double>(nullable: false),
                    PaidAmount = table.Column<double>(nullable: false),
                    UnPaidAmount = table.Column<double>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterBill_HoldingInfo_HoldingInfoId",
                        column: x => x.HoldingInfoId,
                        principalTable: "HoldingInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterConnection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoldingInfoId = table.Column<int>(nullable: false),
                    ConnectionDia = table.Column<double>(nullable: false),
                    ConnectionDate = table.Column<DateTime>(nullable: false),
                    FloorNos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterConnection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterConnection_HoldingInfo_HoldingInfoId",
                        column: x => x.HoldingInfoId,
                        principalTable: "HoldingInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterRate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterConnectionId = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    FloorNos = table.Column<int>(nullable: false),
                    FloorRate = table.Column<double>(nullable: false),
                    FineRate = table.Column<double>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterRate_WaterConnection_WaterConnectionId",
                        column: x => x.WaterConnectionId,
                        principalTable: "WaterConnection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoldingType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterRateId = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldingType_WaterRate_WaterRateId",
                        column: x => x.WaterRateId,
                        principalTable: "WaterRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxRate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxItemSettingId = table.Column<int>(nullable: false),
                    HoldingTypeId = table.Column<int>(nullable: false),
                    HoldingCategoryId = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRate_HoldingCategory_HoldingCategoryId",
                        column: x => x.HoldingCategoryId,
                        principalTable: "HoldingCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxRate_HoldingType_HoldingTypeId",
                        column: x => x.HoldingTypeId,
                        principalTable: "HoldingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxRate_TaxItemSetting_TaxItemSettingId",
                        column: x => x.TaxItemSettingId,
                        principalTable: "TaxItemSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoldingTax",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoldingInfoId = table.Column<int>(nullable: false),
                    HoldingTypeId = table.Column<int>(nullable: false),
                    TaxItemSettingId = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    TaxAmount = table.Column<double>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    TaxRateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldingTax_HoldingInfo_HoldingInfoId",
                        column: x => x.HoldingInfoId,
                        principalTable: "HoldingInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoldingTax_HoldingType_HoldingTypeId",
                        column: x => x.HoldingTypeId,
                        principalTable: "HoldingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoldingTax_TaxItemSetting_TaxItemSettingId",
                        column: x => x.TaxItemSettingId,
                        principalTable: "TaxItemSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoldingTax_TaxRate_TaxRateId",
                        column: x => x.TaxRateId,
                        principalTable: "TaxRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxBill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoldingInfoId = table.Column<int>(nullable: false),
                    TaxItemSettingId = table.Column<int>(nullable: false),
                    BillNo = table.Column<string>(nullable: false),
                    TaxRateId = table.Column<double>(nullable: false),
                    BillAmount = table.Column<double>(nullable: false),
                    Rebate = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    PaidAmount = table.Column<double>(nullable: false),
                    UnPaidAmount = table.Column<double>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    PaidBy = table.Column<string>(nullable: true),
                    SurCharge = table.Column<double>(nullable: false),
                    ServiceCharge = table.Column<double>(nullable: false),
                    MonthYear = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    TaxRateId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxBill_HoldingInfo_HoldingInfoId",
                        column: x => x.HoldingInfoId,
                        principalTable: "HoldingInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxBill_TaxItemSetting_TaxItemSettingId",
                        column: x => x.TaxItemSettingId,
                        principalTable: "TaxItemSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxBill_TaxRate_TaxRateId1",
                        column: x => x.TaxRateId1,
                        principalTable: "TaxRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_ClientInfo_DistrictId",
                table: "ClientInfo",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInfo_DivisionId",
                table: "ClientInfo",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInfo_RoadId",
                table: "ClientInfo",
                column: "RoadId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInfo_UpzillaId",
                table: "ClientInfo",
                column: "UpzillaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInfo_WardId",
                table: "ClientInfo",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_District_DivisionId",
                table: "District",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_ClientInfoId",
                table: "HoldingInfo",
                column: "ClientInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_DistrictId",
                table: "HoldingInfo",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_DivisionId",
                table: "HoldingInfo",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_HoldingCategoryId1",
                table: "HoldingInfo",
                column: "HoldingCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_HoldingTypeId1",
                table: "HoldingInfo",
                column: "HoldingTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_RoadId",
                table: "HoldingInfo",
                column: "RoadId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_UpzillaId",
                table: "HoldingInfo",
                column: "UpzillaId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_WardId",
                table: "HoldingInfo",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingTax_HoldingInfoId",
                table: "HoldingTax",
                column: "HoldingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingTax_HoldingTypeId",
                table: "HoldingTax",
                column: "HoldingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingTax_TaxItemSettingId",
                table: "HoldingTax",
                column: "TaxItemSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingTax_TaxRateId",
                table: "HoldingTax",
                column: "TaxRateId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingType_WaterRateId",
                table: "HoldingType",
                column: "WaterRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Road_WardId",
                table: "Road",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxBill_HoldingInfoId",
                table: "TaxBill",
                column: "HoldingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxBill_TaxItemSettingId",
                table: "TaxBill",
                column: "TaxItemSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxBill_TaxRateId1",
                table: "TaxBill",
                column: "TaxRateId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_HoldingCategoryId",
                table: "TaxRate",
                column: "HoldingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_HoldingTypeId",
                table: "TaxRate",
                column: "HoldingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_TaxItemSettingId",
                table: "TaxRate",
                column: "TaxItemSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_Upzilla_DistrictID",
                table: "Upzilla",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_MunicipilityId",
                table: "Ward",
                column: "MunicipilityId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterBill_HoldingInfoId",
                table: "WaterBill",
                column: "HoldingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterConnection_HoldingInfoId",
                table: "WaterConnection",
                column: "HoldingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterRate_WaterConnectionId",
                table: "WaterRate",
                column: "WaterConnectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingInfo_HoldingType_HoldingTypeId1",
                table: "HoldingInfo",
                column: "HoldingTypeId1",
                principalTable: "HoldingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientInfo_District_DistrictId",
                table: "ClientInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_District_DistrictId",
                table: "HoldingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Upzilla_District_DistrictID",
                table: "Upzilla");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInfo_Division_DivisionId",
                table: "ClientInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_Division_DivisionId",
                table: "HoldingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInfo_Road_RoadId",
                table: "ClientInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_Road_RoadId",
                table: "HoldingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInfo_Upzilla_UpzillaId",
                table: "ClientInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_Upzilla_UpzillaId",
                table: "HoldingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInfo_Ward_WardId",
                table: "ClientInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_Ward_WardId",
                table: "HoldingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_ClientInfo_ClientInfoId",
                table: "HoldingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_HoldingCategory_HoldingCategoryId1",
                table: "HoldingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_HoldingType_HoldingTypeId1",
                table: "HoldingInfo");

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
                name: "HoldingTax");

            migrationBuilder.DropTable(
                name: "TaxBill");

            migrationBuilder.DropTable(
                name: "WaterBill");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TaxRate");

            migrationBuilder.DropTable(
                name: "TaxItemSetting");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Road");

            migrationBuilder.DropTable(
                name: "Upzilla");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "Municipility");

            migrationBuilder.DropTable(
                name: "ClientInfo");

            migrationBuilder.DropTable(
                name: "HoldingCategory");

            migrationBuilder.DropTable(
                name: "HoldingType");

            migrationBuilder.DropTable(
                name: "WaterRate");

            migrationBuilder.DropTable(
                name: "WaterConnection");

            migrationBuilder.DropTable(
                name: "HoldingInfo");
        }
    }
}
