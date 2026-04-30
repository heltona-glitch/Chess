using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
public class GameHistoryController : ControllerBase
{
    private readonly IGameHistoryRepository _gameRepository;
    private readonly IPlayerRepository _playerRepository;

    public GameHistoryController(
        IGameHistoryRepository gameRepository,
        IPlayerRepository playerRepository)
    {
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
    }

    [HttpGet("game-histories/{gameHistoryId}")]
    public IActionResult GetGameHistoryById(int gameHistoryId)
    {
        var history = _gameRepository.GetById(gameHistoryId);

        if (history == null)
        {
            return NotFound("Game history not found.");
        }

        return Ok(history);
    }

    [HttpGet("/game-histories")]
    public IActionResult GetAllGameHistories()
    {
        var histories = _gameRepository.GetAll();
        return Ok(histories);
    }

    [HttpPost("/game-histories")]
    public IActionResult CreateGameHistory(GameHistoryCreateRequest request)
    {
        try
        {
            Player? player1 = _playerRepository.GetById(request.Player1Id);
            Player? player2 = _playerRepository.GetById(request.Player2Id);

            if (player1 == null || player2 == null)
            {
                return BadRequest("One or both players not found.");
            }

            GameHistory history = new GameHistory
            {
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                WinnerPlayerId = request.WinnerPlayerId,
                GamePlayers = new List<Player> { player1, player2 }
            };

            // Update winner
            if (request.WinnerPlayerId.HasValue)
            {
                var winner = _playerRepository.GetById(request.WinnerPlayerId.Value);
                if (winner != null)
                {
                    winner.Wins++;
                    _playerRepository.Update(winner);
                }
            }

            // Update loser
            int loserId = request.Player1Id == request.WinnerPlayerId
                ? request.Player2Id
                : request.Player1Id;

            var loser = _playerRepository.GetById(loserId);
            if (loser != null)
            {
                loser.Losses++;
                _playerRepository.Update(loser);
            }

            _gameRepository.Add(history);
            _gameRepository.Save();

            _playerRepository.Save();

            return Ok(history);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error trying to save game history.");
        }
    }
}