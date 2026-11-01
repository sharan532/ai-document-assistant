
using AIDocumentAssistant.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIDocumentAssistant.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Document> Documents => Set<Document>();
}
