using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStoreScratch;

public class Book : Entity<Guid>
{
    public string Name { get; set; }

    public BookType BookType { get; set; }

    public DateTime PublishDate { get; set; }

    public decimal Price { get; set; }

    internal Book() {}

    internal Book(
        Guid id,
        string name,
        BookType type,
        DateTime publishDate,
        decimal price)
        : base(id)
    {
        Name = name;
        BookType = type;
        PublishDate = publishDate;
        Price = price;
    }
}