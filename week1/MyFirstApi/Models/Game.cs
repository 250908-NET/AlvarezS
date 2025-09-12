public class Game
{
    public int sessionId { get; set; }
    public int answer { get; set; }
    public int guess { get; set; }

    public Game()
    {
        sessionId = 0;
        answer = new Random().Next(1, 101);
        guess = 0;
    }

    public Game(int sessionId)
    {
        this.sessionId = sessionId;
        answer = new Random().Next(1, 101);
        guess = 0;
    }
}