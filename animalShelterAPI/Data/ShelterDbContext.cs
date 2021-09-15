using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AnimalAPI
{
    public class ShelterDbContext : IdentityDbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public string DbPath { get; private set; }

        public ShelterDbContext(DbContextOptions<ShelterDbContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>().HasData(new Animal { AnimalId = 1, Species = "Cat", Name="Arya", IMGUrl="images/cat1.jpg", Description = "Hello everyone my name is Arya. I am a young, fun and friendly kitten looking for a home! My foster Mum says I am a real cutie so I am hoping this is a good thing and I will find someone who wants to adopt me soon."});
            modelBuilder.Entity<Animal>().HasData(new Animal { AnimalId = 2, Species = "Cat", Name="Loki", IMGUrl="images/cat2.jpg", Description = "Meet Loki! Loki is a beautiful boy with a heart of gold and the face of a baby! Loki loves to play with his sisters and run around after toys. He is also a big smoocher! Rubbing up against your legs and giving you a love bite. Loki and his sisters came in with no place to call home and were petrified of humans and their big hands! Now Loki loves when those big hands come out, as it means cuddles and smooch time!"});
            modelBuilder.Entity<Animal>().HasData(new Animal { AnimalId = 3, Species = "Cat", Name="Thor", IMGUrl="images/cat3.jpg", Description = "He is a little shy but we think in the perfect home where he can settle down he would become the most snuggliest cat. He loves a nice comfy bed to sleep in."});
            modelBuilder.Entity<Animal>().HasData(new Animal { AnimalId = 4, Species = "Cat", Name="Khaleesi", IMGUrl="images/cat4.jpg", Description = "Hi there fam…..Meow Meow here on the hunt to find my furever family! You might have guessed from my name I am a bit of a talker!! I love a chat with my foster mum and I’m not going to lie, I am super happy when she talks back to me - the crazy cat lady she is!!"});
            modelBuilder.Entity<Animal>().HasData(new Animal { AnimalId = 5, Species = "Dog", Name="Tilly", IMGUrl="images/dog1.jpg", Description = "Hi everyone I’m Tilly, a very excited and happy puppy ready to play! I’m super active and love to run and play and play! Im super friendly and loyal and sometimes it can take a little while to warm up to other but then I’ll be your best friend. I’m great with smaller humans and play and follow them around. I’ve learnt to how to sit and shake your hand but still working on my other things but I’m a super quick learner."});
            modelBuilder.Entity<Animal>().HasData(new Animal { AnimalId = 6, Species = "Dog", Name="Murphy", IMGUrl="images/dog2.jpg", Description = "Murphy is such a sweet little fella. He’s not a fan of big or boisterous dogs but likes relaxed keep to themselves doggos. He is very shy to start with however when comfortable he’s cuddly and very happy. He loves walks and chasing his ball but doesn’t like to share his ball. We’d love to find Murphy his perfect forever home, he deserves the best."});
            modelBuilder.Entity<Animal>().HasData(new Animal { AnimalId = 7, Species = "Dog", Name="Lolly", IMGUrl="images/dog3.jpg", Description = "Lolly and her siblings were brought to our wonderful partner shelter and are looking healthier each day! Now that they are on their way to a full recovery, Lolly and her siblings can each look forward to finding their forever homes."});
            modelBuilder.Entity<Animal>().HasData(new Animal { AnimalId = 8, Species = "Dog", Name="Buddy", IMGUrl="images/dog4.jpg", Description = "Our sweet, cuddly Buddy boy is a puppy in need of a dedicated, loving and lucky home to keep up his training, and reap the rewards of this beautiful boy's love and affection. Buddy's tail is always wagging, especially when he's following commands, and doing tricks, as he is always wanting to please. He adores his people, so, whether you're outside, or inside relaxing, he's just happy to be near you."});


            modelBuilder.Entity<Customer>().HasData(new Customer {Id = 1, FirstName = "John", LastName = "Snow", PhoneNr="661 1111", Email="johnsnow@youknownothing.com" });
            modelBuilder.Entity<Customer>().HasData(new Customer {Id = 2, FirstName = "Buffy", LastName = "Summers", PhoneNr="849 4491", Email="buffy@slayer.com" });


        }


    }
}