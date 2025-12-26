using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace BookStoreScratch.Books;

public class CreateUpdateBookDto : EntityDto<Guid>
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    public BookType BookType { get; set; } = BookType.Undefined;

    [Required]
    [DataType(DataType.Date)]
    public DateTime PublishDate { get; set; } = DateTime.Now;

    [Required]
    public decimal Price { get; set; }
}