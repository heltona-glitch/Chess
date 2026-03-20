public class GameHistoryCreateRequest
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int? WinnerPlayerId { get; set; } 

    public int Player1Id { get; set; }
    public int Player2Id { get; set; }


}