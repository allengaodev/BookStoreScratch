using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStoreScratch.EntityFrameworkCore;

public class EfCoreBookStoreScratchRepository: EfCoreRepository<BookStoreScratchDbContext, Book, Guid>, IBookStoreScratchRepository
{
    public EfCoreBookStoreScratchRepository(IDbContextProvider<BookStoreScratchDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Book?> FindByBookNameAsync(string name)
    {
        return await (await GetDbSetAsync())
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<Book>> GetPagedAndFilteredListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var queryable = (includeDetails ? await WithDetailsAsync() : await GetQueryableAsync());

        queryable = CreateFilteredQuery(queryable, filter)
            .OrderBy(sorting.IsNullOrEmpty() ? $"{nameof(Book.PublishDate)} desc" : sorting)
            .Skip(skipCount)
            .Take(maxResultCount);

        return await queryable.ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<int> GetFilteredCountAsync(string filter, CancellationToken cancellationToken = default)
    {
        var queryable = await GetQueryableAsync();
        return await CreateFilteredQuery(queryable, filter)
            .CountAsync(GetCancellationToken(cancellationToken));
    }

    protected virtual IQueryable<Book> CreateFilteredQuery(
        IQueryable<Book> queryable,
        string filter)
    {
        var query = queryable
            .WhereIf(!filter.IsNullOrEmpty(), x => x.Name.ToLower().Contains(filter.ToLower()));

        return query;
    }
}