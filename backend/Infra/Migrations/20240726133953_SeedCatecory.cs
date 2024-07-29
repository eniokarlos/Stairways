using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Stairways.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedCatecory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { "01f6ba62-ff48-488b-be73-9539c2281473", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7065), "Teatro", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7066) },
                    { "0c5e1042-9379-4a2d-a6e4-5754f2cc01f7", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3602), "Odontologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3602) },
                    { "0c8aa167-f9f3-44f3-a8a2-b5058023ca93", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1004), "Astronomia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1005) },
                    { "100166b1-5bf4-4218-98a5-6bba7aea1331", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5733), "Museologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5733) },
                    { "18337799-f7e1-45ee-820b-c6f2f1b51112", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7458), "Biotecnologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7459) },
                    { "19b7fb1f-16a1-469f-93d7-b9e74233d44e", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1411), "Bioquímica", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1411) },
                    { "19da0f5c-bd8e-4c90-a7cb-eceeddc28fcb", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6482), "Teologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6482) },
                    { "1b02a49b-aea9-47e2-b032-d2f585a3a0ce", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3285), "Engenharia Nuclear", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3286) },
                    { "203d8e68-2eec-4ed7-81dd-c9ade22434c7", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7314), "Ciência e Tecnologia dos Materiais", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7315) },
                    { "21a87a8a-a227-4120-8121-2db76ffa3e48", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3700), "Enfermagem", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3701) },
                    { "277d1cfc-c913-4bc6-895f-2d09fa6aa118", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1075), "Geociências", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1076) },
                    { "2a441f16-d1fb-450d-9be1-fab7509c7081", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3219), "Engenharia Sanitária", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3220) },
                    { "2f5f1861-691f-4c36-91a8-fc7bb394008c", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5827), "Filosofia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5828) },
                    { "30c5af51-ec55-4457-933f-8e8f712eef84", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3123), "Engenharia de Materiais e Metalúrgica", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3124) },
                    { "37e3f0ef-c61d-47da-bd70-5569a119fdde", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2886), "Engenharia Mecânica", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2886) },
                    { "4479de5a-bb10-48b7-bbda-c58a3620919e", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(638), "Estatística", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(638) },
                    { "450ce619-88de-4087-ad3b-16c90cad86aa", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2658), "Engenharia Civil", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2658) },
                    { "460d2a1a-6516-467b-a11f-67663030d51b", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2065), "Microbiologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2065) },
                    { "4771ea8c-e46b-41ad-a7fb-42ec82abac5f", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5100), "Comunicação", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5100) },
                    { "4855d74d-a10b-4437-9686-e561e0545c69", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7158), "Artes Visuais", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7158) },
                    { "4e8adcb0-70bc-4ce3-8de2-daad868336f3", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5984), "Antropologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5985) },
                    { "507cc554-894d-4dec-b0da-fe80a89ce5b7", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2590), "Morfologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2590) },
                    { "5527ce9d-30cb-4fba-ad3a-37a5f2786a96", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6049), "História", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6049) },
                    { "5621d3a8-b0fd-4533-9071-e297c9519a75", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6589), "Ciência Política", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6589) },
                    { "5d3a7140-58c1-409c-8273-9a0e77e08b65", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6744), "Linguística", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6744) },
                    { "631388bc-6a76-408c-be70-913e7368aaa3", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(829), "Física", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(829) },
                    { "699f58fd-e1fb-41ac-9711-e02088095dd2", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3941), "Educação Física", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3942) },
                    { "6b7df305-50d9-4e19-b60d-8d9e3bd204d8", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2952), "Engenharia Química", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2952) },
                    { "7e817157-26c6-4fd3-99ca-6454aeeb1f83", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4005), "Fonoaudiologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4006) },
                    { "7eba93e1-29d0-48d7-bf7e-2c4c3e7ad21a", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(721), "Computação", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(722) },
                    { "82061c88-0bc1-4007-a60d-6a9961a2ad6e", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4111), "Fisioterapia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4111) },
                    { "84545f76-3ecb-4d81-9b7a-0ee1356e4938", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5574), "Planejamento Urbano e Regional", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5574) },
                    { "92c0916e-a680-42b3-8932-a8e04b35c601", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6680), "Relações Internacionais", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6680) },
                    { "9438f6ad-9f7f-4fca-87f7-caa7990c925e", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1997), "Imunologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1998) },
                    { "9526b72c-b73d-421b-9efb-24ca1cd581e0", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4179), "Farmácia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4179) },
                    { "966d296e-0a1c-41ec-863d-7e3f0de48c9c", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4778), "Ciência e Tecnologia de Alimentos", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4778) },
                    { "999cacc8-76c8-4d67-9c00-df3f4f0545f9", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2402), "Ecologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2402) },
                    { "99ddbd2d-d2db-4fe0-80be-191c821c5f00", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1205), "Oceanografia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1205) },
                    { "9a693f21-0659-4b4b-aeaa-a4d612f75077", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1530), "Biofísica", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1531) },
                    { "9b74c11f-4658-4670-a7ad-2d2a8832d9a1", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1836), "Fisiologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1837) },
                    { "9dce7f8d-6f13-460c-aba6-0a8e99c149be", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3795), "Saúde Coletiva", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3795) },
                    { "9f98d95e-d65a-477a-b138-c8e6fa04c836", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(901), "Química", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(901) },
                    { "a3d9c3b5-732e-4ff1-b260-216111e1ed4f", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1903), "Genética", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1903) },
                    { "a676a7db-8f74-4e0d-b52a-7a6703e903df", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4712), "Recursos Pesqueiros e Engenharia de Pesca", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4712) },
                    { "a73c179c-f5e3-4e2e-9709-445802d8384b", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2179), "Parasitologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2179) },
                    { "a7c6344e-8443-4859-b990-58a536cc1348", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6903), "Artes", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6903) },
                    { "ad3c5d61-db6c-4b45-9d15-2276660411eb", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3379), "Engenharia de Minas", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3379) },
                    { "bb1e5d5a-79b8-4fae-b497-7e72351d2c8f", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6266), "Psicologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6266) },
                    { "c551589f-0a15-4711-8d0a-5fb6ae63bf53", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2244), "Botânica", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2244) },
                    { "c61e7138-1416-4a26-b5b3-81923bcfc0fb", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4361), "Engenharia Florestal", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4361) },
                    { "ce0e8bbd-e145-4f3e-9178-23edb0da0d97", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5455), "Arquitetura e Urbanismo", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5455) },
                    { "ceb4199a-6a22-4acb-a61a-68183c253a05", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3059), "Engenharia de Produção", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3059) },
                    { "cfa6dd2c-3a11-4da8-9d30-fb2e13989557", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4926), "Ciências Contábeis", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4926) },
                    { "cfe5c332-e060-46db-af7b-9053724f72ef", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6196), "Geografia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6196) },
                    { "d43c2239-1c0b-4304-b40a-4cff6581c79d", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5668), "Demografia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5668) },
                    { "d47cdaad-f85a-4261-bfaa-a17e90447d06", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4518), "Medicina Veterinária", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4518) },
                    { "d61704ea-db19-416b-94b4-8d4b84b0c8c3", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1276), "Biologia Geral", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1276) },
                    { "d6ade87b-b4f6-484a-b8c9-6785c9a6c30e", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5226), "Direito", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5227) },
                    { "d79f3777-28bb-4c86-896b-53e36e593a64", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4297), "Agronomia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4297) },
                    { "d7d42c18-1ac6-4b40-a0fa-94d27ec83288", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1603), "Farmacologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(1603) },
                    { "d8f424d2-c525-4c38-be2b-9ff0d1ec9fd5", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7221), "Ciência e Tecnologia Ambiental", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7221) },
                    { "df0206bc-ccdb-4694-ab56-9114e2c6f22e", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4861), "Administração", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4862) },
                    { "df5adb8a-76ac-4143-a7e5-97b329e04001", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6839), "Letras", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6839) },
                    { "e21ab050-4043-4da1-86a9-48618e744976", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3442), "Engenharia de Petróleo", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3443) },
                    { "e5a85dc6-b385-4d1e-ace8-35ca4e600788", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2338), "Zoologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2338) },
                    { "e869be2a-d288-41c2-acdb-2de75291d843", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7378), "Interdisciplinar", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7378) },
                    { "e8da4567-3a52-430b-a4c2-d62bfcef0a31", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5891), "Sociologia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5892) },
                    { "ea71c6d7-6a08-4679-8c07-c672af04927a", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6414), "Educação", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(6415) },
                    { "ea97ef4f-da47-4ef2-8a7f-e44c91db9fbf", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5391), "Turismo", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5392) },
                    { "ed68d4e1-dba7-4c32-a652-41e0d4e9b6f2", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7000), "Música", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(7001) },
                    { "f4bb6e52-6052-4587-aa44-a2d16d86b038", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5035), "Ciências Econômicas", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5036) },
                    { "f4c3e027-932b-4d09-905e-9f8dd328b9d1", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4454), "Engenharia Agrícola", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4454) },
                    { "f6c430cf-65e0-492a-8739-5998dd8056a8", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5289), "Serviço Social", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(5289) },
                    { "fa1dc71f-bff0-476b-b7c2-2d62ea274c6d", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(496), "Matemática", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(498) },
                    { "fbef1515-bceb-4b43-a6e6-ccdc9c7f8884", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3539), "Medicina", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3539) },
                    { "fce432c4-bbcc-4861-8b8a-b4211796082d", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4612), "Zootecnia", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(4613) },
                    { "fd35d6f2-1b61-4685-9480-44f609f5b8f9", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3859), "Nutrição", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(3860) },
                    { "ff743115-7c2d-4b23-900b-7af062379a42", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2743), "Engenharia Elétrica", new DateTime(2024, 7, 26, 13, 39, 53, 18, DateTimeKind.Utc).AddTicks(2743) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "01f6ba62-ff48-488b-be73-9539c2281473");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "0c5e1042-9379-4a2d-a6e4-5754f2cc01f7");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "0c8aa167-f9f3-44f3-a8a2-b5058023ca93");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "100166b1-5bf4-4218-98a5-6bba7aea1331");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "18337799-f7e1-45ee-820b-c6f2f1b51112");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "19b7fb1f-16a1-469f-93d7-b9e74233d44e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "19da0f5c-bd8e-4c90-a7cb-eceeddc28fcb");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1b02a49b-aea9-47e2-b032-d2f585a3a0ce");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "203d8e68-2eec-4ed7-81dd-c9ade22434c7");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "21a87a8a-a227-4120-8121-2db76ffa3e48");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "277d1cfc-c913-4bc6-895f-2d09fa6aa118");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2a441f16-d1fb-450d-9be1-fab7509c7081");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2f5f1861-691f-4c36-91a8-fc7bb394008c");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "30c5af51-ec55-4457-933f-8e8f712eef84");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "37e3f0ef-c61d-47da-bd70-5569a119fdde");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4479de5a-bb10-48b7-bbda-c58a3620919e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "450ce619-88de-4087-ad3b-16c90cad86aa");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "460d2a1a-6516-467b-a11f-67663030d51b");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4771ea8c-e46b-41ad-a7fb-42ec82abac5f");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4855d74d-a10b-4437-9686-e561e0545c69");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4e8adcb0-70bc-4ce3-8de2-daad868336f3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "507cc554-894d-4dec-b0da-fe80a89ce5b7");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5527ce9d-30cb-4fba-ad3a-37a5f2786a96");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5621d3a8-b0fd-4533-9071-e297c9519a75");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5d3a7140-58c1-409c-8273-9a0e77e08b65");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "631388bc-6a76-408c-be70-913e7368aaa3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "699f58fd-e1fb-41ac-9711-e02088095dd2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6b7df305-50d9-4e19-b60d-8d9e3bd204d8");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7e817157-26c6-4fd3-99ca-6454aeeb1f83");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7eba93e1-29d0-48d7-bf7e-2c4c3e7ad21a");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "82061c88-0bc1-4007-a60d-6a9961a2ad6e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "84545f76-3ecb-4d81-9b7a-0ee1356e4938");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "92c0916e-a680-42b3-8932-a8e04b35c601");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9438f6ad-9f7f-4fca-87f7-caa7990c925e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9526b72c-b73d-421b-9efb-24ca1cd581e0");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "966d296e-0a1c-41ec-863d-7e3f0de48c9c");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "999cacc8-76c8-4d67-9c00-df3f4f0545f9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "99ddbd2d-d2db-4fe0-80be-191c821c5f00");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9a693f21-0659-4b4b-aeaa-a4d612f75077");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9b74c11f-4658-4670-a7ad-2d2a8832d9a1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9dce7f8d-6f13-460c-aba6-0a8e99c149be");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9f98d95e-d65a-477a-b138-c8e6fa04c836");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "a3d9c3b5-732e-4ff1-b260-216111e1ed4f");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "a676a7db-8f74-4e0d-b52a-7a6703e903df");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "a73c179c-f5e3-4e2e-9709-445802d8384b");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "a7c6344e-8443-4859-b990-58a536cc1348");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ad3c5d61-db6c-4b45-9d15-2276660411eb");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "bb1e5d5a-79b8-4fae-b497-7e72351d2c8f");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "c551589f-0a15-4711-8d0a-5fb6ae63bf53");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "c61e7138-1416-4a26-b5b3-81923bcfc0fb");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ce0e8bbd-e145-4f3e-9178-23edb0da0d97");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ceb4199a-6a22-4acb-a61a-68183c253a05");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "cfa6dd2c-3a11-4da8-9d30-fb2e13989557");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "cfe5c332-e060-46db-af7b-9053724f72ef");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d43c2239-1c0b-4304-b40a-4cff6581c79d");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d47cdaad-f85a-4261-bfaa-a17e90447d06");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d61704ea-db19-416b-94b4-8d4b84b0c8c3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d6ade87b-b4f6-484a-b8c9-6785c9a6c30e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d79f3777-28bb-4c86-896b-53e36e593a64");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d7d42c18-1ac6-4b40-a0fa-94d27ec83288");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d8f424d2-c525-4c38-be2b-9ff0d1ec9fd5");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "df0206bc-ccdb-4694-ab56-9114e2c6f22e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "df5adb8a-76ac-4143-a7e5-97b329e04001");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "e21ab050-4043-4da1-86a9-48618e744976");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "e5a85dc6-b385-4d1e-ace8-35ca4e600788");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "e869be2a-d288-41c2-acdb-2de75291d843");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "e8da4567-3a52-430b-a4c2-d62bfcef0a31");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ea71c6d7-6a08-4679-8c07-c672af04927a");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ea97ef4f-da47-4ef2-8a7f-e44c91db9fbf");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ed68d4e1-dba7-4c32-a652-41e0d4e9b6f2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f4bb6e52-6052-4587-aa44-a2d16d86b038");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f4c3e027-932b-4d09-905e-9f8dd328b9d1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f6c430cf-65e0-492a-8739-5998dd8056a8");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "fa1dc71f-bff0-476b-b7c2-2d62ea274c6d");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "fbef1515-bceb-4b43-a6e6-ccdc9c7f8884");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "fce432c4-bbcc-4861-8b8a-b4211796082d");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "fd35d6f2-1b61-4685-9480-44f609f5b8f9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ff743115-7c2d-4b23-900b-7af062379a42");
        }
    }
}
