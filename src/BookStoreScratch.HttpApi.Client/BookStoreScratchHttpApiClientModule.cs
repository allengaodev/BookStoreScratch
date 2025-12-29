using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace BookStoreScratch.HttpApi.Client;

[DependsOn(
    typeof(BookStoreScratchApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class BookStoreScratchHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(BookStoreScratchApplicationContractsModule).Assembly,
            "BookStoreScratch"
        );
    }
}