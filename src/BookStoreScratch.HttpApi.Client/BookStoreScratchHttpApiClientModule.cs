using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(typeof(AbpHttpClientModule))]
[DependsOn(typeof(BookStoreScratchApplicationContractsModule))]
public class BookStoreScratchHttpApiClientModule : AbpModule
{
}