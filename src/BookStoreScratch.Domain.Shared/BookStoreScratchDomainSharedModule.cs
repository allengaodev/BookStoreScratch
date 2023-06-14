using Volo.Abp.Modularity;
using Volo.Abp.Validation;

namespace BookStoreScratch;

[DependsOn(typeof(AbpValidationModule))]
public class BookStoreScratchDomainSharedModule : AbpModule
{
}