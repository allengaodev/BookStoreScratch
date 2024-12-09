using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BookStoreScratch.EntityFrameworkCore;

[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(BookStoreScratchDomainModule))]
public class BookStoreScratchEntityFrameworkCoreModule : AbpModule
{
}