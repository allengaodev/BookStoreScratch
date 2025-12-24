using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace BookStoreScratch;

public class BookStoreDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;
    private readonly ICurrentTenant _currentTenant;
    private readonly BookManager _bookManager;

    public BookStoreDataSeedContributor(
        IRepository<Book, Guid> bookRepository,
        ICurrentTenant currentTenant,
        BookManager bookManager)
    {
        _bookRepository = bookRepository;
        _currentTenant = currentTenant;
        _bookManager = bookManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            if (await _bookRepository.GetCountAsync() > 0)
            {
                return;
            }

            var book = _bookManager.CreateBook(
                "The Hitchhiker's Guide to the Galaxy",
                BookType.ScienceFiction,
                new DateTime(1979, 10, 12),
                price: 42
            );

            await _bookRepository.InsertAsync(book);
        }
    }
}