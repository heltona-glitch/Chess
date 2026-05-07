using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
public class PlayerController : ControllerBase
{
private readonly IPlayerService _playerService;

public PlayerController(IPlayerService playerService)
{
    _playerService = playerService;
}
//This is to create a player, I'm implementing CRUD
    [HttpPost("/players")]
public IActionResult CreatePlayer(PlayerCreateRequest request)
{
    if (string.IsNullOrWhiteSpace(request.Name))
    {
        return BadRequest("Player name is required.");
    }

    var player = _playerService.CreatePlayer(request.Name);

    return Created($"/players/{player.PlayerId}", player);
}
//This is to get all players, I'm still implementing CRUD
    [HttpGet("/players")]
    public IActionResult GetPlayers()
    {
        return Ok(_playerService.GetAllPlayers());
    }
//This is to read a single player by id, still using CRUD
    [HttpGet("/players/{id}")]
    public IActionResult GetPlayer(int id)
    {
        var player = _playerService.GetPlayerById(id);

        if (player == null)
        {
            return NotFound("Player not found.");
        }

        return Ok(player);
    }
//HELLO CLASS, THIS IS THE UPDATE METHOD, STILL USING CRUD
    [HttpPut("/players/{id}")]
    public IActionResult UpdatePlayer(int id, PlayerCreateRequest request)
    {
        var player = _playerService.GetPlayerById(id);

        if (player == null)
        {
            return NotFound("Player not found.");
        }

        player.PlayerName = request.Name;

        try
        {
            _playerService.UpdatePlayer(player, request.Name);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error updating player.");
        }

        return Ok(player);
    }
//THIS IS TO DELETE PLAYERS, STILL USING THE CRUDDING CRUD
    [HttpDelete("/players/{id}")]
    public IActionResult DeletePlayer(int id)
    {
        var player = _playerService.GetPlayerById(id);

        if (player == null)
        {
            return NotFound("Player not found.");
        }

        try
        {
            _playerService.DeletePlayer(player);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error deleting player.");
        }

        return NoContent();
    }

    [HttpGet("/players/leaderboard")]
    public IActionResult GetLeaderboard()
    {
        return Ok(_playerService.GetLeaderboard());
    }
}