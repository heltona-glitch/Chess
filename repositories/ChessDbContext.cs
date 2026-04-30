using Microsoft.EntityFrameworkCore;

public class ChessDbContext : DbContext
{
    public ChessDbContext(DbContextOptions<ChessDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
        .HasMany(p => p.GameHistories)
        .WithOne()
        .OnDelete(DeleteBehavior.Cascade);
    }
    //Our entities that our database will be made up of, as tables
    public DbSet<GameHistory> GameHistories { get; set; }

    public DbSet<Player> Players { get; set; }
}