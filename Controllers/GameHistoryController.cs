using Microsoft.AspNetCore.Mvc;

[ApiController]

public class GameHistoryController : ControllerBase
{
    private ChessDbContext chessDbContext;
    public GameHistoryController(ChessDbContext context)
    {
        this.chessDbContext = context;
    }


    [HttpGet("game-histories/{gameHistoryId}")]
    public GameHistory? GetGameHistoryById(int gameHistoryId)
  {
    return chessDbContext.GameHistories.Find(gameHistoryId);
    }
    [HttpPost("/game-histories")]
    public GameHistory CreateGameHistory(GameHistoryCreateRequest request)
    {
        GameHistory gameHistory = new GameHistory();
        
          //Map from request to object we're actually
           GameHistory history = new GameHistory();
           history.StartTime = request.StartTime;
           history.EndTime = request.EndTime;
            history.WinnerPlayerId = request.WinnerPlayerId;

            //retrieve the two players from their id
            Player? player1 = chessDbContext.Players.Find(request.Player1Id);
            Player? player2 = chessDbContext.Players.Find(request.Player2Id);
        
        if (player1 == null || player2 == null)
        {
            throw new Exception("PLAYER NOT FOUND");
        }
        
            gameHistory.GamePlayers = [player1, player2];
            //save the game history to the database
          chessDbContext.GameHistories.Add(history);
          chessDbContext.SaveChanges();

        return history;
        }
    }