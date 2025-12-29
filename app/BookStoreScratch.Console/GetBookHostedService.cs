using System.Threading;
using System.Threading.Tasks;
using BookStoreScratch.Books;
using Microsoft.Extensions.Hosting;

namespace BookStoreScratch.Console;

public class GetBookHostedService : IHostedService
{
    private readonly IBookAppService _bookService;

    public GetBookHostedService(IBookAppService bookService)
    {
        _bookService = bookService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var books = await _bookService.GetListAsync(new BookGetListInput());
        foreach (var book in books.Items)
        {
            System.Console.WriteLine($"[BOOK {book.Id}] Name={book.Name}");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}