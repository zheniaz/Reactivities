using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fix1Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityAttendees",
                table: "ActivityAttendees");

            migrationBuilder.DropIndex(
                name: "IX_ActivityAttendees_ActivityId",
                table: "ActivityAttendees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityAttendees",
                table: "ActivityAttendees",
                columns: new[] { "ActivityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttendees_UserId",
                table: "ActivityAttendees",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityAttendees",
                table: "ActivityAttendees");

            migrationBuilder.DropIndex(
                name: "IX_ActivityAttendees_UserId",
                table: "ActivityAttendees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityAttendees",
                table: "ActivityAttendees",
                columns: new[] { "UserId", "ActivityId" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttendees_ActivityId",
                table: "ActivityAttendees",
                column: "ActivityId");
        }
    }
}
