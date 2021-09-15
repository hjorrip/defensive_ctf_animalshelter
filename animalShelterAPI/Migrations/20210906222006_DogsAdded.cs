using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class DogsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Description", "IMGUrl", "Name", "Species" },
                values: new object[] { 5, "Hi everyone I’m Tilly, a very excited and happy puppy ready to play! I’m super active and love to run and play and play! Im super friendly and loyal and sometimes it can take a little while to warm up to other but then I’ll be your best friend. I’m great with smaller humans and play and follow them around. I’ve learnt to how to sit and shake your hand but still working on my other things but I’m a super quick learner.", "images/dog1.jpg", "Tilly", "Dog" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Description", "IMGUrl", "Name", "Species" },
                values: new object[] { 6, "Murphy is such a sweet little fella. He’s not a fan of big or boisterous dogs but likes relaxed keep to themselves doggos. He is very shy to start with however when comfortable he’s cuddly and very happy. He loves walks and chasing his ball but doesn’t like to share his ball. We’d love to find Murphy his perfect forever home, he deserves the best.", "images/dog2.jpg", "Murphy", "Dog" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Description", "IMGUrl", "Name", "Species" },
                values: new object[] { 7, "Lolly and her siblings were brought to our wonderful partner shelter and are looking healthier each day! Now that they are on their way to a full recovery, Lolly and her siblings can each look forward to finding their forever homes.", "images/dog3.jpg", "Lolly", "Dog" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Description", "IMGUrl", "Name", "Species" },
                values: new object[] { 8, "Our sweet, cuddly Buddy boy is a puppy in need of a dedicated, loving and lucky home to keep up his training, and reap the rewards of this beautiful boy's love and affection. Buddy's tail is always wagging, especially when he's following commands, and doing tricks, as he is always wanting to please. He adores his people, so, whether you're outside, or inside relaxing, he's just happy to be near you.", "images/dog4.jpg", "Buddy", "Dog" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 8);
        }
    }
}
