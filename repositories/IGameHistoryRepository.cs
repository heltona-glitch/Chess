public interface IGameHistoryRepository
{
    List<GameHistory> GetAll();
    GameHistory? GetById(int id);
    GameHistory Add(GameHistory game);
    void Save();
}

public class GameHistoryRepository : IGameHistoryRepository
{
    private readonly ChessDbContext _context;
    public GameHistoryRepository(ChessDbContext context)
    {
        _context = context;
    }

    public List<GameHistory> GetAll()
    {
        return _context.GameHistories.ToList();
    }

    public GameHistory? GetById(int id)
    {
        return _context.GameHistories.FirstOrDefault(g => g.GameHistoryId == id);
    }

    public GameHistory Add(GameHistory game)
    {
        _context.GameHistories.Add(game);
        return game;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}