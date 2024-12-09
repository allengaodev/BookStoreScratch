using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(BookStoreScratchDomainSharedModule))]
public class BookStoreScratchDomainModule : AbpModule
{
}