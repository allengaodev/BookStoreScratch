using System;
using System.Threading.Tasks;
using BookStoreScratch.Books;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace BookStoreScratch.Controllers;

[Area("book")]
[RemoteService(Name = "book")]
[Route("api/book")]
public class BookController : AbpControllerBase, IBookAppService
{
    private readonly IBookAppService _bookAppService;

    public BookController(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    [HttpGet("{id}")]
    public async Task<BookDto> GetAsync(Guid id)
    {
        return await _bookAppService.GetAsync(id);
    }

    [HttpGet]
    public async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _bookAppService.GetListAsync(input);
    }

    [HttpPost]
    public async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
    {
        return await _bookAppService.CreateAsync(input);
    }

    [HttpPut("{id}")]
    public async Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input)
    {
        return await _bookAppService.UpdateAsync(id, input);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await _bookAppService.DeleteAsync(id);
    }
}