using Airbnb.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Infrastructure;

public sealed class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options
) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
    }
}