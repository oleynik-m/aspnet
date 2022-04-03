using Microsoft.EntityFrameworkCore;

namespace WebApplicationGame.repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Game> Game { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<GameDeveloper> GameDevelopers{ get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {   
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {

            modelBuilder.Entity<Tag>().HasData(
                     new Tag { Id = 1, Name = "Action"},
                     new Tag { Id = 2, Name = "RPG"}
             );

            modelBuilder.Entity<GameDeveloper>().HasData(
                  new GameDeveloper { Id = 1, Name = "CD Project Red" },
                  new GameDeveloper { Id = 2, Name = "Piranha Bytes" }
            );

            List<int> arrs = new List<int> () { 1, 2 };

            modelBuilder.Entity<Game>().HasData(
                 new Game { Id = 1, Name = "Gothic",GameDeveloperId = 2,Tag = new List<int>() { 1, 2 } },
                 new Game { Id = 2, Name = "Witcher", GameDeveloperId = 1, Tag = new List<int>() { 1, 2 } }
            );
        }
    }
}
