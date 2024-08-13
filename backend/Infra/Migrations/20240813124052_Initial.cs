using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Stairways.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    ProfileImage = table.Column<string>(type: "text", nullable: false),
                    DoneItemsHashs = table.Column<string[]>(type: "text[]", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roadmaps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<string>(type: "text", nullable: false),
                    JsonContent = table.Column<string>(type: "text", nullable: false),
                    Meta_Description = table.Column<string>(type: "text", nullable: false),
                    Meta_ImageURL = table.Column<string>(type: "text", nullable: false),
                    Meta_Level = table.Column<int>(type: "integer", nullable: false),
                    Meta_Privacy = table.Column<int>(type: "integer", nullable: false),
                    Meta_Title = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roadmaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roadmaps_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roadmaps_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { "11c4c4af-a00f-42a9-bc49-45e4f60fd89e", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1711), "Astronomia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1712) },
                    { "1290425d-9758-4abf-b6f1-a5da81110214", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4126), "Enfermagem", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4126) },
                    { "1381ecb1-2559-4025-ab46-d135ee3b55b3", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7813), "Interdisciplinar", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7814) },
                    { "142e75cd-0428-4edb-8b13-40f16410f62b", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2684), "Botânica", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2685) },
                    { "15b21e9c-e554-426b-949d-76b0554b0a8d", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7314), "Letras", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7314) },
                    { "17fb4cc1-90af-4440-a76f-06f9d18c51c8", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5034), "Engenharia Agrícola", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5034) },
                    { "252f793a-0a98-498c-9441-801b5ff672db", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6043), "Turismo", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6044) },
                    { "25c403fa-1c6c-4954-8e15-4b3f919d0213", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2423), "Microbiologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2424) },
                    { "26761e26-07c0-442c-ac38-cff1424b26cf", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6117), "Arquitetura e Urbanismo", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6118) },
                    { "300c6359-3709-4c71-8d54-90adac1f864d", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5141), "Medicina Veterinária", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5141) },
                    { "314948c6-b84f-4d3f-a578-6e5738fa15ec", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1996), "Bioquímica", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1996) },
                    { "355845f9-9da5-4a24-86c0-7658e383dee2", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3939), "Medicina", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3939) },
                    { "38a6e765-8c78-4c5e-bf06-149b35cd8c02", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7666), "Ciência e Tecnologia Ambiental", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7666) },
                    { "3b84e5ac-27e0-47d6-82ca-e4e0991ad989", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7453), "Música", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7453) },
                    { "3ca0bc64-45a3-453e-b6ff-288c36355fad", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1567), "Física", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1567) },
                    { "400867d1-b827-4879-8dd6-7444ef591034", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5875), "Direito", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5875) },
                    { "40f109c2-6fd5-492c-be37-bad1fdd604fb", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1786), "Geociências", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1786) },
                    { "41123564-fa43-4efa-bc5b-993624f5c99a", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5387), "Ciência e Tecnologia de Alimentos", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5388) },
                    { "429749a9-d489-4d32-ac7a-292fc226eefe", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7740), "Ciência e Tecnologia dos Materiais", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7740) },
                    { "429ca40b-ecc7-429a-b7a5-16b1f96dd638", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5971), "Serviço Social", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5972) },
                    { "4609cfa4-41d2-4729-8348-880ef44c26de", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3469), "Engenharia de Materiais e Metalúrgica", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3469) },
                    { "46c57a85-710c-43a8-b3cf-f69df6d0c50c", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7380), "Artes", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7381) },
                    { "4b36d558-1a5e-4bea-91da-877357da5088", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3762), "Engenharia de Minas", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3762) },
                    { "4d23f36c-3a7f-4da4-9ee5-bcc13dac78d6", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2972), "Engenharia Civil", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2973) },
                    { "50ecfec2-cc9e-4e93-be9f-92db0c024ced", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7521), "Teatro", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7521) },
                    { "538d9bea-7744-4d0f-ba97-ce3ebb458128", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2356), "Imunologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2356) },
                    { "5691cab9-0c76-4aca-ab74-d194312d89e2", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1402), "Estatística", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1403) },
                    { "56afb885-3d8a-4d1b-b8fa-3a424fbbf064", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4297), "Saúde Coletiva", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4297) },
                    { "593d9cb9-1076-440c-afd4-2f76e9fcc316", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6715), "História", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6715) },
                    { "5cd2de6e-5d3a-4fcc-9c96-c1ab069ddeb1", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3213), "Engenharia Mecânica", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3213) },
                    { "63c92b6c-9b1a-4581-881a-be97b21ee4cd", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2141), "Farmacologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2141) },
                    { "64ebd390-8e92-4ea8-97c4-b6cc9ec2f58a", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6489), "Filosofia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6489) },
                    { "69d62521-8ad7-4fc5-a11f-46bf6e57f670", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6857), "Psicologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6857) },
                    { "6b32fd09-8d40-49c6-8ecd-3db3557d36bd", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1636), "Química", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1637) },
                    { "6ca8c11e-3017-40d9-bf70-671b7b28d0ac", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6259), "Demografia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6259) },
                    { "7370fd18-b662-47d5-9d9e-9c0f5fdf839b", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7595), "Artes Visuais", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7596) },
                    { "7720c88a-a02f-4826-a5e2-7b710fb449ab", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6186), "Planejamento Urbano e Regional", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6186) },
                    { "7c14db81-3ba9-4de2-8403-cfb7d34ec74e", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1928), "Biologia Geral", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1928) },
                    { "82f84613-4d95-4a3d-8786-6f701be101a9", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7241), "Linguística", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7241) },
                    { "844191cd-8d74-496f-86f6-88a36c8843d8", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2282), "Genética", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2282) },
                    { "88cc67e7-fbb3-4115-a76b-769c860dded2", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2597), "Parasitologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2597) },
                    { "89c01d21-caa4-4db0-93f8-106741942731", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4054), "Odontologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4055) },
                    { "9045cba9-8e28-4115-9144-b81b78f2fe0d", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4745), "Farmácia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4745) },
                    { "920ca741-0f88-4fba-9ba9-4e4be6751488", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7096), "Ciência Política", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7096) },
                    { "932d45b1-01cb-4cb7-a3ae-2edc918e27e8", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7956), "Gastronomia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7956) },
                    { "978d2192-090a-4113-bc3d-6dd3d99b5534", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2831), "Ecologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2831) },
                    { "a6a87b64-42ad-4148-b59e-93e2f656928f", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3041), "Engenharia Elétrica", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3042) },
                    { "a99de8c3-269b-4c9f-a59f-c6984001fb3b", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3285), "Engenharia Química", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3286) },
                    { "ad727508-1c98-4961-888c-11c186422e1a", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5210), "Zootecnia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5210) },
                    { "af65737d-325d-4c93-b1ef-a7d7dbc1d436", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1855), "Oceanografia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1855) },
                    { "b33ce800-eda4-4815-b1b0-6eca6c207e41", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3580), "Engenharia Sanitária", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3580) },
                    { "b436ce48-7cf3-4b58-b250-1699b67e2634", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1489), "Computação", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1490) },
                    { "b51b12ff-b7c3-41be-8afc-eefed0f95703", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4855), "Agronomia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4856) },
                    { "bbef4774-c52b-4798-a3d2-70d4577d785d", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2758), "Zoologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2759) },
                    { "c056abc1-6218-4db8-a5a4-c470916a98c7", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6787), "Geografia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6788) },
                    { "c9f38fc9-b41d-4c81-ac43-0cf274ffd771", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3868), "Engenharia de Petróleo", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3868) },
                    { "ca2aec5d-481c-40c0-b4f5-054cb70738aa", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4564), "Fonoaudiologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4565) },
                    { "cae0782e-3211-478c-b6f1-d797835f586c", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5480), "Administração", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5480) },
                    { "cb9d26af-04ee-48fb-af11-d416d31d337d", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5676), "Ciências Econômicas", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5677) },
                    { "ccf82e9f-e7a6-4244-99f0-a98cd4a6545d", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2898), "Morfologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2899) },
                    { "cd595661-3547-4010-9749-5fcb2d8a98f6", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7882), "Biotecnologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7883) },
                    { "ce75f6e0-e9a8-44b5-baa7-3ebcac8771e8", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6647), "Antropologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6647) },
                    { "d5530d22-33d6-4bc5-8065-6bc47c9d1d29", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6328), "Museologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6328) },
                    { "d96271e9-10db-41b2-810f-cddea5f98a03", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3397), "Engenharia de Produção", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3397) },
                    { "dcbdfe05-a7be-4c90-92a7-e11a60e901e8", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5749), "Comunicação", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5750) },
                    { "dd594e0e-2a2a-4956-935d-3dc63b61d483", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4368), "Nutrição", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4369) },
                    { "e0cc3efa-47f0-4532-94f2-2ea4fb513a2e", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5547), "Ciências Contábeis", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5547) },
                    { "e39ae74e-3748-418c-8a67-875fc7ad6650", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4496), "Educação Física", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4497) },
                    { "e453e2bb-e065-4c8a-81fe-2534568d4770", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1250), "Matemática", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(1276) },
                    { "e4c17478-3138-4123-b953-28dbb78ab364", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2214), "Fisiologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2214) },
                    { "e4ca2452-93f4-453a-bac0-9f1ed94a62fc", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4962), "Engenharia Florestal", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4962) },
                    { "ea8ffe8c-e46a-4f8e-bdf0-b203298a9465", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4677), "Fisioterapia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(4677) },
                    { "ee5a53c4-5878-4477-9b42-a31885e7b138", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3652), "Engenharia Nuclear", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(3652) },
                    { "f13e0030-8375-4642-9cec-56bcee59049f", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6570), "Sociologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6570) },
                    { "f1464fb3-68f6-4400-ab6e-a6121e35eb62", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7174), "Relações Internacionais", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7174) },
                    { "f40cb36d-eb31-404c-adc5-d50a93976a8d", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2073), "Biofísica", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(2073) },
                    { "f9b7f3d4-cb01-4a1b-beed-26f0046c2cd8", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5319), "Recursos Pesqueiros e Engenharia de Pesca", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(5319) },
                    { "fc0d73dd-82a3-41bb-810d-2d8a4b5e42c1", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7026), "Teologia", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(7027) },
                    { "fd11794a-8379-4014-b5cc-f24e8159a253", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6931), "Educação", new DateTime(2024, 8, 13, 12, 40, 51, 430, DateTimeKind.Utc).AddTicks(6932) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_AuthorId",
                table: "Roadmaps",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_CategoryId",
                table: "Roadmaps",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roadmaps");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
