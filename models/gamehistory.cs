using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Represents a completed or still rinning game
/// </summary>
public class GameHistory
{
    public int GameHistoryId { get; set; } //Primary Key

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    //Relational Data
    /// <summary>
    /// Players that are involved
    /// </summary>
   [NotMapped]
public List<Player>? GamePlayers { get; set; }
// This would normally represent a many-to-many relationship, but it's not mapped to the database for simplicity in this project.

   /// <summary>
   /// Winner of the game, a null means theres a darn draw
   /// </summary>
    public int? WinnerPlayerId { get; set; } //Null == Draw

}