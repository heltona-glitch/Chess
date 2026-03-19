public class GameHistory
{
    public int GameHistoryId { get; set; } //Primary Key

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    //Relational Data
    public int Player1Id { get; set; }
    public Player PlayerOne { get; set; }   

    public int Player2Id { get; set; }
    public Player PlayerTwo { get; set; }

    public int? WinnerPlayerId { get; set; } //Null == Draw

}