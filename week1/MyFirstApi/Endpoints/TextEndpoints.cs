public static class TextEndpoints
{
    public static void MapTextEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/text/reverse/{text}", (string text) =>
        {
            var reversed = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversed += text[i];
            }

            return reversed;
        });

        app.MapGet("/text/uppercase/{text}", (string text) =>
        {
            return text.ToUpper();
        });

        app.MapGet("/text/lowercase/{text}", (string text) =>
        {
            return text.ToLower();
        });

        app.MapGet("/text/count/{text}", (string text) =>
        {
            var wordCount = text.Split(" ");
            var vowels = new[] { 'a', 'e', 'i', 'o', 'u' }.ToList();
            var vowelCount = 0;

            foreach (var letter in text)
            {
                if (vowels.Contains(letter))
                {
                    vowelCount += 1;
                }
            }

            return new
            {
                charCount = text.Length,
                wordCount = wordCount.Length,
                vowelCount = vowelCount,
            };
        });
        
        app.MapGet("/text/palindrome/{text}", (string text) =>
        {
            var l = 0;
            var r = text.Length - 1;

            while (l < r)
            {
                if (text[l] != text[r])
                {
                    return false;
                }
                l++;
                r--;
            }
            return true;
        });
    }
}