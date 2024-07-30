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
                    { "01377241-e04c-4150-bfe6-95a83e1bbd81", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4122), "Engenharia Agrícola", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4122) },
                    { "02b43037-7c83-4bd3-a02f-6c0aa349f076", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2450), "Engenharia de Produção", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2450) },
                    { "0470a27b-12ae-4695-94b6-13a4e6ffb378", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5272), "Arquitetura e Urbanismo", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5273) },
                    { "05f0aaaf-ef62-4301-ae37-af976134c621", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3850), "Farmácia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3851) },
                    { "0b24d54f-a93a-4d5e-a78c-d764f6061b09", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1608), "Parasitologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1609) },
                    { "131327a8-791c-4caa-98b5-910172bf1745", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1201), "Fisiologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1201) },
                    { "26bb7096-e13c-4f08-a835-9c70bbfaa603", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7468), "Interdisciplinar", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7468) },
                    { "3308cadb-acdb-4f63-9956-73affaca9e05", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4391), "Recursos Pesqueiros e Engenharia de Pesca", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4391) },
                    { "34e432a1-55c6-4e09-9eb5-b4cbb2c5cc9f", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6036), "Geografia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6036) },
                    { "37b16a5c-2be0-4679-a730-bc980d2a0894", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4193), "Medicina Veterinária", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4194) },
                    { "3bcdfc9b-e365-4af1-82e7-dffa47a6f0f4", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5967), "História", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5968) },
                    { "40597f88-887c-4bd4-9bee-d39f293add4a", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5807), "Antropologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5808) },
                    { "428a03e4-5f61-4c01-82bb-c1c81cbd04a0", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6248), "Educação", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6248) },
                    { "46b5cd15-5b19-4e52-bfa5-e4cfed245cc1", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7026), "Artes Visuais", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7026) },
                    { "476bf185-d75e-4cab-9634-366da91e2118", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4617), "Administração", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4618) },
                    { "48e93af0-72f9-4247-88ab-2a57fc08da0c", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(964), "Bioquímica", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(965) },
                    { "499d7803-45c3-4db6-b410-bf07da8629e3", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4731), "Ciências Contábeis", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4731) },
                    { "49d5fe8e-554d-404c-99d9-896083eb1071", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2745), "Engenharia Nuclear", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2745) },
                    { "4c707630-ea14-4417-9535-3f0977bbc9e9", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(353), "Física", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(354) },
                    { "503bcdde-bcb6-48b4-8ce6-b0738f88a84e", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4546), "Ciência e Tecnologia de Alimentos", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4546) },
                    { "518d231d-ff0e-459e-bdec-2ca0260404f7", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3735), "Fisioterapia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3735) },
                    { "52320464-45df-4581-8831-d61d18d612c1", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6955), "Teatro", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6956) },
                    { "5272dd5f-732f-4821-81c8-801b5bcba081", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5613), "Filosofia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5613) },
                    { "54f0268a-50e2-4ec2-8721-d5e1025508bd", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7150), "Ciência e Tecnologia Ambiental", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7151) },
                    { "5558befa-5f4c-4aa1-85e6-12027aff088e", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6864), "Música", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6865) },
                    { "58c8a18a-abdf-4fb0-8943-27f8cf8f53d2", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5453), "Demografia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5453) },
                    { "59d12bfe-a9dc-45f5-b9dd-3e434ff327e7", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2614), "Engenharia Sanitária", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2614) },
                    { "5aa6bf5f-fa30-4b2c-b033-ce93f28e9abb", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7326), "Ciência e Tecnologia dos Materiais", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7328) },
                    { "5ff2ef20-63b6-4d02-9140-fba02274b050", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3258), "Enfermagem", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3259) },
                    { "64a150aa-9c7f-40e0-95a4-964ef9bce46a", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(81), "Estatística", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(81) },
                    { "6599a041-6d89-4a53-87d9-b6be3bba235f", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6686), "Letras", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6686) },
                    { "69abc5c0-cb3a-40dc-a598-42c9405b5258", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3327), "Saúde Coletiva", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3328) },
                    { "6a280a7f-416c-40a3-8974-b88bfdfefe01", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3663), "Fonoaudiologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3663) },
                    { "72e05866-208f-4f58-b258-feed8aff4742", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1413), "Imunologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1413) },
                    { "776fd232-5352-451f-affa-46c9d04503ca", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2085), "Engenharia Civil", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2085) },
                    { "7b043772-e42c-4f8e-ae23-ae75f932cb8e", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4909), "Comunicação", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4910) },
                    { "811d64a1-7653-4ee8-b5fd-be5c32478317", new DateTime(2024, 7, 30, 18, 16, 49, 417, DateTimeKind.Utc).AddTicks(9980), "Matemática", new DateTime(2024, 7, 30, 18, 16, 49, 417, DateTimeKind.Utc).AddTicks(9983) },
                    { "845a441b-ab5d-4201-b484-1968b6baae63", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(465), "Química", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(465) },
                    { "8767339b-d401-4b2d-b27d-6ec4dc00e2ee", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5087), "Serviço Social", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5087) },
                    { "8c2e1094-4a8d-44fd-84b3-b922dd19d3fe", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6140), "Psicologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6141) },
                    { "8e9d2607-2b29-4db3-9ee2-3e66dd8d9492", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6501), "Relações Internacionais", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6502) },
                    { "8fdec82d-713b-4426-a992-52d6b653fb90", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(549), "Astronomia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(550) },
                    { "942ee7c6-52ab-433d-a751-2c3d86a6c432", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1903), "Ecologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1904) },
                    { "957bd779-e808-47fc-9581-3826eaedc645", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(663), "Geociências", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(663) },
                    { "965f6972-4aa5-4189-bfc7-6b93da6c0fd3", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6430), "Ciência Política", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6430) },
                    { "97a36b63-161f-4b9d-8542-eadecc360bff", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2273), "Engenharia Mecânica", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2274) },
                    { "9d84201a-fea2-4ced-8e8e-8088f576e6d9", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1131), "Farmacologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1131) },
                    { "9fdae4a1-eaee-4947-9fd8-6b0b0aee06ff", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7598), "Biotecnologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(7598) },
                    { "a0715523-cac3-49f7-a36b-ebe8527500e5", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4978), "Direito", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4979) },
                    { "a2336a01-11bd-494c-bc7a-b89e7fc8f890", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1538), "Microbiologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1538) },
                    { "a342b53e-c1c0-49f5-9143-3ab46849bb74", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5544), "Museologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5545) },
                    { "a3908e72-9534-4562-a953-fe86a11733ec", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5382), "Planejamento Urbano e Regional", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5382) },
                    { "a43c1e59-b791-4739-baba-1259f92a9db7", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2380), "Engenharia Química", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2381) },
                    { "a470958a-f165-41f8-a200-63be0642595f", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2944), "Engenharia de Petróleo", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2944) },
                    { "a47a646a-3c15-4186-83d7-9c995c633ada", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3150), "Odontologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3151) },
                    { "a6e6a3d6-4087-420d-a3d5-c6aa85c22cb9", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1036), "Biofísica", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1037) },
                    { "a777c4c0-6a7b-4539-bdfc-89b6037207b8", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6319), "Teologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6319) },
                    { "a7c9d890-ebe3-4ee0-845a-b70ce1e88049", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2545), "Engenharia de Materiais e Metalúrgica", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2545) },
                    { "a9258565-fe65-45c2-b0a5-475509fb8316", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2198), "Engenharia Elétrica", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2199) },
                    { "ac0b11a9-479c-4c6f-9a74-8de6a466f4cf", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3919), "Agronomia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3919) },
                    { "b8ddb18a-a40d-4783-a2bb-38819da58644", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4318), "Zootecnia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4318) },
                    { "b96e1fbe-12ff-4654-aa28-a6b7c96389b2", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(280), "Computação", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(280) },
                    { "c730c1b0-c260-4f29-9c8a-96a7feda0a76", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1719), "Botânica", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1720) },
                    { "c9607f68-daa5-4da2-9297-e53d5b525df4", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2010), "Morfologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2011) },
                    { "cb4ad5ca-ab8a-4903-ae3b-3277c0d280f6", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6611), "Linguística", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6611) },
                    { "ce472bca-76a4-49bb-a1d1-1b969abd00d5", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3507), "Educação Física", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3507) },
                    { "cec599d6-a5cf-4225-90a0-9958f5a76410", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6794), "Artes", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(6794) },
                    { "d2b322b9-d156-4a73-a8dc-61731da57d97", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5199), "Turismo", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5199) },
                    { "d439e9a3-b2d5-4b4b-a52f-3a36a0b61720", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5738), "Sociologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(5738) },
                    { "d9bbabf1-1f4e-4c8c-9ae5-78b78dc7d75c", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3075), "Medicina", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3076) },
                    { "db9dd922-9b11-479c-8822-57377594ffb4", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1830), "Zoologia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1831) },
                    { "df8de6d6-1abb-425a-86ae-de9d7695c719", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(856), "Biologia Geral", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(857) },
                    { "e09e0575-d718-4c4f-bb28-1a2556d133d1", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3436), "Nutrição", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(3436) },
                    { "e9e313d6-c615-4862-b82f-a0b5b1187df0", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1341), "Genética", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(1341) },
                    { "ec1e7f90-0e12-4795-a1dd-9dc6d66e96c2", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4798), "Ciências Econômicas", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4799) },
                    { "ecebd8c2-20ff-41bf-9bdd-98f340bfd6c4", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2871), "Engenharia de Minas", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(2872) },
                    { "f02eaa3c-8db5-4294-b359-23f1a4fd4dbb", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(781), "Oceanografia", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(781) },
                    { "f08a5b8f-b936-4eba-aebd-6e11c8fa80d0", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4030), "Engenharia Florestal", new DateTime(2024, 7, 30, 18, 16, 49, 418, DateTimeKind.Utc).AddTicks(4030) }
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
