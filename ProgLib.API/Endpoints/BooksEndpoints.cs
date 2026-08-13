using Microsoft.AspNetCore.Mvc;
using ProgLib.API.Contracts;
using ProgLib.Application.Services;
using ProgLib.Core.Abstractions;
using ProgLib.Core.Models;

namespace ProgLib.API.Endpoints;

public static class BooksEndpoints
{

    public static IEndpointRouteBuilder MapBooksEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("proglibbooks").RequireAuthorization();

        endpoints.MapGet(string.Empty, GetBooks);

        endpoints.MapPost(string.Empty, CreateBook);

        endpoints.MapPut("{id:guid}", UpdateBooks);

        endpoints.MapDelete("{id:guid}", DeleteBook);

        return endpoints;
    }

    public async static Task<IResult> GetBooks(IBooksService booksService) 
    {
        var books = await booksService.GetAllBooks();

        var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));

        return Results.Ok(response);
    }

    public async static Task<IResult> CreateBook([FromBody] BooksRequest request, IBooksService booksService)
    {
        var (book, error) = Book.Create(
            Guid.NewGuid(),
            request.Title,
            request.Descrtiption,
            request.Price);

        if (!string.IsNullOrEmpty(error))
        {
            return Results.BadRequest(error);
        }

        var bookId = await booksService.CreateBook(book);

        return Results.Ok(book);
    }


    public async static Task<IResult> UpdateBooks(Guid id, [FromBody] BooksRequest request, IBooksService booksService)
    {
        var bookId = await booksService.UpdateBook(id, request.Title, request.Descrtiption, request.Price);

        return Results.Ok(bookId);
    }

    public async static Task<IResult> DeleteBook(Guid id, IBooksService booksService)
    {
        return Results.Ok(await booksService.DeleteBook(id));
    }
}
