using ProgLib.API.Contracts;
using ProgLib.Core.Abstractions;

namespace ProgLib.API.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);

        app.MapPost("login", Login);

        return app;
    }

    private static async Task<IResult> Register(RegisterUserRequest request, IUsersService usersService)
    {
        await usersService.Register(request.UserName, request.Email, request.Password);
        return Results.Created();
    }

    private static async Task<IResult> Login(LoginUserRequest request, IUsersService usersService, HttpContext context)
    {
        var token = await usersService.Login(request.Email, request.Password);

        context.Response.Cookies.Append("proglibcookies", token);

        return Results.Ok();
    }
}
