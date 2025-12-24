using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BookStoreScratch.EntityFrameworkCore;

public static class BookStoreScratchDbContextModelCreatingExtensions
{
    public static void ConfigureBookStoreScratch(this ModelBuilder builder)
    {
        builder.Entity<Book>(b =>
        {
            b.ToTable("Books");
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });
    }
}