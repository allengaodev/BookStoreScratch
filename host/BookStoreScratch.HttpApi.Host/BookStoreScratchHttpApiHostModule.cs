using BookStoreScratch.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(
    typeof(BookStoreScratchApplicationModule),
    typeof(BookStoreScratchEntityFrameworkCoreModule),
    typeof(BookStoreScratchHttpApiModule)
)]
public class BookStoreScratchHttpApiHostModule : AbpModule
{
}