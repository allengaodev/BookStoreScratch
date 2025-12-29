using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace BookStoreScratch.HttpApi.Client.Static;

[DependsOn(
    typeof(AbpHttpClientModule),
    typeof(AbpVirtualFileSystemModule),
    typeof(BookStoreScratchApplicationContractsModule)
)]
public class BookStoreScratchHttpApiClientStaticModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddStaticHttpClientProxies(
            typeof(BookStoreScratchApplicationContractsModule).Assembly
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BookStoreScratchHttpApiClientStaticModule>();
        });
    }
}