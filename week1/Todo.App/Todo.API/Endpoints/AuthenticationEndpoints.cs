public static class AuthenticationEndpoints
{
    public static List<User> users = new List<User>();
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", (User user) =>
        {
            var foundUser = userExist(user);
            if (foundUser != null)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Operation failed",
                    error = "User exists. Please log in"
                });
            else
            {
                var newUser = new User(user.name, user.password);

                users.Add(newUser);

                return Results.Ok(new
                {
                    success = true,
                    message = "User created successfully",
                });
            }
        });

        app.MapPost("/login", (User user) =>
        {
            var foundUser = userExist(user);

            if (foundUser != null && foundUser.password == user.password)
            {
                var token = JWTService.GenerateToken(foundUser.name);
                return Results.Ok(new
                {
                    success = true,
                    message = "Operation completed successfully",
                    data = token
                });
            }
            else if (foundUser == null)
            {
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Operation failed",
                    error = "User not found. Please register"
                });
            }
            else
            {
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Operation failed",
                    error = "Invalid Password"
                });
            }
        });
    }

    public static User? userExist(User findUser)
    {
        var user = users.FirstOrDefault(u => u.name == findUser.name);

        if (user != null) return user;
        return null;
    }
}