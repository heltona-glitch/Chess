using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
public class GameHistoryController : ControllerBase
{
    private readonly IGameHistoryService _gameService;

    public GameHistoryController(IGameHistoryService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet("game-histories/{Id}")]
    public IActionResult GetById(int Id)
    {
        var history = _gameService.GetById(Id);

        if (history == null)
        {
            return NotFound("Game not found.");
        }
        return Ok(history);
    }

    [HttpGet("/game-histories")]
    public IActionResult GetAll()
    {
        return Ok(_gameService.GetAll());
    }

    [HttpPost("/game-histories")]
    public IActionResult Create(GameHistoryCreateRequest request)
    {
        try
        {
            var game = _gameService.CreateGame(request);
            return Ok(game);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
};