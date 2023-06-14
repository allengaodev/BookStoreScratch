using System;
using BookStoreScratch.Books;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStoreScratch.EntityFrameworkCore;

public class EfCoreBookRepository : EfCoreRepository<BookStoreScratchDbContext, Book, Guid>
{
    public EfCoreBookRepository(IDbContextProvider<BookStoreScratchDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
}