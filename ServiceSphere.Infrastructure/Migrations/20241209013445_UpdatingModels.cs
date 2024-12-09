using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceSphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Events_EventId",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "ServiceSupplier");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Guests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SupplierId",
                table: "Services",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "OrganizerId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Events_EventId",
                table: "Guests",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Suppliers_SupplierId",
                table: "Services",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Events_EventId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Suppliers_SupplierId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_SupplierId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Guests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceSupplier",
                columns: table => new
                {
                    ServicesServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    SuppliersSupplierId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSupplier", x => new { x.ServicesServiceId, x.SuppliersSupplierId });
                    table.ForeignKey(
                        name: "FK_ServiceSupplier_Services_ServicesServiceId",
                        column: x => x.ServicesServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSupplier_Suppliers_SuppliersSupplierId",
                        column: x => x.SuppliersSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSupplier_SuppliersSupplierId",
                table: "ServiceSupplier",
                column: "SuppliersSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "OrganizerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Events_EventId",
                table: "Guests",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
