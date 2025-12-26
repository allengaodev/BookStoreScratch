using System;
using Volo.Abp.Application.Dtos;

namespace BookStoreScratch.Books;

public class BookDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public BookType BookType { get; set; }

    public DateTime PublishDate { get; set; }

    public decimal Price { get; set; }
}