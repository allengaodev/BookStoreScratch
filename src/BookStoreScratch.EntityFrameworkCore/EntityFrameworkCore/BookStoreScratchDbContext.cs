using BookStoreScratch.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStoreScratch.EntityFrameworkCore;

public class BookStoreScratchDbContext : AbpDbContext<BookStoreScratchDbContext>
{
    public DbSet<Book> Books { get; set; }

    public BookStoreScratchDbContext(DbContextOptions<BookStoreScratchDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBookStoreScratch();
    }
}