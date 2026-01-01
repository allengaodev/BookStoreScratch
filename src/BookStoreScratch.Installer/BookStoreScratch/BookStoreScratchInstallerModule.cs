using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace BookStoreScratch;

[DependsOn(typeof(AbpVirtualFileSystemModule))]
public class BookStoreScratchInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BookStoreScratchInstallerModule>();
        });
    }
}