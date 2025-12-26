using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(
    typeof(BookStoreScratchApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class BookStoreScratchHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BookStoreScratchHttpApiModule).Assembly);
        });
    }
}