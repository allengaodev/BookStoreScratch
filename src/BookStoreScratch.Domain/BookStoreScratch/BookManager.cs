using System;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace BookStoreScratch;

public class BookManager : DomainService
{
    public Book CreateBook(string name, BookType bookType, DateTime publishDate, decimal price)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.NotDefaultOrNull<BookType>(bookType, nameof(bookType));
        Check.NotDefaultOrNull<DateTime>(publishDate, nameof(publishDate));

        if (price < 0)
        {
            throw new ArgumentException("Price must be greater than or equal to 0.");
        }

        return new Book(
            new Guid(),
            name,
            bookType,
            publishDate,
            price
        );
    }
}