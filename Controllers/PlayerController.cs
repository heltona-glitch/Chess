using Microsoft.AspNetCore.Mvc;

[ApiController]
public class PlayerController : ControllerBase
{
    private ChessDbContext chessDbContext;

public PlayerController(ChessDbContext context)
    {
        this.chessDbContext = context;
    }
    [HttpPost("/players")]
    public Player CreatePlayer(PlayerCreateRequest request)
    {
        Player playerToCreate = new Player { PlayerName = request.Name };

        chessDbContext.Players.Add(playerToCreate);
        chessDbContext.SaveChanges();
        return playerToCreate;
    }
}