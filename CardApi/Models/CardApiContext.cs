using CardApi.Models.Account;
using CardApi.Models.Cards;
using Microsoft.EntityFrameworkCore;

namespace CardApi.Models
{
    public class CardApiContext   :DbContext
    {

        public string DbPath { get; set; }

        
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Deck> Decks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Personal)}{Path.DirectorySeparatorChar}smart_contracts.db";


            optionsBuilder.UseSqlite($"Data Source=Database/CardDb.db");
        }
        public CardApiContext(DbContextOptions<CardApiContext> options): base(options)
        {
            Database.EnsureCreated();
        }

       

    }

}
