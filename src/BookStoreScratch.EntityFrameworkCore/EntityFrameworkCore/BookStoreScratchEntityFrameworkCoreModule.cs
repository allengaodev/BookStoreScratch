using BookStoreScratch.Books;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BookStoreScratch.EntityFrameworkCore;

[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(BookStoreScratchDomainModule))]
public class BookStoreScratchEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<BookStoreScratchDbContext>(options =>
        {
            options.AddRepository<Book, EfCoreBookRepository>();
        });
    }
}