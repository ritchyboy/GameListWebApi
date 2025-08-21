using GameListWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GameListWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContext _db;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Game> games { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(
              new Game(1,"Elden Ring", "Adventure game extremely hard full of challenge"),
              new Game(2,"Stellar blade","Beautiful game with a rich story"),
              new Game(3,"The Legend Of Zelda","Adventure game and puzzle"),
              new Game(4,"Nier Automata","Game of robot trying to be humain"),
              new Game(5,"Armored Core V","Mecha game action and fight"),
              new Game(6,"Battlefield 3", "Game of war shooting game")
            );
        }
    }
}
