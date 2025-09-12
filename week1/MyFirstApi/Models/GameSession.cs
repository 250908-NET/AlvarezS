public class GameSession
{
    private static int _nextId = 1;

    public int sessionId { get; set; }
    public int answer { get; set; }
    public int guess { get; set; }

    public GameSession()
    {
        sessionId = _nextId++;
        answer = new Random().Next(1, 101);
        guess = 0;
    }

    public GameSession(int answer, int guess)
    {
        sessionId = _nextId++;
        this.answer = answer;
        this.guess = guess;
    }
}