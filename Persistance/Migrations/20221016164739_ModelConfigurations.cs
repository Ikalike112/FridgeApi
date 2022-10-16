using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ModelConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54dec2f3-15bd-4309-ad43-8c0842ded3c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95471bf6-86d4-458c-9f41-db5c482e9ae5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b0f3777-e2ce-4da4-abf9-730cd4beeb6c", "adec2842-d831-4043-9cc1-1c0ea90e66ef", "User", "USER" },
                    { "195896e6-fa3e-4958-b5c8-6b1ce4ab320d", "9dac0541-f95b-4081-a624-0b8901b97acf", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("3bfd5e1c-8407-4d3e-b77b-30427468656e"), "Samsung RB34A7B4F35/WT", 2020 },
                    { new Guid("d957b9be-b351-4629-a332-4841851aa395"), "LG DoorCooling+ GA-B509CQTL", 2020 },
                    { new Guid("b12741d6-4ea0-4ce4-8a4e-3be45767b928"), "Electrolux KNT2LF18S", 2019 },
                    { new Guid("b0463f44-af0c-434f-9667-c3bf6c9f8a93"), "ATLANT ХМ 4307-000", 2017 },
                    { new Guid("2767f531-6eab-492b-99fa-839b826552e9"), "Indesit ITR 5200 W", 2020 }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "FridgeModelId", "Name", "OwnerName" },
                values: new object[] { new Guid("78f6f534-8b95-44b7-88e3-6c395c53207e"), new Guid("2767f531-6eab-492b-99fa-839b826552e9"), "Indesit Roma", "Roman" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("5d25ffb3-2f6b-4911-974d-a35f34ca7014"), 1, "https://localhost:5001/Images/sourcream.jpg", "Sour cream" },
                    { new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"), 1, "https://localhost:5001/Images/curd.webp", "Curd" },
                    { new Guid("60aa9097-9f29-4f08-b0bd-b07a68b9da43"), 1, "https://localhost:5001/Images/bread.jpg", "Bread" },
                    { new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"), 5, "https://localhost:5001/Images/cucumbers.jpg", "Сucumbers" },
                    { new Guid("c30b9ac9-bdba-4edc-aa9c-ad3dda4814ae"), 4, "https://localhost:5001/Images/apples.jpg", "Apples" },
                    { new Guid("1b098f23-f8d9-4f7c-9385-20d620e176b6"), 1, "https://localhost:5001/Images/buckwheat.webp", "Buckwheat" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("681dd588-f9fd-4cf5-93c6-028adaa79f87"), new Guid("78f6f534-8b95-44b7-88e3-6c395c53207e"), new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"), 7 },
                    { new Guid("5c23a099-37f7-45e3-88f7-80119eb8a4f0"), new Guid("78f6f534-8b95-44b7-88e3-6c395c53207e"), new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"), 3 },
                    { new Guid("e73af1a7-0f1a-4762-8d81-4fe406fa353b"), new Guid("78f6f534-8b95-44b7-88e3-6c395c53207e"), new Guid("60aa9097-9f29-4f08-b0bd-b07a68b9da43"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "FridgeModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("72e0a604-0877-4510-9701-f3b29ead9d9d"), new Guid("d957b9be-b351-4629-a332-4841851aa395"), "Lg Inessa", "Inessa" },
                    { new Guid("7870e84d-0f97-4196-bed7-19bd8ff40a63"), new Guid("b12741d6-4ea0-4ce4-8a4e-3be45767b928"), "Electrolux Dima", "Dima" },
                    { new Guid("557d35ef-ab80-4e17-a96c-2b65cf3dd7bf"), new Guid("b12741d6-4ea0-4ce4-8a4e-3be45767b928"), "Electrolux Sasha", "Sasha" },
                    { new Guid("b97c170d-a6bf-4f26-8231-28d9025bf3ad"), new Guid("b0463f44-af0c-434f-9667-c3bf6c9f8a93"), "ATLANT Vlad", "Vlad" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("3d0ee611-17e8-43b6-9ceb-ff117eaaa79c"), new Guid("72e0a604-0877-4510-9701-f3b29ead9d9d"), new Guid("1b098f23-f8d9-4f7c-9385-20d620e176b6"), 3 },
                    { new Guid("52956ec3-022e-49de-b2c9-f2229478bbd8"), new Guid("72e0a604-0877-4510-9701-f3b29ead9d9d"), new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"), 7 },
                    { new Guid("ffd7f7ce-dd5d-4610-93a9-a57c1c14b2df"), new Guid("72e0a604-0877-4510-9701-f3b29ead9d9d"), new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"), 3 },
                    { new Guid("e0e12e03-2f7c-4a49-8b5c-602ce5786f28"), new Guid("7870e84d-0f97-4196-bed7-19bd8ff40a63"), new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"), 3 },
                    { new Guid("ce9cca0d-44af-4ed0-94e4-ada2281d3cda"), new Guid("7870e84d-0f97-4196-bed7-19bd8ff40a63"), new Guid("60aa9097-9f29-4f08-b0bd-b07a68b9da43"), 1 },
                    { new Guid("cf6e9d69-3eb9-4f73-ac12-25a09d016a6c"), new Guid("7870e84d-0f97-4196-bed7-19bd8ff40a63"), new Guid("c30b9ac9-bdba-4edc-aa9c-ad3dda4814ae"), 15 },
                    { new Guid("05da7993-8bc2-4a92-a1c7-c282af54def9"), new Guid("557d35ef-ab80-4e17-a96c-2b65cf3dd7bf"), new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"), 1 },
                    { new Guid("ec994091-00a1-41f5-bf8f-6abe3b4863a3"), new Guid("557d35ef-ab80-4e17-a96c-2b65cf3dd7bf"), new Guid("5d25ffb3-2f6b-4911-974d-a35f34ca7014"), 2 },
                    { new Guid("14e4c28d-4ed9-41cd-95eb-f66f8c9bfe60"), new Guid("557d35ef-ab80-4e17-a96c-2b65cf3dd7bf"), new Guid("c30b9ac9-bdba-4edc-aa9c-ad3dda4814ae"), 0 },
                    { new Guid("bffdc898-d59f-485d-a748-90df10a1e8c9"), new Guid("b97c170d-a6bf-4f26-8231-28d9025bf3ad"), new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"), 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "195896e6-fa3e-4958-b5c8-6b1ce4ab320d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b0f3777-e2ce-4da4-abf9-730cd4beeb6c");

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("2767f531-6eab-492b-99fa-839b826552e9"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("3bfd5e1c-8407-4d3e-b77b-30427468656e"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("05da7993-8bc2-4a92-a1c7-c282af54def9"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("14e4c28d-4ed9-41cd-95eb-f66f8c9bfe60"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("3d0ee611-17e8-43b6-9ceb-ff117eaaa79c"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("52956ec3-022e-49de-b2c9-f2229478bbd8"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5c23a099-37f7-45e3-88f7-80119eb8a4f0"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("681dd588-f9fd-4cf5-93c6-028adaa79f87"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("bffdc898-d59f-485d-a748-90df10a1e8c9"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ce9cca0d-44af-4ed0-94e4-ada2281d3cda"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("cf6e9d69-3eb9-4f73-ac12-25a09d016a6c"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("e0e12e03-2f7c-4a49-8b5c-602ce5786f28"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("e73af1a7-0f1a-4762-8d81-4fe406fa353b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ec994091-00a1-41f5-bf8f-6abe3b4863a3"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ffd7f7ce-dd5d-4610-93a9-a57c1c14b2df"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("557d35ef-ab80-4e17-a96c-2b65cf3dd7bf"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("72e0a604-0877-4510-9701-f3b29ead9d9d"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("7870e84d-0f97-4196-bed7-19bd8ff40a63"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("78f6f534-8b95-44b7-88e3-6c395c53207e"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("b97c170d-a6bf-4f26-8231-28d9025bf3ad"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b098f23-f8d9-4f7c-9385-20d620e176b6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5d25ffb3-2f6b-4911-974d-a35f34ca7014"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60aa9097-9f29-4f08-b0bd-b07a68b9da43"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c30b9ac9-bdba-4edc-aa9c-ad3dda4814ae"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("b0463f44-af0c-434f-9667-c3bf6c9f8a93"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("b12741d6-4ea0-4ce4-8a4e-3be45767b928"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("d957b9be-b351-4629-a332-4841851aa395"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54dec2f3-15bd-4309-ad43-8c0842ded3c5", "57ed9028-9ff0-4de3-ac26-5d93fc39b8f8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95471bf6-86d4-458c-9f41-db5c482e9ae5", "a1d15e86-1e1a-4778-b5f8-24d4cb61a033", "Administrator", "ADMINISTRATOR" });
        }
    }
}
