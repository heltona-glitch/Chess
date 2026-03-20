using Microsoft.EntityFrameworkCore;

public class ChessDbContext : DbContext
{
    public ChessDbContext(DbContextOptions<ChessDbContext> options) : base(options)
    {
        
    }

    //Our entities that our database will be made up of, as tables
    public DbSet<GameHistory> GameHistories { get; set; }

    public DbSet<Player> Players { get; set; }
}