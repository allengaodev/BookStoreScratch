using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(typeof(AbpDddApplicationModule))]
[DependsOn(
    typeof(BookStoreScratchApplicationContractsModule),
    typeof(BookStoreScratchDomainModule)
)]
public class BookStoreScratchApplicationModule : AbpModule
{
}