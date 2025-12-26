using Volo.Abp.Application.Dtos;

namespace BookStoreScratch.Books;

public class BookGetListInput : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
