using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace BookStoreScratch;

public class BookStoreDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;
    private readonly ICurrentTenant _currentTenant;
    private readonly IGuidGenerator _guidGenerator;

    public BookStoreDataSeedContributor(
        IRepository<Book, Guid> bookRepository,
        ICurrentTenant currentTenant,
        IGuidGenerator guidGenerator)
    {
        _bookRepository = bookRepository;
        _currentTenant = currentTenant;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            if (await _bookRepository.GetCountAsync() > 0)
            {
                return;
            }

            var book = new Book(_guidGenerator.Create(),
                "The Hitchhiker's Guide to the Galaxy",
                BookType.ScienceFiction,
                new DateTime(1979, 10, 12),
                price: 42
            );

            await _bookRepository.InsertAsync(book);
        }
    }
}