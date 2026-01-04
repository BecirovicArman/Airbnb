using Airbnb.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    
}