using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class OnModelSeed_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Description",
                value: "Hello everyone my name is Arya. I am a young, fun and friendly kitten looking for a home! My foster Mum says I am a real cutie so I am hoping this is a good thing and I will find someone who wants to adopt me soon.");

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Description", "IMGUrl", "Name", "Species" },
                values: new object[] { 2, "Meet Loki! Loki is a beautiful boy with a heart of gold and the face of a baby! Loki loves to play with his sisters and run around after toys. He is also a big smoocher! Rubbing up against your legs and giving you a love bite. Loki and his sisters came in with no place to call home and were petrified of humans and their big hands! Now Loki loves when those big hands come out, as it means cuddles and smooch time!", "images/cat2.jpg", "Loki", "Cat" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Description", "IMGUrl", "Name", "Species" },
                values: new object[] { 3, "He is a little shy but we think in the perfect home where he can settle down he would become the most snuggliest cat. He loves a nice comfy bed to sleep in.", "images/cat3.jpg", "Thor", "Cat" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Description", "IMGUrl", "Name", "Species" },
                values: new object[] { 4, "Hi there fam…..Meow Meow here on the hunt to find my furever family! You might have guessed from my name I am a bit of a talker!! I love a chat with my foster mum and I’m not going to lie, I am super happy when she talks back to me - the crazy cat lady she is!!", "images/cat4.jpg", "Khaleesi", "Cat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Description",
                value: "Description for Arya");
        }
    }
}
