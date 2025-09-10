public static class NumbersEndpoints
{
    public static int Fib(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }
        return Fib(n - 1) + Fib(n - 2);
    }
    /*
        numbers divisible by three, you print "Fizz," for numbers divisible by five, 
        you print "Buzz," and for numbers divisible by both, you print "FizzBuzz" 
        instead of the number itself.
    */
    public static void MapNumbersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/numbers/fizzbuzz/{count}", (int count) =>
        {
            var sequence = new List<string>();
            for (int n = 0; n <= count; n++)
                if (n % 3 == 0 && n % 5 == 0)
                {
                    sequence.Add($"{n}: FizzBuzz");
                }
                else if (n % 3 == 0)
                {
                    sequence.Add($"{n}: Fizz");
                }
                else if (n % 5 == 0)
                {
                    sequence.Add($"{n}: Buzz");

                }
                else
                {
                    sequence.Add(n.ToString());
                }
            return sequence;
        });

        app.MapGet("/numbers/prime/{number}", (int number) =>
        {
            if (number <= 1)
            {
                return false;
            }
            else if (number == 2)
            {
                return true;
            }

            for (int i = 3; i < (int)Math.Sqrt(number) + 1; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        });

        app.MapGet("/numbers/fibonacci/{n}", (int n) =>
        {
            var sequence = new List<int>();

            for (int i = 0; i <= n; i++)
            {
                sequence.Add(Fib(i));
            }
            return sequence;
        });

        app.MapGet("/numbers/factors/{number}", (int number) =>
        {
            var factors = new List<int>();
            for (int i = 1; i < (int)Math.Sqrt(number); i++)
            {
                if (i == 1 || i % 2 == 0)
                {
                    factors.Add(i);
                    factors.Add(number / i);
                }
            }
            factors.Sort();
            return factors;

        });
    }
}