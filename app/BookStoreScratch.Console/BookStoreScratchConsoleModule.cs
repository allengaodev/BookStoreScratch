using BookStoreScratch.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BookStoreScratch.Console;

[DependsOn(
    typeof(BookStoreScratchApplicationModule),
    typeof(BookStoreScratchEntityFrameworkCoreModule)
)]
public class BookStoreScratchConsoleModule : AbpModule
{
}