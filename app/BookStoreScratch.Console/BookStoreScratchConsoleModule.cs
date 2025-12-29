using BookStoreScratch.HttpApi.Client.Static;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BookStoreScratch.Console;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookStoreScratchHttpApiClientStaticModule)
)]
public class BookStoreScratchConsoleModule : AbpModule
{
}