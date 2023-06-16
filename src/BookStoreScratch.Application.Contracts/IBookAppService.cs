using System;
using BookStoreScratch.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStoreScratch;

public interface IBookAppService
    : ICrudAppService<
        BookDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookDto>
{
}