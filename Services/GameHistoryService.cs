public class GameHistoryService : IGameHistoryService
{
    private readonly IGameHistoryRepository _gameRepository;
    private readonly IPlayerRepository _playerRepository;

    public GameHistoryService(
        IGameHistoryRepository gameRepository,
        IPlayerRepository playerRepository)
    {
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
    }

    public GameHistory? GetById(int id)
    {
        return _gameRepository.GetById(id);
    }

    public List<GameHistory> GetAll()
    {
        return _gameRepository.GetAll();
    }

    public GameHistory CreateGame(GameHistoryCreateRequest request)
    {
        var player1 = _playerRepository.GetById(request.Player1Id);
        var player2 = _playerRepository.GetById(request.Player2Id);

        if (player1 == null || player2 == null)
        {
            throw new Exception("Players not found");
        }

        var game = new GameHistory
        {
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            WinnerPlayerId = request.WinnerPlayerId,
            GamePlayers = new List<Player> { player1, player2 }
        };

        // Win/Loss logic (MOVED OUT OF THE CONTROLLER AND INTO THE SERVICE)
        if (request.WinnerPlayerId.HasValue)
        {
            var winner = _playerRepository.GetById(request.WinnerPlayerId.Value);
            if (winner != null)
            {
                winner.Wins++;
                _playerRepository.Update(winner);
            }
        }

        int loserId = request.Player1Id == request.WinnerPlayerId
            ? request.Player2Id
            : request.Player1Id;

        var loser = _playerRepository.GetById(loserId);
        if (loser != null)
        {
            loser.Losses++;
            _playerRepository.Update(loser);
        }

        _playerRepository.Save();

        _gameRepository.Add(game);
        _gameRepository.Save();

        return game;
    }
}