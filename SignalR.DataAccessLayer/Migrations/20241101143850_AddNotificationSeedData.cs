using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class AddNotificationSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "Date", "Description", "Icon", "Status", "Type" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yeni Bir Kullanıcı Eklendi", "la la-user-plus", false, "notif-icon notif-primary" });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "Date", "Description", "Icon", "Status", "Type" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yorum Yapıldı", "la la-comment", false, "notif-icon notif-success" });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "Date", "Description", "Icon", "Status", "Type" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı Beğendi", "la la-heart", false, "notif-icon notif-danger" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 3);
        }
    }
}
