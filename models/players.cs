using Microsoft.AspNetCore.RateLimiting;
using System.Text.Json.Serialization;

public class Player
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }

//Relational Data
[JsonIgnore]
public List<GameHistory> GameHistories { get; set; }
}
