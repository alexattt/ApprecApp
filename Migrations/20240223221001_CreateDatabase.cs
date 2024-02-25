using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MsgDeliveryFailReporting.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    V = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Senders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusV = table.Column<string>(name: "Status_V", type: "nvarchar(max)", nullable: true),
                    StatusDN = table.Column<string>(name: "Status_DN", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRecs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MsgTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MIGversion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftwareName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftwareVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRecs_MessageTypes_MsgTypeId",
                        column: x => x.MsgTypeId,
                        principalTable: "MessageTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppRecs_Receivers_ReceiverID",
                        column: x => x.ReceiverID,
                        principalTable: "Receivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRecs_Senders_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Senders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRecs_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrV = table.Column<string>(name: "Err_V", type: "nvarchar(max)", nullable: true),
                    ErrS = table.Column<string>(name: "Err_S", type: "nvarchar(max)", nullable: true),
                    ErrDN = table.Column<string>(name: "Err_DN", type: "nvarchar(max)", nullable: true),
                    ErrOT = table.Column<string>(name: "Err_OT", type: "nvarchar(max)", nullable: true),
                    AppRecId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Errors_AppRecs_AppRecId",
                        column: x => x.AppRecId,
                        principalTable: "AppRecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRecs_MsgTypeId",
                table: "AppRecs",
                column: "MsgTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRecs_ReceiverID",
                table: "AppRecs",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_AppRecs_SenderId",
                table: "AppRecs",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRecs_StatusId",
                table: "AppRecs",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Errors_AppRecId",
                table: "Errors",
                column: "AppRecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "AppRecs");

            migrationBuilder.DropTable(
                name: "MessageTypes");

            migrationBuilder.DropTable(
                name: "Receivers");

            migrationBuilder.DropTable(
                name: "Senders");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
