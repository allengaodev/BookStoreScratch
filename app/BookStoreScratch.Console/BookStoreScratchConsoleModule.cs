using BookStoreScratch.HttpApi.Client;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BookStoreScratch.Console;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookStoreScratchHttpApiClientModule)
)]
public class BookStoreScratchConsoleModule : AbpModule
{
}