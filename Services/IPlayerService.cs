public interface IPlayerService
{
    List<Player> GetAllPlayers();
    List<Player> GetLeaderboard();
    Player? GetPlayerById(int id);
    Player CreatePlayer(string name);
    void UpdatePlayer(Player player, string name);
    void DeletePlayer(Player player);
}

