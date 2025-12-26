using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BookStoreScratch;

public interface IBookStoreScratchRepository : IBasicRepository<Book, Guid>
{
    Task<Book?> FindByBookNameAsync(string name);

    Task<List<Book>> GetPagedAndFilteredListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);

    Task<int> GetFilteredCountAsync(string filter, CancellationToken cancellationToken = default);
}

