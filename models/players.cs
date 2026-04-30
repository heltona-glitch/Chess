using Microsoft.AspNetCore.RateLimiting;
using System.Text.Json.Serialization;
/// <summary>
/// Represents a chess playerrr
/// </summary>
public class Player
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public int Wins { get; set; }
    public int Losses { get; set; }

//Relational Data
/// <summary>
/// Lists of games associated with the playerrr
/// </summary>
[JsonIgnore]
public List<GameHistory> GameHistories { get; set; } =new();
}
