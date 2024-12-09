using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(typeof(AbpDddApplicationContractsModule))]
[DependsOn(typeof(BookStoreScratchDomainSharedModule))]
public class BookStoreScratchApplicationContractsModule : AbpModule
{
}