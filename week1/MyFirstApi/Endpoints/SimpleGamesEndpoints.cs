public static class SimpleGamesEndpoints
{
    public static List<GameSession> sessions = new List<GameSession>();
    public static void MapSimpleGamesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/game/start", () =>
        {
            var session = new GameSession();
            sessions.Add(session);
            return Results.Ok(new { session.sessionId, message = "Game started! Guess a number between 1 and 100." });
        });

        app.MapPost("/game/guess-number", (GameSession incomingSession) =>
        {
            
            var existingSession = sessions.FirstOrDefault(s => s.sessionId == incomingSession.sessionId);

            if (existingSession is null)
            {
                return Results.NotFound(new { message = "Session not found. Start a new game first." });
            }

            
            if (incomingSession.guess == existingSession.answer)
            {
                sessions.Remove(existingSession);
                return Results.Ok(new { message = $"🎉 Correct! Session {existingSession.sessionId} ended." });
            }
            else if (incomingSession.guess < existingSession.answer)
            {
                return Results.Ok(new { message = "Too low! Try again." });
            }
            else
            {
                return Results.Ok(new { message = "Too high! Try again." });
            }
        });
    


        app.MapGet("/game/rock-paper-scissors/{choice}", (string choice) =>
        {
            List<string> options = new List<string> { "rock", "paper", "scissor" };
            Random r = new Random();
            string bot = options[r.Next(options.Count())];

            if (choice == bot)
                return "tie";
            switch (choice)
            {
                case "rock":
                    if (bot == "paper")
                        return $"You win! {choice} beats {bot}";
                    else
                        return $"You Lose! {bot} beats {choice}";
                case "paper":
                    if (bot == "rock")
                        return $"You win! {choice} beats {bot}";
                    else
                        return $"You Lose! {bot} beats {choice}";
                case "scissor":
                    if (bot == "paper")
                        return $"You win! {choice} beats {bot}";
                    else
                        return $"You Lose! {bot} beats {choice}";
                default:
                    break;
            }
            return "I AM A TEAPOT";
        });

        app.MapGet("/game/dice/{sides}/{count}", (int sides, int count) =>
        {
            List<int> dice = new List<int>();
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                int roll = r.Next(1, sides);
                dice.Add(roll);
            }
            return dice;
        });

        app.MapGet("/game/coin-flip/{count}", (int count) =>
        {
            List<char> coinFaces = new List<char> { 'H', 'T' };
            Dictionary<int, char> results = new Dictionary<int, char>();
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                int index = r.Next(0, coinFaces.Count());
                results.Add(i, coinFaces[index]);
            }
            return results;
        });
    }
}