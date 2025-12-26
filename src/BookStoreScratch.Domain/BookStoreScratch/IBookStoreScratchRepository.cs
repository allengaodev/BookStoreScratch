using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BookStoreScratch;

public interface IBookStoreScratchRepository : IBasicRepository<Book, Guid>
{
    Task<Book?> FindByBookNameAsync(string name);
}

