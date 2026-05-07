public interface IGameHistoryService
{
    GameHistory? GetById(int id);
    List<GameHistory> GetAll();
    GameHistory CreateGame(GameHistoryCreateRequest request);
}