namespace ProgLib.API.Contracts
{
    public record BooksResponse(Guid Id, string Title, string Description, decimal Price);

    public record BooksRequest(string Title, string Descrtiption, decimal Price);
}
