using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(
    typeof(BookStoreScratchTestBaseModule)
)]
public class BookStoreScratchDomainTestModule : AbpModule
{
}