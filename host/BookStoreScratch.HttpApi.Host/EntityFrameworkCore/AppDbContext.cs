using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStoreScratch.EntityFrameworkCore;

public class AppDbContext : AbpDbContext<AppDbContext>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    
        builder.ConfigureBookStoreScratch();
    }
}