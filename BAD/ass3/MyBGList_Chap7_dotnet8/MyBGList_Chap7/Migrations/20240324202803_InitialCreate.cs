﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBGList_Chap7.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakingGood",
                columns: table => new
                {
                    BakingGoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BgName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateProduced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakingGood", x => x.BakingGoodId);
                });

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryPlace = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "BakingGoodBatch",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    BakingGoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BakingGoodId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakingGoodBatch", x => new { x.BatchId, x.BakingGoodId });
                    table.ForeignKey(
                        name: "FK_BakingGoodBatch_BakingGood_BakingGoodId",
                        column: x => x.BakingGoodId,
                        principalTable: "BakingGood",
                        principalColumn: "BakingGoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakingGoodBatch_BakingGood_BakingGoodId1",
                        column: x => x.BakingGoodId1,
                        principalTable: "BakingGood",
                        principalColumn: "BakingGoodId");
                    table.ForeignKey(
                        name: "FK_BakingGoodBatch_Batch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batch",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderBakingGood",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BakingGoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BakingGoodId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBakingGood", x => new { x.OrderId, x.BakingGoodId });
                    table.ForeignKey(
                        name: "FK_OrderBakingGood_BakingGood_BakingGoodId",
                        column: x => x.BakingGoodId,
                        principalTable: "BakingGood",
                        principalColumn: "BakingGoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderBakingGood_BakingGood_BakingGoodId1",
                        column: x => x.BakingGoodId1,
                        principalTable: "BakingGood",
                        principalColumn: "BakingGoodId");
                    table.ForeignKey(
                        name: "FK_OrderBakingGood_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packet",
                columns: table => new
                {
                    PacketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packet", x => x.PacketId);
                    table.ForeignKey(
                        name: "FK_Packet_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatchStock",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StockId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchStock", x => new { x.BatchId, x.StockId });
                    table.ForeignKey(
                        name: "FK_BatchStock_Batch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batch",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchStock_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchStock_Stock_StockId1",
                        column: x => x.StockId1,
                        principalTable: "Stock",
                        principalColumn: "StockId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakingGoodBatch_BakingGoodId",
                table: "BakingGoodBatch",
                column: "BakingGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BakingGoodBatch_BakingGoodId1",
                table: "BakingGoodBatch",
                column: "BakingGoodId1");

            migrationBuilder.CreateIndex(
                name: "IX_BatchStock_StockId",
                table: "BatchStock",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchStock_StockId1",
                table: "BatchStock",
                column: "StockId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBakingGood_BakingGoodId",
                table: "OrderBakingGood",
                column: "BakingGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBakingGood_BakingGoodId1",
                table: "OrderBakingGood",
                column: "BakingGoodId1");

            migrationBuilder.CreateIndex(
                name: "IX_Packet_OrderId",
                table: "Packet",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakingGoodBatch");

            migrationBuilder.DropTable(
                name: "BatchStock");

            migrationBuilder.DropTable(
                name: "OrderBakingGood");

            migrationBuilder.DropTable(
                name: "Packet");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "BakingGood");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
