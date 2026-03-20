public class GameHistory
{
    public int GameHistoryId { get; set; } //Primary Key

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    //Relational Data
   public List<Player> GamePlayers { get; set; } //Navigation property for the many-to-many relationship

    public int? WinnerPlayerId { get; set; } //Null == Draw

}