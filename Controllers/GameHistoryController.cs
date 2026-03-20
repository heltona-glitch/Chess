using Microsoft.AspNetCore.Mvc;

[ApiController]

public class GameHistoryController : ControllerBase
{
    [HttpGet("game-histories/{gameHistoryId}")]
    public GameHistory GetGameHistoryById(int gameHistoryId)
    {
      GameHistory gameHistory = new GameHistory
      {
        GameHistoryId = gameHistoryId,
        StartTime = DateTime.Now,
        EndTime = DateTime.MaxValue
      };
      
      Player player1 = new Player
      {
        PlayerId = 1,
        PlayerName = "Player Bob"
      };

        Player player2 = new Player
        {
            PlayerId = 2,
            PlayerName = "Alice"
        };

       gameHistory.GamePlayers = [player1, player2];

        gameHistory.WinnerPlayerId = player1.PlayerId;
        return gameHistory;
    }

}