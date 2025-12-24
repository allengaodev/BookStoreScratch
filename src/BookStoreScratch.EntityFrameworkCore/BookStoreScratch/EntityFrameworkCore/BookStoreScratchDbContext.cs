using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BookStoreScratch.EntityFrameworkCore;

public class BookStoreScratchDbContext: AbpDbContext<BookStoreScratchDbContext>
{
    public DbSet<Book> Books { get; set; }

    public BookStoreScratchDbContext(DbContextOptions<BookStoreScratchDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Book>(b =>
        {
            b.ToTable("Books");
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });
    }
}