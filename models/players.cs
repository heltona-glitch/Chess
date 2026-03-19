using Microsoft.AspNetCore.RateLimiting;

public class Player
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }

//Relational Data
public List<GameHistory> GameHistories { get; set; }
}
