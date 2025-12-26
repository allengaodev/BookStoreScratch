using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStoreScratch.Books;

public class BookAppService: ApplicationService, IBookAppService
{
    private readonly IBookStoreScratchRepository _bookStoreScratchRepository;
    private readonly BookManager _bookManager;

    public BookAppService(IBookStoreScratchRepository bookStoreScratchRepository, BookManager bookManager)
    {
        _bookStoreScratchRepository = bookStoreScratchRepository;
        _bookManager = bookManager;
    }

    public async Task<BookDto> GetAsync(Guid id)
    {
        var book = await _bookStoreScratchRepository.GetAsync(id);
        return ObjectMapper.Map<Book, BookDto>(book);
    }

    public async Task<PagedResultDto<BookDto>> GetListAsync(BookGetListInput input)
    {
        var books = await _bookStoreScratchRepository.GetPagedAndFilteredListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting.IsNullOrEmpty() ? "Id desc" : input.Sorting,
            input.Filter,
            includeDetails: true);

        var count = await _bookStoreScratchRepository.GetFilteredCountAsync(input.Filter);

        return new PagedResultDto<BookDto>(count, ObjectMapper.Map<List<Book>, List<BookDto>>(books));
    }

    public async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
    {
        var book = _bookManager.CreateBook(input.Name, input.Type, input.PublishDate, input.Price);
        await _bookStoreScratchRepository.InsertAsync(book);
        return ObjectMapper.Map<Book, BookDto>(book);
    }

    public async Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input)
    {
        var book = await _bookStoreScratchRepository.GetAsync(id);

        book.Name = input.Name;
        book.BookType = input.Type;
        book.PublishDate = input.PublishDate;
        book.Price = input.Price;

        await _bookStoreScratchRepository.UpdateAsync(book);

        return ObjectMapper.Map<Book, BookDto>(book);
    }

    public Task DeleteAsync(Guid id)
    {
        return _bookStoreScratchRepository.DeleteAsync(id);
    }
}