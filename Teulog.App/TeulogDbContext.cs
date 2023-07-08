namespace Teulog.App;

using Microsoft.EntityFrameworkCore;
using Teulog.App.Entities;

public sealed class TeulogDbContext : DbContext
{
    public DbSet<OperatingSystem> OperatingSystems { get; set; } = default!;

    public TeulogDbContext(DbContextOptions<TeulogDbContext> options) : base(options) { }
}
