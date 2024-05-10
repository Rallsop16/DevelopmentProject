
using DevelopmentProject.Shared.Entities;
using Microsoft.EntityFrameworkCore;


namespace DevelopmentProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			//---------------------------------User-------------------------------------
			modelBuilder.Entity<User>().HasData(
				new User { UserId = 1, FirstName = "Rachel", LastName = "Allsop", Email = "Email@address.com", Password = "Password", Role = "User" },
                new User { UserId = 2, FirstName = "Kate", LastName = "Jelly", Email = "Address@email.com", Password = "Password1", Role = "Admin" }
                );

			modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.UserId).ValueGeneratedOnAdd();

            //---------------------------------Vocab-------------------------------------
            modelBuilder.Entity<Vocab>().HasData(
                new Vocab {VocabId = 1, Original_word = "Horse", Translated_word = "Cheval", Original_language = "English", Translated_language = "French", UserId = 1 },
                 new Vocab { VocabId = 98, Original_word = "DOG", Translated_word = "CHIEN", Original_language = "English", Translated_language = "French", UserId = 2 }
                );

            
            modelBuilder.Entity<Vocab>().HasKey(v => v.VocabId);
            modelBuilder.Entity<Vocab>().Property(v => v.VocabId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Vocab>()
                .HasOne(u => u.User)
                .WithMany(v => v.Vocabs)
                .HasForeignKey(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //---------------------------------CollectionVocab-------------------------------------
            modelBuilder.Entity<CollectionVocab>().HasData(
                new CollectionVocab { CollectionVocabId = 1, CollectionVocabName = "Animals", UserId = 1},
                new CollectionVocab { CollectionVocabId = 99, CollectionVocabName = "Dog Breeds", UserId = 2 }
                );

            modelBuilder.Entity<CollectionVocab>().HasKey(c => c.CollectionVocabId);
            modelBuilder.Entity<CollectionVocab>().Property(c => c.CollectionVocabId).ValueGeneratedOnAdd();

            modelBuilder.Entity<CollectionVocab>()
                .HasOne(u => u.User)
                .WithMany(c => c.CollectionVocabs)
                .HasForeignKey(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //---------------------------------CollectionMap-------------------------------------
            modelBuilder.Entity<CollectionMap>().HasData(
                new CollectionMap { CollectionMapId = 1, VocabId = 1, CollectionVocabId = 1 },
                new CollectionMap { CollectionMapId = 88, VocabId = 98, CollectionVocabId = 99 }
                );

            modelBuilder.Entity<CollectionMap>().HasKey(m => m.CollectionMapId);
            modelBuilder.Entity<CollectionMap>().Property(m => m.CollectionMapId).ValueGeneratedOnAdd();

            modelBuilder.Entity<CollectionMap>()
                .HasOne(v => v.Vocab)
                .WithMany(m => m.CollectionMaps)
                .HasForeignKey(v => v.VocabId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CollectionMap>()
                .HasOne(c => c.CollectionVocab)
                .WithMany(m => m.CollectionMaps)
                .HasForeignKey(c => c.CollectionVocabId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //---------------------------------Statistics-------------------------------------
            modelBuilder.Entity<Statistics>().HasData(
                 new Statistics { StatisticsId = 1, Experience = 0, Time = 0, UserId = 1, Language = "French" },
                 new Statistics { StatisticsId = 2, Experience = 0, Time = 0, UserId = 2, Language = "French" }
                 );
            modelBuilder.Entity<Statistics>().HasKey(s => s.StatisticsId);
            modelBuilder.Entity<Statistics>().Property(s => s.StatisticsId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Statistics>()
                .HasOne(u => u.User)
                .WithMany(s => s.StatisticsCol)
                .HasForeignKey(u => u.UserId)
            .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vocab> Vocabs { get; set; }
        public DbSet<CollectionVocab> CollectionVocabs { get; set; }
        public DbSet<CollectionMap> CollectionMaps { get; set; }
        public DbSet<Statistics> Statistics { get; set; }



    }
}

