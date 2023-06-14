using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(typeof(AbpAspNetCoreMvcModule))]
[DependsOn(typeof(BookStoreScratchHttpApiModule))]
public class BookStoreScratchHttpApiModule : AbpModule
{
}