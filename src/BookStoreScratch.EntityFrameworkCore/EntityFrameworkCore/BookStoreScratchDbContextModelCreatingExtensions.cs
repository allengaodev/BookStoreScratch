using BookStoreScratch.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BookStoreScratch.EntityFrameworkCore;

public static class BookStoreScratchDbContextModelCreatingExtensions
{
    public static void ConfigureBookStoreScratch(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        
        builder.Entity<Book>(b =>
        {
            b.ToTable("AppBooks", "dbo");
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });
    }
}