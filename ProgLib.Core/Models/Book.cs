namespace ProgLib.Core.Models
{
    public class Book
    {
        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public Guid Id { get; }

        public string Title { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; }

        public static (Book book, string error) Create(Guid id, string title,string description, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title))
            {
                error = "Title can not be empty";
            }

            var book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}
