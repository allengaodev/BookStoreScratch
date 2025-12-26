using System;
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
}