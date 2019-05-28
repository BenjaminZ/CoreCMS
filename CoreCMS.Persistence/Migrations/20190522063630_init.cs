using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCMS.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMenus",
                columns: table => new
                {
                    AdminMenuID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParentMenuID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: true),
                    IconPath = table.Column<string>(maxLength: 128, nullable: true),
                    Url = table.Column<string>(maxLength: 128, nullable: true),
                    OrderNumber = table.Column<int>(nullable: false),
                    OperationLevel = table.Column<string>(maxLength: 256, nullable: true),
                    IsDisplayed = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDefault = table.Column<bool>(nullable: false, defaultValue: false),
                    AddedBy = table.Column<int>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMenus", x => x.AdminMenuID);
                    table.ForeignKey(
                        name: "FK_ParentMenus_ChildMenus",
                        column: x => x.ParentMenuID,
                        principalTable: "AdminMenus",
                        principalColumn: "AdminMenuID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    ArticleCategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(maxLength: 128, nullable: false),
                    ParentCategoryID = table.Column<int>(nullable: true),
                    Depth = table.Column<int>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    IconPath = table.Column<string>(maxLength: 128, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 128, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 256, nullable: true),
                    SeoDescription = table.Column<string>(maxLength: 512, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.ArticleCategoryID);
                    table.ForeignKey(
                        name: "FK_ParentCategories_ChildCategories",
                        column: x => x.ParentCategoryID,
                        principalTable: "ArticleCategories",
                        principalColumn: "ArticleCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerRoles",
                columns: table => new
                {
                    ManagerRoleID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManagerRoleName = table.Column<string>(maxLength: 64, nullable: false),
                    ManagerRoleType = table.Column<int>(nullable: false, defaultValue: 2)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsSystemDefault = table.Column<bool>(nullable: false, defaultValue: false),
                    AddedBy = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerRoles", x => x.ManagerRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleCategoryID = table.Column<int>(nullable: false),
                    Title = table.Column<int>(maxLength: 128, nullable: false),
                    PicturePath = table.Column<int>(maxLength: 128, nullable: false),
                    Content = table.Column<string>(type: "Text", nullable: true),
                    ViewCount = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<int>(nullable: false),
                    Author = table.Column<string>(maxLength: 64, nullable: true),
                    Origin = table.Column<string>(maxLength: 128, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 128, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 256, nullable: true),
                    SeoDescription = table.Column<string>(maxLength: 512, nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    IsPinned = table.Column<bool>(nullable: false, defaultValue: false),
                    IsInCarousel = table.Column<bool>(nullable: false, defaultValue: false),
                    IsHot = table.Column<bool>(nullable: false, defaultValue: false),
                    IsPublished = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories",
                        column: x => x.ArticleCategoryID,
                        principalTable: "ArticleCategories",
                        principalColumn: "ArticleCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManagerRoleID = table.Column<int>(nullable: false),
                    AccountName = table.Column<string>(maxLength: 32, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    HeadShot = table.Column<string>(maxLength: 256, nullable: true),
                    NickName = table.Column<string>(maxLength: 32, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 32, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    LoginCount = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastLoginIp = table.Column<string>(maxLength: 64, nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsLocked = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerID);
                    table.ForeignKey(
                        name: "FK_Managers_ManagerRoles",
                        column: x => x.ManagerRoleID,
                        principalTable: "ManagerRoles",
                        principalColumn: "ManagerRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleAccesses",
                columns: table => new
                {
                    RoleAccessID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManagerRoleID = table.Column<int>(nullable: false),
                    AdminMenuID = table.Column<int>(nullable: false),
                    AccessType = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccesses", x => x.RoleAccessID);
                    table.ForeignKey(
                        name: "FK_RoleAccesses_AdminMenus",
                        column: x => x.AdminMenuID,
                        principalTable: "AdminMenus",
                        principalColumn: "AdminMenuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAccesses_ManagerRoles",
                        column: x => x.ManagerRoleID,
                        principalTable: "ManagerRoles",
                        principalColumn: "ManagerRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationLogs",
                columns: table => new
                {
                    LogID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OperationType = table.Column<string>(maxLength: 32, nullable: true),
                    OperatorID = table.Column<int>(nullable: false),
                    OperateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    OperatorIp = table.Column<string>(maxLength: 64, nullable: true),
                    Note = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationLogs", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_OperationLogs_Managers",
                        column: x => x.OperatorID,
                        principalTable: "Managers",
                        principalColumn: "ManagerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminMenus_ParentMenuID",
                table: "AdminMenus",
                column: "ParentMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ParentCategoryID",
                table: "ArticleCategories",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryID",
                table: "Articles",
                column: "ArticleCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_ManagerRoleID",
                table: "Managers",
                column: "ManagerRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_OperationLogs_OperatorID",
                table: "OperationLogs",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccesses_AdminMenuID",
                table: "RoleAccesses",
                column: "AdminMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccesses_ManagerRoleID",
                table: "RoleAccesses",
                column: "ManagerRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "OperationLogs");

            migrationBuilder.DropTable(
                name: "RoleAccesses");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "AdminMenus");

            migrationBuilder.DropTable(
                name: "ManagerRoles");
        }
    }
}
