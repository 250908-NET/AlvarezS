using System.Text.RegularExpressions;

public static class SimpleValidatorEndpoints
{
    public static void MapSimpleValidatorEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/validate/email/{email}", (string email) =>
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(pattern);
        });

        app.MapGet("/validate/phone/{phone}", (string phone) =>
        { 
            string pattern = @"^\(?\d{3}\)?[-. ]?\d{3}[-. ]?\d{4}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phone);
        });

        app.MapGet("/validate/creditcard/{number}", (string number) =>
        {
            //Go through each char in string and input into digits as int
            List<int> digits = number.Select(c => int.Parse(c.ToString())).ToList();
            List<int> results = new List<int>();
            int second = 1;
            int sum = 0;

            for (int i = digits.Count - 1; i >= 0; i--)
            {
                if (second == 2)
                {
                    int n = digits[i] * 2;
                    if (n > 9) n -= 9;
                    results.Add(n);
                }
                else
                {
                    results.Add(digits[i]);
                }

                
                second = (second == 1) ? 2 : 1;
            }

            foreach (int num in results)
            {
                sum += num;
            }

            return sum % 10 == 0;
        });

        app.MapGet("/validate/strongpassword/{password}", (string password) =>
        { 
            string strongPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$";
            return Regex.IsMatch(password, strongPattern);
        });
    }
}