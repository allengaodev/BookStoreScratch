using System;
using Volo.Abp.Domain.Entities;

namespace BookStoreScratch.Books;

public class Book : Entity<Guid>
{
    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }
}