using BookStoreScratch.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStoreScratch.HttpApi.Host;

public class UnifiedDbContext : AbpDbContext<UnifiedDbContext>
{
    public UnifiedDbContext(DbContextOptions<UnifiedDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureBookStoreScratch();
    }
}