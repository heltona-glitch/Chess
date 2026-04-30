public interface IPlayerService
{
    List<Player> GetAllPlayers();
    Player? GetPlayerById(int id);
    Player CreatePlayer(string name);
    void UpdatePlayer(Player player, string name);
    void DeletePlayer(Player player);
}

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public List<Player> GetAllPlayers()
    {
        return _playerRepository.GetAll();
    }

    public Player? GetPlayerById(int id)
    {
        return _playerRepository.GetById(id);
    }

    public Player CreatePlayer(string name)
    {
        var player = new Player
        {
            PlayerName = name,
            Wins = 0,
            Losses = 0
        };

        _playerRepository.Add(player);
        _playerRepository.Save();

        return player;
    }

    public void UpdatePlayer(Player player, string name)
    {
        player.PlayerName = name;
        _playerRepository.Update(player);
        _playerRepository.Save();
    }

    public void DeletePlayer(Player player)
    {
        _playerRepository.Delete(player);
        _playerRepository.Save();
    }
}