
using AIDocumentAssistant.Application.Interfaces;
using AIDocumentAssistant.Domain.Entities;
using AIDocumentAssistant.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AIDocumentAssistant.Infrastructure.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly AppDbContext _context;

    public DocumentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Document document)
    {
        await _context.Documents.AddAsync(document);
        await _context.SaveChangesAsync();
    }

    public async Task<Document?> GetByIdAsync(Guid id)
    {
        return await _context.Documents
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<List<Document>> GetAllAsync()
    {
        return await _context.Documents
            .AsNoTracking()
            .ToListAsync();
    }
}
