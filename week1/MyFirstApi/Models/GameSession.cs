public class GameSession
{
    private static int _nextId = 1;

    public int sessionId { get; set; }

    public GameSession()
    {
        sessionId = _nextId++;
    }
}