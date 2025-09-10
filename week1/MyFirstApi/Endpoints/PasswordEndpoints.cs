public static class PasswordEndpoints
{
    public static void MapPasswordEndpoints(this IEndpointRouteBuilder app)
    {
        string alpha = "abcdefghijklmnopqrstuvwxyz";
        string sym = "!@#$%^&*-_+.?";
        string[] wordBank = new[]
        {
            "apple", "moon", "river", "star", "cloud", "stone", "fire",
            "wind", "tree", "wolf", "sun", "sky", "night", "ocean", "dream"
        };

        app.MapGet("/password/simple/{length}", (int length) =>
        {
            string pass = "";
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                int n = r.Next(2);
                if (n == 0)
                {

                    pass += alpha[r.Next(alpha.Length - 1)];
                }
                else
                {
                    pass += r.Next(10);

                }
            }
            return pass;
        });

        app.MapGet("/password/complex/{length}", (int length) =>
        { 
            string pass = "";
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                int n = r.Next(2);
                if (n == 0)
                {
                    pass += alpha[r.Next(alpha.Length - 1)];
                }
                else if (n == 1)
                {
                    pass += sym[r.Next(sym.Length - 1)];
                }
                else
                {
                    pass += r.Next(10);
                }
            }
            return pass;
        });

        app.MapGet("/password/memorable/{words}", (int words)=>
        {
            Random rand = new Random();
            var selected = Enumerable.Range(0, words)
                .Select(_ => wordBank[rand.Next(wordBank.Length)]);

            string pass = string.Join("-", selected);

            return pass;
        });

        app.MapGet("/password/strength/{password}", (string password)=>
        {
            int score = 0;

            if (password.Length >= 8) score++;
            if (password.Length >= 12) score++;
            if (password.Any(char.IsLower)) score++;
            if (password.Any(char.IsUpper)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (password.Any(ch => !char.IsLetterOrDigit(ch))) score++;

            string strength;
            if (score <= 2)
                strength = "Weak";
            else if (score <= 4)
                strength = "Medium";
            else
                strength = "Strong";

            return Results.Ok(new { password, strength, score });
        });
    }
}