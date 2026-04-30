public interface IPlayerRepository
{
    List<Player> GetAll();
    Player? GetById(int id);
    Player Add(Player player);
    void Update(Player player);
    void Delete(Player player);
    void Save();
}

public class PlayerRepository : IPlayerRepository
{
    private readonly ChessDbContext _context;
    public PlayerRepository(ChessDbContext context)
    {
        _context = context;
    }

    public List<Player> GetAll()
    {
        return _context.Players.ToList();
    }

    public Player? GetById(int id)
    {
        return _context.Players.FirstOrDefault(p => p.PlayerId == id);
    }

    public Player Add(Player player)
    {
        _context.Players.Add(player);
        return player;
    }

    public void Update(Player player)
    {
        _context.Players.Update(player);
    }

    public void Delete(Player player)
    {
        _context.Players.Remove(player);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
    
}