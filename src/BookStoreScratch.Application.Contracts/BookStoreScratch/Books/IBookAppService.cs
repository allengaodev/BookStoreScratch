using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStoreScratch.Books;

public interface IBookAppService
    : ICrudAppService<
        BookDto,
        Guid,
        BookGetListInput,
        CreateUpdateBookDto>
{
}