using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
)]
[DependsOn(
    typeof(BookStoreScratchApplicationContractsModule),
    typeof(BookStoreScratchDomainModule)
)]
public class BookStoreScratchApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<BookStoreScratchApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BookStoreScratchApplicationModule>();
        });
    }
}