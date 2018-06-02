using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SystemDiagnostic.WebAPI.Migrations
{
    public partial class InitialDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsConnected = table.Column<bool>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerSystems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ComputerId = table.Column<string>(nullable: false),
                    ComputerName = table.Column<string>(nullable: true),
                    CurrentUsername = table.Column<string>(nullable: true),
                    DNSHostName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerSystems_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiskDrives",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ComputerDiskDriveId = table.Column<string>(nullable: true),
                    ComputerId = table.Column<string>(nullable: false),
                    MediaType = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SizeGB = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiskDrives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiskDrives_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotherBoards",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ComputerId = table.Column<string>(nullable: false),
                    ComputerMotherBoardId = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Product = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherBoards_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalMemories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CapacityGB = table.Column<double>(nullable: false),
                    ComputerId = table.Column<string>(nullable: false),
                    ComputerPhysicalMemoryId = table.Column<string>(nullable: false),
                    FormFactor = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Speed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalMemories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalMemories_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ComputerId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processes_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Architecture = table.Column<string>(nullable: true),
                    ClockFrequency = table.Column<int>(nullable: false),
                    ComputerId = table.Column<string>(nullable: false),
                    ComputerProcessorId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    L2CacheSize = table.Column<int>(nullable: false),
                    L3CacheSize = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NumberOfCores = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processors_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoCards",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AdapterCompatibility = table.Column<string>(nullable: true),
                    AdapterRAMGB = table.Column<double>(nullable: false),
                    ComputerId = table.Column<string>(nullable: false),
                    MaxRefreshRate = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    VideoProcessor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoCards_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessInformations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CommandLine = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ProcessId = table.Column<string>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessInformations_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessPerfomances",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ComputerProcessId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PercentCPUUsage = table.Column<int>(nullable: false),
                    ProcessId = table.Column<string>(nullable: false),
                    RamMemoryUsageMB = table.Column<int>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessPerfomances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessPerfomances_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerSystems_ComputerId",
                table: "ComputerSystems",
                column: "ComputerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiskDrives_ComputerId",
                table: "DiskDrives",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherBoards_ComputerId",
                table: "MotherBoards",
                column: "ComputerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalMemories_ComputerId",
                table: "PhysicalMemories",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_ComputerId",
                table: "Processes",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessInformations_ProcessId",
                table: "ProcessInformations",
                column: "ProcessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Processors_ComputerId",
                table: "Processors",
                column: "ComputerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessPerfomances_ProcessId",
                table: "ProcessPerfomances",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCards_ComputerId",
                table: "VideoCards",
                column: "ComputerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerSystems");

            migrationBuilder.DropTable(
                name: "DiskDrives");

            migrationBuilder.DropTable(
                name: "MotherBoards");

            migrationBuilder.DropTable(
                name: "PhysicalMemories");

            migrationBuilder.DropTable(
                name: "ProcessInformations");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "ProcessPerfomances");

            migrationBuilder.DropTable(
                name: "VideoCards");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "Computers");
        }
    }
}
