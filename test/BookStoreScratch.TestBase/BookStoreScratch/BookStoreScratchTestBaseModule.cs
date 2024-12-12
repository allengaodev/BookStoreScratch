using Volo.Abp;
using Volo.Abp.Modularity;

namespace BookStoreScratch;

[DependsOn(
    typeof(AbpTestBaseModule)
)]
public class BookStoreScratchTestBaseModule : AbpModule
{
}