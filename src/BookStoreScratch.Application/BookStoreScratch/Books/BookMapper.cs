using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;

namespace BookStoreScratch.Books;

public class BookMapper : IObjectMapper<Book, BookDto>, ITransientDependency
{
    public BookDto Map(Book source)
    {
        return Map(source, new BookDto());
    }

    public BookDto Map(Book source, BookDto destination)
    {
        destination.Id = source.Id;
        destination.Name = source.Name;
        destination.BookType = source.BookType;
        destination.PublishDate = source.PublishDate;
        destination.Price = source.Price;

        return destination;
    }
}

public class CreateUpdateBookMapper : IObjectMapper<CreateUpdateBookDto, Book>, ITransientDependency
{
    public Book Map(CreateUpdateBookDto source)
    {
        return new Book(
            source.Id,
            source.Name,
            source.BookType,
            source.PublishDate,
            source.Price
        );
    }

    public Book Map(CreateUpdateBookDto source, Book destination)
    {
        destination.Name = source.Name;
        destination.BookType = source.BookType;
        destination.PublishDate = source.PublishDate;
        destination.Price = source.Price;

        return destination;
    }
}