using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace BookStoreScratch;

public class Book : Entity<Guid>
{
    public string Name { get; set; }

    public BookType BookType { get; set; }

    public DateTime PublishDate { get; set; }

    public decimal Price { get; set; }

    internal Book() {}

    public Book(
        Guid id,
        string name,
        BookType bookType,
        DateTime publishDate,
        decimal price)
        : base(id)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.NotDefaultOrNull<BookType>(bookType, nameof(bookType));
        Check.NotDefaultOrNull<DateTime>(publishDate, nameof(publishDate));

        if (price < 0)
        {
            throw new ArgumentException("Price must be greater than or equal to 0.");
        }

        Name = name;
        BookType = bookType;
        PublishDate = publishDate;
        Price = price;
    }
}