using System;
using Volo.Abp.Application.Dtos;

namespace BookStoreScratch.Books;

public class BookDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }
}