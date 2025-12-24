using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BookStoreScratch;

public interface IBookStoreScratchEventRepository : IBasicRepository<Book, Guid>
{
    Task<Book?> FindByBookNameAsync(string name);
}

