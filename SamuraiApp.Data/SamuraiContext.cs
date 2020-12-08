using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information).AddConsole();
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sConnB = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "SamuraiDataApp",
                UserID = "sa",
                Password = "sa1"
            };
            optionsBuilder.UseSqlServer(sConnB.ConnectionString)
                .UseLoggerFactory(ConsoleLoggerFactory)
                .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new {s.SamuraiId, s.BattleId});
            modelBuilder.Entity<Hourse>().ToTable("Horses");
        }
    }
}